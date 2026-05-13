CREATE DATABASE DBSistemMonitoringMasaTanam
GO

CREATE TABLE DataTanaman(
	TanamanID INT IDENTITY(1,1) PRIMARY KEY,
	NamaTanaman VARCHAR(50) UNIQUE NOT NULL,
	LamaMasaTanam INT NOT NULL
);

CREATE TABLE DataLahan(
	LahanID INT IDENTITY(1,1) PRIMARY KEY,
	NamaLahan VARCHAR(50) UNIQUE NOT NULL,
	luas_lahan FLOAT NOT NULL
);

CREATE TABLE JadwalTanam(
	JadwalID INT IDENTITY(1,1) PRIMARY KEY,
	TanamanID INT NOT NULL,
	LahanID INT NOT NULL,
	TanggalTanam DATE NOT NULL,
	EstimasiPanen DATE NOT NULL,

	CONSTRAINT FK_Tanaman_ID FOREIGN KEY (TanamanID) REFERENCES DataTanaman(TanamanID) ON DELETE CASCADE,
	CONSTRAINT FK_Lahan_ID FOREIGN KEY (LahanID) REFERENCES DataLahan(LahanID) ON DELETE CASCADE
);

CREATE TABLE Report(
	ReportID INT IDENTITY(1,1) PRIMARY KEY
);

ALTER TABLE DataTanaman ADD CONSTRAINT CHK_NamaTanaman CHECK(NamaTanaman NOT LIKE '%[^a-zA-Z ]%');
ALTER TABLE DataTanaman ADD CONSTRAINT CHK_LamaMasaTanam CHECK(LamaMasaTanam > 0);

ALTER TABLE DataLahan ADD CONSTRAINT CHK_NamaLahan CHECK(NamaLahan NOT LIKE '%[^a-zA-Z ]%');
ALTER TABLE DataLahan ADD CONSTRAINT CHK_luaslahan CHECK(luas_lahan > 0);

ALTER TABLE JadwalTanam ADD CONSTRAINT CHK_TanggalTanam CHECK(TanggalTanam <= GETDATE())

DROP TABLE JadwalTanam

SELECT * FROM DataLahan
SELECT * FROM DataTanaman

-- Jadwal Tanam perlu unique atau tidak ( tiap tanaman hanya satu saja )
SELECT * FROM JadwalTanam

SELECT
    DataTanaman.TanamanID AS TanamanID,
    DataTanaman.NamaTanaman AS Nama,
    DataTanaman.LamaMasaTanam AS LamaMasaTanam,
    DataLahan.namaLahan AS NamaLahan
  FROM
    DataTanaman
  LEFT JOIN
    DataLahan
  ON DataTanaman.NamaTanaman = DataLahan.NamaLahan;

  SELECT
    JT.JadwalID AS IDJadwal,
    DT.NamaTanaman AS NamaTanaman,
    DL.NamaLahan AS NamaTanaman,
    JT.TanggalTanam AS TanggalTanam,
    JT.EstimasiPanen AS EstimasiPanen

  FROM JadwalTanam JT
  INNER JOIN DataTanaman DT ON  JT.TanamanID = DT.TanamanID
  INNER JOIN DataLahan DL ON JT.LahanID = DL.LahanID

  select * from DataTanaman;

-- ==============================================================
--           SEMUA VIEW dan SP PADA TABLE Data Tanaman
-- ==============================================================

ALTER VIEW v_GetTanaman AS
  SELECT
    DataTanaman.TanamanID AS TanamanID,
    DataTanaman.NamaTanaman AS NamaTanaman,
    DataTanaman.LamaMasaTanam AS LamaMasaTanam
  FROM
    DataTanaman
SELECT * FROM DataTanaman

SELECT * FROM DataTanaman
SELECT * FROM DataTanaman_Backup

