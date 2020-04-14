CREATE PROCEDURE [dbo].[spProductLookup]
	@Id int
AS
begin
	set nocount on;

	SELECT [Id], [Name], [Description], [CategoryId], [BrandId]
	FROM [dbo].[Product] WHERE Id = @Id;
end

