CREATE PROCEDURE [dbo].[spVariantGetAll]
AS
BEGIN
	set nocount on;

	SELECT * FROM [dbo].[Variant];
END
