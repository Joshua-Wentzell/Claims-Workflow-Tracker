CREATE TABLE [dbo].[ClaimStatus]
(
	Id INT IDENTITY(1,1) NOT NULL,
	StatusName NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_ClaimStatus 
		PRIMARY KEY CLUSTERED(Id),

	CONSTRAINT UQ_ClaimStatus_StatusName
		UNIQUE (StatusName)
);