ALTER PROCEDURE sp_InsertTanaman
    @NamaTanaman VARCHAR(50),
    @LamaMasaTanam INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM DataTanaman WHERE NamaTanaman = @NamaTanaman)
    BEGIN 
        THROW 51000, 'Nama tanaman itu sudah terdaftar', 1;
    END

    IF @NamaTanaman LIKE '%[^a-zA-Z ]%'
    BEGIN
        THROW 51000, 'Nama tanaman hanya boleh abjad', 1;
    END

    IF @LamaMasaTanam < 0 
    BEGIN
        THROW 51000, 'Lama masa tanam tidak boleh kurang dari 0', 1;
    END

    IF @LamaMasaTanam = 0
    BEGIN
        THROW 51000, 'Lama masa tanam harus diisi', 1;
    END

    INSERT INTO DataTanaman(NamaTanaman, LamaMasaTanam)
    VALUES (@NamaTanaman, @LamaMasaTanam);
END

ALTER PROCEDURE sp_UpdateTanaman
    @TanamanID INT,
    @NamaTanaman VARCHAR(50),
    @LamaMasaTanam INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM DataTanaman WHERE TanamanID = @TanamanID)
    BEGIN
        THROW 51000, 'Data tanaman tidak ditemukan atau sudah dihapus!', 1;
    END

    IF @NamaTanaman IS NULL 
    BEGIN
        THROW 51000, 'Nama tanaman harus terisi', 1;
    END

    IF EXISTS (SELECT 1 FROM DataTanaman WHERE NamaTanaman = @NamaTanaman AND TanamanID != @TanamanID)
    BEGIN 
        THROW 51000, 'Nama tanaman itu sudah terdaftar untuk tanaman lain', 1;
    END

    IF @NamaTanaman LIKE '%[^a-zA-Z ]%'
    BEGIN
        THROW 51000, 'Nama tanaman hanya boleh abjad', 1;
    END

    IF @LamaMasaTanam < 0 
    BEGIN
        THROW 51000, 'Lama masa tanam tidak boleh kurang dari 0', 1;
    END

    IF @LamaMasaTanam = 0
    BEGIN 
        THROW 51000, 'Lama masa tanam harus terisi', 1;
    END

    -- TAHAP 1: EKSEKUSI UPDATE KE TABEL PARENT (MASTER TANAMAN)
    UPDATE DataTanaman
    SET 
        NamaTanaman = @NamaTanaman,
        LamaMasaTanam = @LamaMasaTanam
    WHERE 
        TanamanID = @TanamanID;

    -- TAHAP 2: EKSEKUSI OTOMATIS KE TABEL CHILD (JADWAL TANAM)
    -- Hitung ulang EstimasiPanen (TanggalTanam + LamaMasaTanam yang baru)
    UPDATE JadwalTanam
    SET 
        EstimasiPanen = DATEADD(day, @LamaMasaTanam, TanggalTanam)
    WHERE 
        TanamanID = @TanamanID;
END

CREATE PROCEDURE sp_DeleteTanaman
    @TanamanID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM DataTanaman WHERE TanamanID = @TanamanID)
    BEGIN
        THROW 51000, 'Data tanaman tidak ditemukan atau sudah dihapus sebelumnya!', 1;
    END

    IF EXISTS (SELECT 1 FROM JadwalTanam WHERE TanamanID = @TanamanID)
    BEGIN
        THROW 51000, 'Gagal menghapus! Tanaman ini sedang digunakan di Jadwal Tanam. Hapus jadwalnya terlebih dahulu.', 1;
    END

    DELETE FROM DataTanaman 
    WHERE TanamanID = @TanamanID;
END

-- ==============================================================
--            SEMUA VIEW dan SP PADA TABLE Data Lahan
-- ==============================================================

  ALTER VIEW v_GetLahan AS
  SELECT
    LahanID AS LahanID,
    NamaLahan AS NamaLahan,
    luas_lahan AS luas_lahan
  FROM DataLahan



