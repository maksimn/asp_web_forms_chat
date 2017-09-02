CREATE DATABASE [WebFormsChat]
ON
( 
   NAME = 'WebFormsChat', 
   FILENAME = 'C:\Users\MSSQLSERVER\DataBases\WebFormsChat.mdf', 
   SIZE = 5120KB , MAXSIZE = 10240KB , FILEGROWTH = 1024KB 
)
LOG ON 
( 
   NAME = 'WebFormsChat_log', 
   FILENAME = 'C:\Users\MSSQLSERVER\DataBases\WebFormsChat_db.ldf', 
   SIZE = 1024KB , MAXSIZE = 10240KB , FILEGROWTH = 1024KB 
);

GO

USE WebFormsChat;

GO

CREATE TABLE Users (
   Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
   Name nvarchar(50) UNIQUE NOT NULL,
   PasswordHash nvarchar(1000) NOT NULL
); 

CREATE TABLE ChatMessages (
   Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
   UserName nvarchar(50) NOT NULL FOREIGN KEY REFERENCES Users(Name),
   Text nvarchar(500) NOT NULL
);

CREATE PROC AddUser
    @userName AS nvarchar(50),
	@passwordHash AS nvarchar(1000)
AS
BEGIN
    BEGIN TRY
        INSERT Users(Name, PasswordHash)
	    VALUES (@userName, @passwordHash);
	END TRY
	BEGIN CATCH
	    THROW;
	END CATCH
	RETURN;
END;

CREATE PROC GeyUserByName
    @userName AS nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;

	SELECT Id, Name, PasswordHash
	FROM Users
	WHERE Name = @userName;
	
	RETURN;
END;

CREATE PROC NumberOfUsers
    @numUsers AS INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

	SELECT @numUsers = COUNT(*)
	FROM Users;
	
	RETURN;
END;

CREATE PROC DeleteAllUsers
AS
BEGIN
    DELETE FROM Users;
    RETURN;
END;