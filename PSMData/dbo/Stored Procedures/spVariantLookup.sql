CREATE PROCEDURE [dbo].[spVariantLookup]
	@Id int
AS
Begin
	set nocount on;

	SELECT * FROM [dbo].[Variant] WHERE Id = @Id;
End
