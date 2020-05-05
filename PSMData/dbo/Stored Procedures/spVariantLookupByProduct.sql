CREATE PROCEDURE [dbo].[spVariantLookupByProduct]
	@ProductId int
AS
BEGIN
	set nocount on;

	SELECT [Id], [ProductId], [BasePrice], [Tax], [InStock] FROM [dbo].[Variant]
	WHERE [ProductID] = @ProductId;
END
