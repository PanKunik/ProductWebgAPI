CREATE PROCEDURE [dbo].[spVariantGetAll]
AS
BEGIN
	set nocount on;

	SELECT [Id], [ProductId], [BasePrice], [Tax], [InStock]
	FROM [dbo].[Variant];
END
