CREATE PROCEDURE [dbo].[spCategoryGetAll]
AS
BEGIN
	set nocount on;

	SELECT [CategoryId], [Category] FROM [dbo].[Category];
END
