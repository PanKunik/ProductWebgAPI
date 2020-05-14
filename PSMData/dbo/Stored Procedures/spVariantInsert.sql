CREATE PROCEDURE [dbo].[spVariantInsert]
	@ProductId int,
	@BasePrice decimal(10, 2),
	@Tax decimal (10, 2),
	@InStock int
AS
BEGIN
	set nocount on;

	INSERT INTO [dbo].[Variant] ([Product_ProductId], [BasePrice], [Tax], [InStock], [CreationDate], [ModificationDate])
	VALUES(@ProductId, @BasePrice, @Tax, @InStock, GETUTCDATE(), GETUTCDATE());
END
