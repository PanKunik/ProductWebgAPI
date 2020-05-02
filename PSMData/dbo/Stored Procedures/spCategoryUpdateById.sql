CREATE PROCEDURE [dbo].[spCategoryUpdateById]
	@Id int,
	@Category nvarchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Category] SET [Category] = @Category WHERE [Id] = @Id;
END