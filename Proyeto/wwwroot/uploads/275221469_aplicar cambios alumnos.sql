USE EscuelaUTS
go

ALTER TABLE dbo.Alumno ADD
NumTel VARCHAR(20) NOT NULL,
CorreoElec VARCHAR(40) NOT NULL

INSERT INTO dbo.Alumno(Nombres, ApePa, ApeMa, Sexo, Calle, Colonia, NroCasa, Ciudad, Municipio, CP, CURP, RFC, NivEdu, FecNac, FecIng, IdGrupo1, NumTel, CorreoElec)
VALUES ('Cesar', 'Armenta', 'Hernandez', 'M', 'Morelos', 'Centro', 234, 'Obregon', 'Cajeme', 85000, 'CURP', 'RFC', 'uNIVERSIDAD', '2000-02-08', '2023-05-09', 1, '6441-34-45-44', 'cesar@gmail.com')

SELECT * FROM dbo.Alumno




