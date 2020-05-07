CREATE PROCEDURE [dbo].[spVariantGetAll]
	@ProductId int = NULL,
	@MinPrice decimal(10,2) = NULL,
	@MaxPrice decimal(10,2) = NULL
AS
BEGIN
	set nocount on;

	IF @ProductId = NULL AND @MinPrice = NULL AND @MaxPrice = NULL
	BEGIN
		SELECT [Id], [ProductId], [BasePrice], [Tax], [InStock]
		FROM [dbo].[Variant];
	END
	ELSE
	BEGIN
		SELECT [Id], [ProductId], [BasePrice], [Tax], [InStock] FROM [dbo].[Variant]
		WHERE [ProductId] = ISNULL(@ProductId, [ProductId]) AND
			[BasePrice] >= ISNULL(@MinPrice, [BasePrice]) AND
			[BasePrice] <= ISNULL(@MaxPrice, [BasePrice]);
	END
END
