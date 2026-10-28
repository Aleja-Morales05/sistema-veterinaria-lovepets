CREATE TABLE [dbo].[Clientes] (
    [Id]        INT          NOT NULL,
    [Nombre]    VARCHAR (50) NULL,
    [Direccion] VARCHAR (50) NULL,
    [Telefono]  VARCHAR (50) NULL,
    [Correo]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Empleados] (
    [Id]         INT          NOT NULL,
    [Nombre]     VARCHAR (50) NULL,
    [Direccion ] VARCHAR (50) NULL,
    [Telefono]   VARCHAR (50) NULL,
    [Correo]     VARCHAR (50) NULL,
    [Cargo]      VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Tratamientos] (
    [Id]          INT           NOT NULL,
    [Nombre]      VARCHAR (50)  NULL,
    [Descripción] VARCHAR (250) NULL,
    [Cantidad]    INT           NULL,
    [Precio]      VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Mascotas] (
    [Id]          INT          NOT NULL,
    [Niup]        NUMERIC (18) NULL,
    [Nombre]      VARCHAR (50) NULL,
    [Raza]        VARCHAR (50) NULL,
    [Animal]      VARCHAR (50) NULL,
    [Cliente]     INT          NULL,
    [Genero]      VARCHAR (50) NULL,
    [Peso]        VARCHAR (50) NULL,
    [Tratamiento] INT          NULL,
    [Fecha]       DATE         NULL,
    [Veterinario] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Mascotas_ToTable] FOREIGN KEY ([Cliente]) REFERENCES [dbo].[Clientes] ([Id]),
    CONSTRAINT [FK_Mascotas_ToTable_1] FOREIGN KEY ([Tratamiento]) REFERENCES [dbo].[Tratamientos] ([Id]),
    CONSTRAINT [FK_Mascotas_ToTable_2] FOREIGN KEY ([Veterinario]) REFERENCES [dbo].[Empleados] ([Id])
);

