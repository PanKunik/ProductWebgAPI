CREATE PROCEDURE [dbo].[spProductLookupByCategory]
	@Id int
AS
begin
	set nocount on;

	SELECT [Id], [Name], [Description], [CategoryId], [BrandId]
	FROM [dbo].[Product] WHERE CategoryId = @Id;
end