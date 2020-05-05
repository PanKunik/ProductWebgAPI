CREATE PROCEDURE [dbo].[spVariantLookupByPrice]
	@MinPrice int,
	@MaxPrice int
AS
BEGIN
	set nocount on;

	SELECT [Id], [ProductId], [BasePrice], [Tax], [InStock] FROM [dbo].[Variant]
	WHERE ([BasePrice] + [Tax]) >= @MinPrice AND ([BasePrice] + [Tax]) <= @MaxPrice;
	
END
