﻿CREATE PROCEDURE [dbo].[spVariantDeleteById]
	@Id int
AS
BEGIN
	set nocount on;

	DELETE FROM [dbo].[Variant] WHERE [VariantId] = @Id;
END
