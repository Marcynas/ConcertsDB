#@(#) script.ddl

DROP TABLE IF EXISTS IRANGA;
DROP TABLE IF EXISTS DARBAS;
DROP TABLE IF EXISTS PASIRODYMAS;
DROP TABLE IF EXISTS IRENGiNYS;
DROP TABLE IF EXISTS DARBUOTOJAS;
DROP TABLE IF EXISTS KONCERTAS;
DROP TABLE IF EXISTS IRENGINIO_TIPAS;
DROP TABLE IF EXISTS ATLIKEJAS;
DROP TABLE IF EXISTS ASMUO;
DROP TABLE IF EXISTS Tipas;
DROP TABLE IF EXISTS Role;
DROP TABLE IF EXISTS Miestas;
DROP TABLE IF EXISTS Lytis;
CREATE TABLE Lytis
(
	id_Lytis integer,
	name char (7) NOT NULL,
	PRIMARY KEY(id_Lytis)
);
INSERT INTO Lytis(id_Lytis, name) VALUES(1, 'Vyras');
INSERT INTO Lytis(id_Lytis, name) VALUES(2, 'Moteris');

CREATE TABLE Miestas
(
	id_Miestas integer,
	name char (11) NOT NULL,
	PRIMARY KEY(id_Miestas)
);
INSERT INTO Miestas(id_Miestas, name) VALUES(1, 'Vilnius');
INSERT INTO Miestas(id_Miestas, name) VALUES(2, 'Kaunas');
INSERT INTO Miestas(id_Miestas, name) VALUES(3, 'Klaipeda');
INSERT INTO Miestas(id_Miestas, name) VALUES(4, 'Siauliai');
INSERT INTO Miestas(id_Miestas, name) VALUES(5, 'Panevezys');
INSERT INTO Miestas(id_Miestas, name) VALUES(6, 'Alytus');
INSERT INTO Miestas(id_Miestas, name) VALUES(7, 'Marijampole');
INSERT INTO Miestas(id_Miestas, name) VALUES(8, 'Mazeikiai');
INSERT INTO Miestas(id_Miestas, name) VALUES(9, 'Jonava');
INSERT INTO Miestas(id_Miestas, name) VALUES(10, 'Utena');
INSERT INTO Miestas(id_Miestas, name) VALUES(11, 'Kedainiai');
INSERT INTO Miestas(id_Miestas, name) VALUES(12, 'Taurage');
INSERT INTO Miestas(id_Miestas, name) VALUES(13, 'Telsiai');
INSERT INTO Miestas(id_Miestas, name) VALUES(14, 'Ukmerge');

CREATE TABLE Role
(
	id_Role integer,
	name char (20) NOT NULL,
	PRIMARY KEY(id_Role)
);
INSERT INTO Role(id_Role, name) VALUES(1, 'Garso_indzinierius');
INSERT INTO Role(id_Role, name) VALUES(2, 'Gitaru_technikas');
INSERT INTO Role(id_Role, name) VALUES(3, 'Apsvietimo_technikas');
INSERT INTO Role(id_Role, name) VALUES(4, 'Koordinatorius');
INSERT INTO Role(id_Role, name) VALUES(5, 'Scenos_vadybininkas');

CREATE TABLE Tipas
(
	id_Tipas integer,
	name char (11) NOT NULL,
	PRIMARY KEY(id_Tipas)
);
INSERT INTO Tipas(id_Tipas, name) VALUES(1, 'Apsvietimas');
INSERT INTO Tipas(id_Tipas, name) VALUES(2, 'Mikrofonas');
INSERT INTO Tipas(id_Tipas, name) VALUES(3, 'Iem');
INSERT INTO Tipas(id_Tipas, name) VALUES(4, 'Laidas');
INSERT INTO Tipas(id_Tipas, name) VALUES(5, 'Kolonele');
INSERT INTO Tipas(id_Tipas, name) VALUES(6, 'Pultas');

CREATE TABLE ASMUO
(
	id int,
	vardas varchar (255),
	pavarde varchar (255),
	lytis integer,
	PRIMARY KEY(id),
	FOREIGN KEY(lytis) REFERENCES Lytis (id_Lytis)
);

CREATE TABLE ATLIKEJAS
(
	id int,
	vardas varchar (255),
	pavarde varchar (255),
	zanras varchar (255),
	kontaktai varchar (255),
	lytis integer,
	PRIMARY KEY(id),
	FOREIGN KEY(lytis) REFERENCES Lytis (id_Lytis)
);

CREATE TABLE IRENGINIO_TIPAS
(
	id int,
	tipas integer,
	PRIMARY KEY(id),
	FOREIGN KEY(tipas) REFERENCES Tipas (id_Tipas)
);

CREATE TABLE KONCERTAS
(
	id int,
	pavadinimas varchar (255),
	pradzia timestamp,
	pabaiga timestamp,
	aprasymas varchar (255),
	miestas integer,
	PRIMARY KEY(id),
	FOREIGN KEY(miestas) REFERENCES Miestas (id_Miestas)
);

CREATE TABLE DARBUOTOJAS
(
	id int,
	dirbaNuo timestamp,
	dirbaIki timestamp,
	Darbuotojo_role integer,
	fk_ASMUOid int NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(Darbuotojo_role) REFERENCES Role (id_Role),
	CONSTRAINT yra FOREIGN KEY(fk_ASMUOid) REFERENCES ASMUO (id)
);

CREATE TABLE IRENGiNYS
(
	id int,
	pavadinimas varchar (255),
	turimas_kiekis float,
	fk_IRENGINIO_TIPASid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT priklauso FOREIGN KEY(fk_IRENGINIO_TIPASid) REFERENCES IRENGINIO_TIPAS (id)
);

CREATE TABLE PASIRODYMAS
(
	id int,
	pavadinimas varchar (255),
	kaina float,
	sumoketa float,
	fk_KONCERTASid int NOT NULL,
	fk_ATLIKEJASid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT vyksta FOREIGN KEY(fk_KONCERTASid) REFERENCES KONCERTAS (id),
	CONSTRAINT atlieka FOREIGN KEY(fk_ATLIKEJASid) REFERENCES ATLIKEJAS (id)
);

CREATE TABLE DARBAS
(
	id int,
	pradzia timestamp,
	pabaiga timestamp,
	alga float,
	sumoketa float,
	fk_DARBUOTOJASid int NOT NULL,
	fk_KONCERTASid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT priskirtas FOREIGN KEY(fk_DARBUOTOJASid) REFERENCES DARBUOTOJAS (id),
	CONSTRAINT atliekamas FOREIGN KEY(fk_KONCERTASid) REFERENCES KONCERTAS (id)
);

CREATE TABLE IRANGA
(
	id int,
	kiekis int,
	kaina float,
	sumoketa float,
	fk_IRENGiNYSid int NOT NULL,
	fk_KONCERTASid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT reikia FOREIGN KEY(fk_IRENGiNYSid) REFERENCES IRENGiNYS (id),
	CONSTRAINT turi FOREIGN KEY(fk_KONCERTASid) REFERENCES KONCERTAS (id)
);
