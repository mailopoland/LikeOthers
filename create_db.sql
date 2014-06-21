use likeothersdb;

IF OBJECT_ID('UsersResults') IS NOT NULL 
BEGIN
ALTER TABLE UsersResults drop FK__UsersResults;
DROP TABLE UsersResults;
END
IF OBJECT_ID('Options') IS NOT NULL
BEGIN
ALTER TABLE Options drop FK__Options;
DROP TABLE Options;
END
IF OBJECT_ID('Questions') IS NOT NULL DROP TABLE Questions;
IF OBJECT_ID('ResultTexts') IS NOT NULL DROP TABLE ResultTexts;

create table ResultTexts (
Min int NOT null unique,
Max int Not null unique,
Text nchar(200) Not null,
PRIMARY KEY (Min)
)

create table Questions (
Id int NOT null,
Question nchar(100) NOT null,
PRIMARY KEY (Id)
)

create table Options (
Id int NOT null,
IdQuestion int NOT null,
Image char(15) NOT null,
Description nchar(25),
PRIMARY KEY (Id),
CONSTRAINT FK__Options FOREIGN KEY (IdQuestion) REFERENCES Questions(Id)
)

create table UsersResults (
IdOption int NOT null,
Amount int Not null DEFAULT 1,
PRIMARY KEY (IdOption),
CONSTRAINT FK__UsersResults FOREIGN KEY (IdOption) REFERENCES Options(Id)
)

Insert into Questions values(1,'Co wolisz?'),(2,N'Na kt�re zdj�cie pierw spojrza�e�?');
Insert into Questions values(3,N'Na co masz ochot�?'),(4,'Gdzie jest gorzej?'),(5,'Gdzie jest lepiej?');
Insert into Options values(1,1,'book.jpg',N'Dobr� ksi��k�'),
(2,1,'movie.jpg',N'Niez�y film'),
(3,2,'blonde.jpg','Blondooka'),
(4,2,'brunette.jpg','Brunetka');
Insert into Options values(5,3,'banana.jpg',N'Naj��tsze z naj��tszych'),
(6,3,'apple.jpg','Jabuszko'),
(7,4,'school.jpg',N'Strach si� ba�'),
(8,4,'motherinlaw.jpg',N'U mamusi (te�ciowej)'),
(9,5,'sea.jpg',N'S�oneczna morska pla�a'),
(10,5,'mountains.jpg',N'Najpi�kniejsze szczyty');

Insert into ResultTexts values(76, 100, N'Jeste� tak przeci�tny, �e a� mi cie �al.'),
(0,25, N'Jeste� tak odklejony od rzeczywisto�ci, �e prawdopodobnie nied�ugo cie zamkn�.'),
(26,50, N'Zdecydowanie r�nisz si� od reszty ale nie pal ju� wi�cej.'),
(51,75, N'Jeste� powy�ej �redniej przeci�tno�ci z t�d o krok do nijako�ci, przemy�l to.');
Insert into UsersResults values(1,DEFAULT),(2,DEFAULT),(3,DEFAULT),(4,DEFAULT);

Insert into UsersResults values(5,DEFAULT),(6,DEFAULT),(7,DEFAULT),(8,DEFAULT),(9,DEFAULT),(10,DEFAULT);
