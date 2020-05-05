CREATE PROCEDURE [dbo].[spProductUpdateById]
	@Id int,
	@Name nvarchar(128),
	@Description text,
	@CategoryId int,
	@BrandId int
AS
BEGIN
	set nocount on;

	UPDATE [dbo].[Product] SET [Name] = @Name, [Description] = @Description, [CategoryId] = @CategoryId, [BrandId] = @BrandId
	WHERE [Id] = @Id;
END