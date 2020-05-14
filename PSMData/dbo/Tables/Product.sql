CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NTEXT NOT NULL,
	[CategoryId] INT NOT NULL,
	[BrandId] INT NOT NULL,

	CONSTRAINT FK_Brand FOREIGN KEY (BrandId) REFERENCES Brand([BrandId]),
	CONSTRAINT FK_Category FOREIGN KEY (CategoryId) REFERENCES Category([CategoryId]),
)
