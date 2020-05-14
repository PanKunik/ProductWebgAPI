CREATE PROCEDURE [dbo].[spProductDeleteById]
	@Id int
AS
BEGIN
	set nocount on;

	DELETE FROM [dbo].[Product] WHERE [ProductId] = @Id;
END
