CREATE PROCEDURE [dbo].[spCategoryDeleteById]
	@Id int
AS
BEGIN
	set nocount on;

	DELETE FROM [dbo].[Category] WHERE [Id] = @Id;
END
