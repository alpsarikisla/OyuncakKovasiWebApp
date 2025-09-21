CREATE DATABASE OyuncakKovasi_DB
GO
USE OyuncakKovasi_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int PRIMARY KEY IDENTITY(1,1),
	Isim nvarchar(25) NOT NULL
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Moderator')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTurID int,
	Isim nvarchar(75) NOT NULL,
	Soyisim nvarchar(75),
	KullaniciAdi nvarchar(25) NOT NULL,
	Mail nvarchar(150) NOT NULL,
	Sifre nvarchar(12) NOT NULL,
	AktifMi bit,
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID)
	REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler(YoneticiTurID,Isim,Soyisim,KullaniciAdi,Mail,Sifre,AktifMi)
VALUES(1,'Dev','Dev','developer','developer@developer.com','1234',1)
GO
CREATE TABLE Uyeler
(
	ID int PRIMARY KEY IDENTITY(1,1),
	Isim nvarchar(75) NOT NULL,
	Soyisim nvarchar(75),
	KullaniciAdi nvarchar(25) NOT NULL,
	Mail nvarchar(150) NOT NULL,
	Sifre nvarchar(12) NOT NULL,
	AktifMi bit,
)
GO
CREATE TABLE Kategoriler
(
	ID int PRIMARY KEY IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	AktifMi bit
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(10000,1),
	YazarID int,
	KategoriID int,
	Baslik nvarchar(150) NOT NULL,
	Icerik ntext,
	Ozet nvarchar(500),
	KapakResim nvarchar(50),
	GoruntulemeSayi int,
	EklemeTarihi dateTime,
	SilinmisMi bit,
	AktifMi bit,
	CONSTRAINT pk_makale PRIMARY KEY(ID),
	CONSTRAINT fk_makaleYazar FOREIGN KEY(YazarID)
	REFERENCES Yoneticiler(ID),
	CONSTRAINT fk_makaleKategori FOREIGN KEY(KategoriID)
	REFERENCES Kategoriler(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	MakaleID int,
	UyeID int,
	Icerik ntext,
	Tarih Datetime,
	Yayinla bit,
	CONSTRAINT pk_yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(MakaleID)
	REFERENCES Makaleler(ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID)
	REFERENCES Uyeler(ID)
)

