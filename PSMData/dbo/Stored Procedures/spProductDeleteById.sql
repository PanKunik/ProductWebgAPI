CREATE PROCEDURE [dbo].[spProductDeleteById]
	@Id int
AS
BEGIN
	set nocount on;

	DELETE FROM [dbo].[Product] WHERE [Id] = @Id;
END
