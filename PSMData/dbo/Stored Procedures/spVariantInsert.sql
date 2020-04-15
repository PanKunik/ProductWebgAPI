CREATE PROCEDURE [dbo].[spVariantInsert]
	@ProductId int,
	@BasePrice decimal(10, 2),
	@Tax decimal (10, 2),
	@InStock int
AS
BEGIN
	set nocount on;

	INSERT INTO [dbo].[Variant] ([ProductId], [BasePrice], [Tax], [InStock])
	VALUES(@ProductId, @BasePrice, @Tax, @InStock);
END
