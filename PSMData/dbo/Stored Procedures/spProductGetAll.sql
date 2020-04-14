CREATE PROCEDURE [dbo].[spProductGetAll]
AS
begin
	set nocount on;

	SELECT * FROM [dbo].[Product];
end
