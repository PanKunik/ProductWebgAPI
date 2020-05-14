CREATE PROCEDURE [dbo].[spProductGetAll]
	@CategoryId int = NULL,
	@BrandId int = NULL,
	@Name nvarchar(100) = NULL,
	@Page int = 1,
	@Limit tinyint = 100
AS
begin
	set nocount on;
	--IF @CategoryId = NULL AND
	--	@BrandId = NULL AND
	--	@Name = NULL
	--BEGIN
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
			[dbo].[Product].[ProductId] = [dbo].[Variant].[Product_ProductId];
	--END

	--ELSE
	--BEGIN
	--	SELECT [ProductId], [Name], [Description], [CategoryId], [BrandId] FROM [dbo].[Product]
	--	WHERE [CategoryId] = ISNULL(@CategoryId, [CategoryId]) AND
	--		[BrandId] = ISNULL(@BrandId, [BrandId]) AND
	--		[Name] LIKE ISNULL('%' + @Name + '%', [Name]);
	--END
end
