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

Insert into Questions values(1,'Co wolisz?'),(2,N'Na które zdjêcie pierw spojrza³eœ?');
Insert into Questions values(3,N'Na co masz ochotê?'),(4,'Gdzie jest gorzej?'),(5,'Gdzie jest lepiej?');
Insert into Options values(1,1,'book.jpg',N'Dobr¹ ksi¹¿kê'),
(2,1,'movie.jpg',N'Niez³y film'),
(3,2,'blonde.jpg','Blondooka'),
(4,2,'brunette.jpg','Brunetka');
Insert into Options values(5,3,'banana.jpg',N'Naj¿ó³tsze z naj¿ó³tszych'),
(6,3,'apple.jpg','Jabuszko'),
(7,4,'school.jpg',N'Strach siê baæ'),
(8,4,'motherinlaw.jpg',N'U mamusi (teœciowej)'),
(9,5,'sea.jpg',N'S³oneczna morska pla¿a'),
(10,5,'mountains.jpg',N'Najpiêkniejsze szczyty');

Insert into ResultTexts values(76, 100, N'Jesteœ tak przeciêtny, ¿e a¿ mi cie ¿al.'),
(0,25, N'Jesteœ tak odklejony od rzeczywistoœci, ¿e prawdopodobnie nied³ugo cie zamkn¹.'),
(26,50, N'Zdecydowanie ró¿nisz siê od reszty ale nie pal ju¿ wiêcej.'),
(51,75, N'Jesteœ powy¿ej œredniej przeciêtnoœci z t¹d o krok do nijakoœci, przemyœl to.');
Insert into UsersResults values(1,DEFAULT),(2,DEFAULT),(3,DEFAULT),(4,DEFAULT);

Insert into UsersResults values(5,DEFAULT),(6,DEFAULT),(7,DEFAULT),(8,DEFAULT),(9,DEFAULT),(10,DEFAULT);
