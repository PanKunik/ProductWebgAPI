CREATE PROCEDURE [dbo].[spCategoryInsert]
	@Category nvarchar(64)
AS
BEGIN
	set nocount on;

	INSERT INTO [dbo].[Category]([Category]) VALUES(@Category);
END
