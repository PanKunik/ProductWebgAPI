CREATE PROCEDURE [dbo].[spProductLookup]
	@Id int
AS
begin
	set nocount on;

	SELECT
		[Product].[ProductId], 
		[Product].[Name], 
		[Product].[Description], 
		[Product].[CategoryId], 
		[Product].[BrandId], 
		[Variant].[VariantId], 
		[Variant].[BasePrice], 
		[Variant].[Tax], 
		[Variant].[InStock]
	FROM 
		[dbo].[Product]
	LEFT JOIN 
		[dbo].[Variant]
	ON 
		[dbo].[Product].[ProductId] = [dbo].[Variant].[Product_ProductId]
	WHERE 
		[Product].[ProductId] = @Id;
end