CREATE PROCEDURE [dbo].[spProductInsert]
	@Name nvarchar(128),
	@Description text,
	@CategoryId int,
	@BrandId int
AS
BEGIN
	set nocount on;

	INSERT INTO [dbo].[Product] ([Name], [Description], [CategoryId], [BrandId])
	VALUES (@Name, @Description, @CategoryId, @BrandId);
END
