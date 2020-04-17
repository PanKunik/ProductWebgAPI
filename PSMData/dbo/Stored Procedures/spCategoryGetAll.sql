CREATE PROCEDURE [dbo].[spCategoryGetAll]
AS
BEGIN
	set nocount on;

	SELECT [Id], [Category] FROM [dbo].[Category];
END
