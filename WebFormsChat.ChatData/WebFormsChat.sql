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
