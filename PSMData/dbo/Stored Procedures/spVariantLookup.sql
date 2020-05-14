CREATE PROCEDURE [dbo].[spVariantLookup]
	@Id int
AS
Begin
	set nocount on;

	SELECT [VariantId], [Product_ProductId], [BasePrice], [Tax], [InStock]
	FROM [dbo].[Variant] WHERE [VariantId] = @Id;
End
