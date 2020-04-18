CREATE PROCEDURE [dbo].[spProductLookupByBrand]
	@Id int
AS
begin
	set nocount on;

	SELECT [Id], [Name], [Description], [CategoryId], [BrandId]
	FROM [dbo].[Product] WHERE BrandId = @Id;
end
