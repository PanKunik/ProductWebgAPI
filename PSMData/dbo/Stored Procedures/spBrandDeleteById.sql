CREATE PROCEDURE [dbo].[spBrandDeleteById]
	@Id int
AS
Begin
	set nocount on;
	
	DELETE FROM [dbo].[Brand] WHERE [Id] = @Id;
End