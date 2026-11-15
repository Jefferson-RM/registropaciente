CREATE TABLE Pacientes
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Edad INT NOT NULL,
    Telefono VARCHAR(20),
    MotivoConsulta VARCHAR(250)
);
GO
