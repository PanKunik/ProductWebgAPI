CREATE TABLE [dbo].[Variant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductId] INT NOT NULL,
	[BasePrice] DECIMAL(10, 2) NOT NULL,
	[Tax] DECIMAL (10,2) NOT NULL,
	[InStock] INT NOT NULL,
	[CreationDate] DATETIME2(7) NOT NULL DEFAULT getutcdate(),
	[ModificationDate] DATETIME2(7) NOT NULL DEFAULT getutcdate()
)