ALTER PROCEDURE sp_InsertLahan
    @NamaLahan VARCHAR(50),
    @luas_lahan FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM DataLahan WHERE NamaLahan = @NamaLahan)
    BEGIN 
        THROW 51000, 'Nama lahan itu sudah terdaftar', 1;
    END

    IF @NamaLahan LIKE '%[^a-zA-Z ]%'
    BEGIN
        THROW 51000, 'Nama lahan hanya boleh abjad', 1;
    END

    IF @luas_lahan < 0 
    BEGIN
        THROW 51000, 'Luas lahan tidak boleh kurang dari 0', 1;
    END

    IF @luas_lahan = 0
    BEGIN
        THROW 51000, 'Luas lahan harus diisi', 1;
    END

    IF @luas_lahan LIKE '%[^0-9]%'
    BEGIN
        THROW 51000, 'Luas lahan harus berupa angka',1;
    END

    INSERT INTO DataLahan(NamaLahan, luas_lahan)
    VALUES (@NamaLahan, @luas_lahan);
END



ALTER PROCEDURE sp_UpdateLahan
    @LahanID INT,
    @NamaLahan VARCHAR(50),
    @luas_lahan INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM DataLahan WHERE LahanID = @LahanID)
    BEGIN
        THROW 51000, 'Data lahan tidak ditemukan atau sudah dihapus!', 1;
    END

    IF @NamaLahan IS NULL 
    BEGIN
        THROW 51000, 'Nama lahan harus terisi', 1;
    END

    IF EXISTS (SELECT 1 FROM DataLahan WHERE NamaLahan= @NamaLahan AND LahanID != @LahanID)
    BEGIN 
        THROW 51000, 'Nama lahan itu sudah terdaftar untuk lahan lain', 1;
    END

    IF @NamaLahan LIKE '%[^a-zA-Z ]%'
    BEGIN
        THROW 51000, 'Nama lahan hanya boleh abjad', 1;
    END

    IF @luas_lahan < 0 
    BEGIN
        THROW 51000, 'Luas lahan tidak boleh kurang dari 0', 1;
    END

    IF @luas_lahan = 0
    BEGIN 
        THROW 51000, 'Luas lahan harus terisi', 1;
    END

    UPDATE DataLahan
    SET 
        NamaLahan = @NamaLahan,
        luas_lahan = @luas_lahan
    WHERE 
        LahanID = @LahanID;
END


ALTER PROCEDURE sp_DeleteLahan
    @LahanID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM DataLahan WHERE LahanID = @LahanID)
    BEGIN
        THROW 51000, 'Data tanaman tidak ditemukan atau sudah dihapus sebelumnya!', 1;
    END

    IF EXISTS (SELECT 1 FROM JadwalTanam WHERE LahanID = @LahanID)
    BEGIN
        THROW 51000, 'Gagal menghapus! Tanaman ini sedang digunakan di Jadwal Tanam. Hapus jadwalnya terlebih dahulu.', 1;
    END

    DELETE FROM DataLahan 
    WHERE
        LahanID = @LahanID;
END

CREATE PROCEDURE sp_ResetInjection
AS
BEGIN
    SET NOCOUNT ON;
    
    IF OBJECT_ID('DataLahan_Backup') IS NOT NULL
    BEGIN
        DELETE FROM DataLahan;
        SET IDENTITY_INSERT DataLahan ON;
        
        INSERT INTO DataLahan (LahanID, NamaLahan, luas_lahan)
        SELECT LahanID, NamaLahan, luas_lahan FROM DataLahan_Backup;
        
        SET IDENTITY_INSERT DataLahan OFF;
    END
    ELSE
    BEGIN
        THROW 51000, 'Tabel backup (DataLahan_Backup) tidak ditemukan!', 1;
    END
END

CREATE PROCEDURE sp_Injection
    @LuasLahan NVARCHAR(MAX),
    @LahanID NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @sqlQuery NVARCHAR(MAX);
    
    -- INI ADALAH CELAH KEAMANANNYA: Menggabungkan string secara mentah (Concatenation)
    SET @sqlQuery = 'UPDATE DataLahan SET NamaLahan = ''HACKED'', luas_lahan = ' + @LuasLahan + ' WHERE LahanID = ' + @LahanID;
    
    -- Menjalankan string tersebut sebagai perintah SQL
    EXEC(@sqlQuery);
