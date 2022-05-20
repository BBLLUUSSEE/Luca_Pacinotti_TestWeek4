CREATE DATABASE GestioneSpese;

CREATE TABLE Spese(
id int primary key identity(1,1),
Data datetime,
Categoria int,
Descrizione varchar(500),
Utente varchar(100),
Importo decimal(5,2),
Approvato bit,
CONSTRAINT FK_CATEGORIA FOREIGN KEY (Categoria) REFERENCES Categoria(id)
);

CREATE TABLE Categoria(
id int primary key identity(100,1),
Categoria varchar(100) not null
);

INSERT INTO Categoria VALUES('Viveri');
INSERT INTO Categoria VALUES('Immobili');
INSERT INTO Categoria VALUES('Abbigliamento');
INSERT INTO Categoria VALUES('Meccanico');
INSERT INTO Categoria VALUES('Sport');
select * from Categoria
select * from Spese

SELECT * FROM Spese WHERE Approvato = 1;
SELECT * FROM Spese WHERE Utente LIKE 'Luca';
SELECT SUM(Spese.Importo) FROM Spese WHERE Categoria = 103; 