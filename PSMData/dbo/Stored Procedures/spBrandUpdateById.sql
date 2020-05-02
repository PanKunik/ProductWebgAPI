CREATE PROCEDURE [dbo].[spBrandUpdateById]
	@Id int,
	@Brand nvarchar(64)
AS
begin
	set nocount on;

	UPDATE [dbo].[Brand] SET [Brand] = @Brand WHERE [Id] = @Id
end
