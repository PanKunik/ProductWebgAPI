CREATE PROCEDURE [dbo].[spProductGetAll]
AS
begin
	set nocount on;

	SELECT [Id], [Name], [Description], [CategoryId], [BrandId]
	FROM [dbo].[Product];
end
