CREATE PROCEDURE [dbo].[spBrandLookup]
	@Id int
AS
begin
	set nocount on;

	SELECT [BrandId], [Brand] FROM [dbo].[Brand] WHERE [BrandId] = @Id;
end
