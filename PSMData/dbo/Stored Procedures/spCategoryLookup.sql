CREATE PROCEDURE [dbo].[spCategoryLookup]
	@Id int
AS
begin
	set nocount on;

	SELECT [CategoryId], [Category] FROM [dbo].[Category] WHERE [CategoryId] = @Id;
end