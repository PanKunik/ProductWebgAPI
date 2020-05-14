CREATE PROCEDURE [dbo].[spVariantUpdateById]
	@Id int,
	@ProductId int,
	@BasePrice decimal(10, 2),
	@Tax decimal(10, 2),
	@InStock int
AS
BEGIN
	set nocount on;

	UPDATE [dbo].[Variant] SET [Product_ProductId] = @ProductId, [BasePrice] = @BasePrice, [Tax] = @Tax, [InStock] = @InStock, [ModificationDate] = GETUTCDATE()
	WHERE [VariantId] = @Id;
END
