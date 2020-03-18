
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2020 09:55:10
-- Generated from EDMX file: C:\Users\dghiuzan\source\repos\EFDesignFirst\ModelDesignFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestPerson];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_CustomerOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(10)  NOT NULL,
    [MiddleName] nvarchar(10)  NOT NULL,
    [LastName] nvarchar(10)  NOT NULL,
    [TelephoneNumber] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotalValue] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlbumName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Artists'
CREATE TABLE [dbo].[Artists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ArtistAlbum'
CREATE TABLE [dbo].[ArtistAlbum] (
    [Artists_Id] int  NOT NULL,
    [Albums_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Artists'
ALTER TABLE [dbo].[Artists]
ADD CONSTRAINT [PK_Artists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Artists_Id], [Albums_Id] in table 'ArtistAlbum'
ALTER TABLE [dbo].[ArtistAlbum]
ADD CONSTRAINT [PK_ArtistAlbum]
    PRIMARY KEY CLUSTERED ([Artists_Id], [Albums_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([CustomerId]);
GO

-- Creating foreign key on [Artists_Id] in table 'ArtistAlbum'
ALTER TABLE [dbo].[ArtistAlbum]
ADD CONSTRAINT [FK_ArtistAlbum_Artist]
    FOREIGN KEY ([Artists_Id])
    REFERENCES [dbo].[Artists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Albums_Id] in table 'ArtistAlbum'
ALTER TABLE [dbo].[ArtistAlbum]
ADD CONSTRAINT [FK_ArtistAlbum_Album]
    FOREIGN KEY ([Albums_Id])
    REFERENCES [dbo].[Albums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistAlbum_Album'
CREATE INDEX [IX_FK_ArtistAlbum_Album]
ON [dbo].[ArtistAlbum]
    ([Albums_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------