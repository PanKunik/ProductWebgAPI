CREATE TABLE [dbo].[FeatureCombinationOfValue]
(
	[VariantId] INT NOT NULL,
	[FeatureCombinationId] INT NOT NULL,

	CONSTRAINT FK_Variant FOREIGN KEY (VariantId) REFERENCES Variant([VariantId]),
	CONSTRAINT FK_FeatureCombination FOREIGN KEY ([FeatureCombinationId]) REFERENCES FeatureCombination([FeatureCombinationId])
)
