CREATE PROCEDURE [dbo].[spProductLookupByName]
	@Keyword nvarchar(100)
AS
BEGIN
	set nocount on;

	SELECT [Id], [Name], [Description], [CategoryId], [BrandId]
	FROM [dbo].[Product]
	WHERE [Name] LIKE '%' + @Keyword + '%' OR [Description] LIKE '%' + @Keyword + '%';
END
