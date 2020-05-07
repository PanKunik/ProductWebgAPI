CREATE PROCEDURE [dbo].[spProductGetAll]
	@CategoryId int = NULL,
	@BrandId int = NULL,
	@Name nvarchar(100) = NULL,
	@Page int = 1,
	@Limit tinyint = 100
AS
begin
	set nocount on;
	IF @CategoryId = NULL AND
		@BrandId = NULL AND
		@Name = NULL
	BEGIN
		SELECT [Id], [Name], [Description], [CategoryId], [BrandId]
		FROM [dbo].[Product];
	END

	ELSE
	BEGIN
		SELECT [Id], [Name], [Description], [CategoryId], [BrandId] FROM [dbo].[Product]
		WHERE [CategoryId] = ISNULL(@CategoryId, [CategoryId]) AND
			[BrandId] = ISNULL(@BrandId, [BrandId]) AND
			[Name] LIKE ISNULL('%' + @Name + '%', [Name]);
	END
end
