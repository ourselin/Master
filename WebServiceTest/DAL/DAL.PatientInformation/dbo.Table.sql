CREATE TABLE [dbo].[Patient] (
    [Id]     VARCHAR (50) NOT NULL,
    [dob]    DATE         NOT NULL,
    [gender] CHAR (1)     NOT NULL,
    [Firstname] VARCHAR(50) NOT NULL, 
    [Lastname] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

