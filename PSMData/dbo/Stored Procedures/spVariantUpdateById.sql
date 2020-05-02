CREATE PROCEDURE [dbo].[spVariantUpdateById]
	@Id int,
	@ProductId int,
	@BasePrice decimal(10, 2),
	@Tax decimal(10, 2),
	@InStock int
AS
BEGIN
	set nocount on;

	UPDATE [dbo].[Variant] SET [ProductId] = @ProductId, [BasePrice] = @BasePrice, [Tax] = @Tax, [InStock] = @InStock, [ModificationDate] = GETUTCDATE()
	WHERE [Id] = @Id;
END
