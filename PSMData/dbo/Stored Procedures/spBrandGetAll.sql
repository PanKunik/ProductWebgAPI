CREATE PROCEDURE [dbo].[spBrandGetAll]

AS
BEGIN
	set nocount on;

	SELECT [Id], [Brand] FROM [dbo].[Brand];
END
