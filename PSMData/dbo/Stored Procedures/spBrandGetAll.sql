CREATE PROCEDURE [dbo].[spBrandGetAll]

AS
BEGIN
	set nocount on;

	SELECT [BrandId], [Brand] FROM [dbo].[Brand];
END
