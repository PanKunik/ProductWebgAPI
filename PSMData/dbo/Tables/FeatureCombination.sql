CREATE TABLE [dbo].[FeatureCombination]
(
	[FeatureCombinationId] INT NOT NULL PRIMARY KEY IDENTITY,
	[FeatureId] INT NOT NULL,
	[FeatureValueId] INT NOT NULL,

	CONSTRAINT FK_Feature FOREIGN KEY (FeatureId) REFERENCES Feature([FeatureId]),
	CONSTRAINT FK_FeatureValue FOREIGN KEY (FeatureValueId) REFERENCES FeatureValue([FeatureValueId])
)