END



-- ==============================================================
--           SEMUA VIEW dan SP PADA TABLE JADWAL TANAM
-- ==============================================================
--VIEW JADWAL (pake join)
CREATE OR ALTER VIEW v_GetJadwal AS
SELECT
    JT.JadwalID AS JadwalID,
    JT.TanamanID,             -- Tetap bawa ID untuk kebutuhan sistem
    DT.NamaTanaman AS NamaTanaman,
    JT.LahanID,                -- Tetap bawa ID untuk kebutuhan sistem
    DL.NamaLahan AS NamaLahan,
    JT.TanggalTanam AS TanggalTanam,
    JT.EstimasiPanen AS EstimasiPanen
FROM JadwalTanam JT
INNER JOIN DataTanaman DT ON JT.TanamanID = DT.TanamanID
INNER JOIN DataLahan DL ON JT.LahanID = DL.LahanID

CREATE VIEW v_Get_CMB_DataTanaman AS
SELECT
    TanamanID,
    NamaTanaman
FROM
DataTanaman

CREATE VIEW v_Get_CMB_DataLahan AS
SELECT
    LahanID,
    NamaLahan
FROM
DataLahan

ALTER PROCEDURE sp_Get_LamaMasaTanam 
@TanamanID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        LamaMasaTanam
    FROM
        DataTanaman
    WHERE 
        TanamanID = @TanamanID
END

CREATE PROCEDURE sp_InsertJadwal
    @TanamanID INT,
    @LahanID INT,
    @TanggalTanam DATE,
    @EstimasiPanen DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF @TanamanID IS NULL OR @LahanID IS NULL
    BEGIN
        THROW 51000, 'Tanaman dan Lahan harus dipilih!', 1;
    END

    IF @TanggalTanam > @EstimasiPanen
    BEGIN
        THROW 51000, 'Tanggal tanam tidak logis!', 1;
    END

    -- 3. Eksekusi Simpan
    INSERT INTO JadwalTanam (TanamanID, LahanID, TanggalTanam, EstimasiPanen)
    VALUES (@TanamanID, @LahanID, @TanggalTanam, @EstimasiPanen);
END

CREATE PROCEDURE sp_UpdateJadwal
    @JadwalID INT,
    @TanamanID INT,
    @LahanID INT,
    @TanggalTanam DATE,
    @EstimasiPanen DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Pastikan data yang mau diubah beneran ada
    IF NOT EXISTS (SELECT 1 FROM JadwalTanam WHERE JadwalID = @JadwalID)
    BEGIN
        THROW 51000, 'Data jadwal tidak ditemukan atau sudah dihapus!', 1;
    END

    -- 2. Validasi input ID
    IF @TanamanID IS NULL OR @LahanID IS NULL
    BEGIN
        THROW 51000, 'Tanaman dan Lahan harus dipilih!', 1;
    END

    -- 3. Validasi logis tanggal
    IF @TanggalTanam > @EstimasiPanen
    BEGIN
        THROW 51000, 'Tanggal tanam tidak logis!', 1;
    END

    -- 4. Eksekusi Update
    UPDATE JadwalTanam
    SET 
        TanamanID = @TanamanID,
        LahanID = @LahanID,
        TanggalTanam = @TanggalTanam,
        EstimasiPanen = @EstimasiPanen
    WHERE JadwalID = @JadwalID;
END

CREATE PROCEDURE sp_DeleteJadwal
    @JadwalID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM JadwalTanam WHERE JadwalID = @JadwalID)
    BEGIN
        THROW 51000, 'Data jadwal tidak ditemukan atau sudah dihapus sebelumnya!', 1;
    END

    DELETE FROM JadwalTanam 
    WHERE JadwalID = @JadwalID;
END

SELECT * FROM DataLahan
SELECT * FROM DataTanaman

DROP TABLE Report

SELECT * INTO DataLahan_Backup FROM DataLahan;
SELECT * FROM DataLahan_Backup
SELECT * FROM DataLahan
