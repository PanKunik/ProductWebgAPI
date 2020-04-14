CREATE PROCEDURE [dbo].[spVariantLookup]
	@Id int
AS
Begin
	set nocount on;

	SELECT [Id], [ProductId], [BasePrice], [Tax], [InStock]
	FROM [dbo].[Variant] WHERE Id = @Id;
End
