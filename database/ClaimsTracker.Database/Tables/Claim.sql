CREATE TABLE [dbo].[Claim]
(
	Id INT IDENTITY(1,1) NOT NULL,
	StatusId INT NOT NULL,
	TypeId INT NOT NULL,
	ReportedAt DATETIME2(0) NOT NULL 
		CONSTRAINT DF_Claim_ReportedAt DEFAULT SYSUTCDATETIME(),
	AssignedAdjusterId INT NULL,

	CONSTRAINT PK_Claim
		PRIMARY KEY CLUSTERED (Id),

	CONSTRAINT FK_Claim_ClaimStatus_StatusId 
		FOREIGN KEY (StatusId)
		REFERENCES ClaimStatus (Id),

	CONSTRAINT FK_Claim_ClaimType_TypeId 
		FOREIGN KEY (TypeId)
		REFERENCES ClaimType (Id),

	CONSTRAINT FK_Claim_ClaimAdjuster_AssignedId 
		FOREIGN KEY (AssignedAdjusterId)
		REFERENCES ClaimAdjuster (Id)
);