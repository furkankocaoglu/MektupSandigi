CREATE DATABASE MektupSandigi_DB
GO
USE MektupSandigi_DB
GO
CREATE TABLE YoneticilerTable
(
    YoneticiID int IDENTITY(1,1),
    Isim nvarchar(50),
    Soyisim nvarchar(50),
    KullaniciAdi nvarchar(50),
    Mail nvarchar(120),
    Sifre nvarchar(20),
    Durum bit,
    Silinmis bit,
    CONSTRAINT pk_Yoneticiler PRIMARY KEY(YoneticiID),
)
GO

INSERT INTO YoneticilerTable(Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis)
VALUES('Furkan', 'Kocaoðlu', 'Admin', 'furkan.kocaoglu@gmail.com', '1234', 1, 0)

GO
CREATE TABLE KullanicilarTable
(   
    KullaniciID int IDENTITY (1,1),
    KullaniciAdi nvarchar(50),
    Mail nvarchar(120),
    Sifre nvarchar(20),
    OlusturmaTarihi datetime,
    Durum bit,
    Silinmis bit,
    CONSTRAINT pk_Kullanicilar PRIMARY KEY(KullaniciID)
)
GO
CREATE TABLE KategorilerTable
(
    KategoriID int IDENTITY(1,1),
    KategoriIsim nvarchar(50) NOT NULL,
    CONSTRAINT pk_Kategoriler PRIMARY KEY(KategoriID)
)
GO

INSERT INTO KategorilerTable(KategoriIsim) VALUES('Kendime')
INSERT INTO KategorilerTable(KategoriIsim) VALUES('Arkadaþýma')
INSERT INTO KategorilerTable(KategoriIsim) VALUES('Sevgilime')
INSERT INTO KategorilerTable(KategoriIsim) VALUES('Eþime')

GO

CREATE TABLE MektuplarTable
(
    MektupID int IDENTITY (1,1),
    KullaniciID int,
    KategoriID int,
    Baslik nvarchar(200),    
    Icerik ntext,    
    AliciMail nvarchar(200),
    GonderimTarihi datetime, 
    AcilisTarihi datetime, 
    TeslimEdildiMi bit,
    OlusturmaTarihi datetime,
    CONSTRAINT pk_Mektuplar PRIMARY KEY(MektupID),
    CONSTRAINT fk_MektuplarKullanicilar FOREIGN KEY(KullaniciID) REFERENCES KullanicilarTable(KullaniciID),
    CONSTRAINT fk_MektuplarKategoriler FOREIGN KEY(KategoriID) REFERENCES KategorilerTable(KategoriID)
)
GO
CREATE TABLE YorumlarTable
(
    YorumID int IDENTITY (1,1),
    MektupID int,
    KullaniciID int,
    YorumIcerik ntext,
    OlusturmaTarihi datetime,
    CONSTRAINT pk_Yorumlar PRIMARY KEY(YorumID),
    CONSTRAINT fk_YorumlarMektuplar FOREIGN KEY(MektupID) REFERENCES MektuplarTable(MektupID),
    CONSTRAINT fk_YorumlarKullanicilar FOREIGN KEY(KullaniciID) REFERENCES KullanicilarTable(KullaniciID)
)
GO
CREATE TABLE DesteklerTable

(
	DestekID int IDENTITY (1,1),
	KullaniciID int,
	Baslik nvarchar(200),
	Icerik ntext, 
	CONSTRAINT pk_Destekler PRIMARY KEY(DestekID),
	CONSTRAINT fk_DesteklerKullanicilar FOREIGN KEY(KullaniciID) REFERENCES KullanicilarTable(KullaniciID)
)
