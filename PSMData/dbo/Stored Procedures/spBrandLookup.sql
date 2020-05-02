CREATE PROCEDURE [dbo].[spBrandLookup]
	@Id int
AS
begin
	set nocount on;

	SELECT [Id], [Brand] FROM [dbo].[Brand] WHERE [Id] = @Id;
end
