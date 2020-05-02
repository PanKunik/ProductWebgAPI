CREATE PROCEDURE [dbo].[spBrandInsert]
	@Brand nvarchar(64)
AS
Begin
	set nocount on;
	
	INSERT INTO [dbo].[Brand] ([Brand]) VALUES(@Brand)
End