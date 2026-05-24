CREATE TABLE [dbo].[Claims]
(
	Id INT IDENTITY(1,1) NOT NULL,
	StatusId INT NOT NULL,
	TypeId INT NOT NULL,
	ReportedAt DATETIME2(0) NOT NULL 
		CONSTRAINT DF_Claims_ReportedAt DEFAULT SYSUTCDATETIME(),
	AssignedAdjusterId INT NULL,

	CONSTRAINT PK_Claims
		PRIMARY KEY CLUSTERED (Id),

	CONSTRAINT FK_Claims_ClaimStatus_StatusId 
		FOREIGN KEY (StatusId)
		REFERENCES ClaimStatus(Id),

	CONSTRAINT FK_Claims_ClaimType_TypeId 
		FOREIGN KEY (TypeId)
		REFERENCES ClaimType(Id),

	CONSTRAINT FK_Claims_ClaimAdjusters_AssignedId 
		FOREIGN KEY (AssignedAdjusterId)
		REFERENCES ClaimAdjusters(Id)
);
GO