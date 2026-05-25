MERGE dbo.ClaimType AS Target
USING
(
    VALUES
        (N'AUTO',       N'Auto'),
        (N'HOME',       N'Home'),
        (N'LIFE',       N'Life'),
        (N'DISABILITY', N'Disability'),
        (N'OTHER',      N'Other')
) AS Source (TypeCode, TypeName)
ON Target.TypeCode = Source.TypeCode

WHEN MATCHED THEN
    UPDATE SET
        TypeName = Source.TypeName

WHEN NOT MATCHED BY TARGET THEN
    INSERT (TypeCode, TypeName)
    VALUES (Source.TypeCode, Source.TypeName);