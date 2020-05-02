CREATE PROCEDURE [dbo].[spCategoryLookup]
	@Id int
AS
begin
	set nocount on;

	SELECT [Id], [Category] FROM [dbo].[Category] WHERE [Id] = @Id;
end