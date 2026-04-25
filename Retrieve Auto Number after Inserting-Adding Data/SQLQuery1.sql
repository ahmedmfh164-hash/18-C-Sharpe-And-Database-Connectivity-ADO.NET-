USE [ContactsDB]
GO

INSERT INTO [dbo].[Contacts]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Phone]
           ,[Address]
           ,[CountryID])
     VALUES
('Ali','Omar','A@a.com','030249','123 street',1);

select SCOPE_IDENTITY();

select *from Contacts;


