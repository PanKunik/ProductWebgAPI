CREATE TABLE [dbo].[Variant]
(
	[VariantId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Product_ProductId] INT NOT NULL,
	[BasePrice] DECIMAL(10, 2) NOT NULL,
	[Tax] DECIMAL (10,2) NOT NULL,
	[InStock] INT NOT NULL,
	[CreationDate] DATETIME2(7) NOT NULL DEFAULT getutcdate(),
	[ModificationDate] DATETIME2(7) NOT NULL DEFAULT getutcdate(),

	CONSTRAINT FK_Product FOREIGN KEY ([Product_ProductId]) REFERENCES Product([ProductId])
)
