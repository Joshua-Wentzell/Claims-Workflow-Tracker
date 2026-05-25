MERGE dbo.ClaimStatus AS Target
USING
(
    VALUES
        (N'New'),
        (N'In Review'),
        (N'Approved'),
        (N'Rejected'),
        (N'Closed')
) AS Source (StatusName)
ON Target.StatusName = Source.StatusName

WHEN NOT MATCHED BY TARGET THEN
    INSERT (StatusName)
    VALUES (Source.StatusName);