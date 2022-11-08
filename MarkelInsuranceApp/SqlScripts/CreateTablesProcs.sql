

--Create a Database Called 'MarkelInsurance' and then run the script below to create/populate tables and procs.

USE [MarkelInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Claims](
	[UCR] [varchar](20) NULL,
	[CompanyId] [int] NULL,
	[ClaimDate] [datetime] NULL,
	[LossDate] [datetime] NULL,
	[AssuredName] [varchar](100) NULL,
	[IncurredLoss] [decimal](15, 2) NULL,
	[Closed] [bit] NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Claims]
	([UCR]
	,[CompanyId]
	,[ClaimDate]
	,[LossDate]
	,[AssuredName]
	,[IncurredLoss]
	,[Closed])
VALUES 
	('JAM1234',101,'01/01/2022','01/01/2022','SomeAssuredName1',100,1),
	('JAM5678',101,'02/02/2022','02/02/2022','SomeAssuredName2',500,0),
	('JAM90123',101,NULL,'03/03/2022','SomeAssuredName3',50,0),
	('BAR123',102,'03/03/2022','03/03/2022','SomeAssuredName4',200,0),
	('BAR456',102,'04/04/2022','04/04/2022','SomeAssuredName5',100,0),
	('STA123',103,'05/05/2022','05/05/2022','SomeAssuredName6',1000,0)
GO

CREATE TABLE [dbo].[ClaimType](
	[Id] [int] NULL,
	[Name] [varchar](20) NULL
) ON [PRIMARY]
GO

INSERT INTO 
	[dbo].[ClaimType]
           ([Id]
           ,[Name])
     VALUES
           (101,'THEFT')
GO


CREATE TABLE [dbo].[Company](
	[Id] [int] NULL,
	[Name] [varchar](200) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[Address3] [varchar](100) NULL,
	[Postcode] [varchar](20) NULL,
	[Country] [varchar](50) NULL,
	[Active] [bit] NULL,
	[InsuranceEndDate] [datetime] NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Company]
    ([Id]
    ,[Name]
    ,[Address1]
    ,[Address2]
    ,[Address3]
    ,[Postcode]
    ,[Country]
    ,[Active]
    ,[InsuranceEndDate])
VALUES
    (101,'Universal Exports','10 Downing Street','Westminster','London','E1 1ab','England',1,'31/01/2023'),
	(102,'Aperture Science','0451 HL Road','Borealis','California','90210','USA',0,'31/01/2024'),
	(103,'Acme Corp','3 Diagon Alley','Muggleford','London','E2 2RP','England',1,'31/01/2025')
GO



CREATE PROCEDURE [dbo].[Single_Claim_Get]
     @UCR varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	   [UCR]
      ,[CompanyId]
      ,[ClaimDate]
      ,[LossDate]
      ,[AssuredName]
      ,[IncurredLoss]
      ,[Closed]
	FROM 
		[dbo].[Claims] CLA
	WHERE
		CLA.UCR = @UCR
END
GO

CREATE PROCEDURE [dbo].[Single_Claim_Update]
	@UCR Varchar(20),
	@Closed bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @retVal int 

    UPDATE [dbo].[Claims]
	SET Closed = @Closed
	WHERE UCR = @UCR

	IF @@ROWCOUNT = 0
		set @retVal = -101
	ELSE
	    set @retVal = 0

	return @retVal
END
GO

CREATE PROCEDURE [dbo].[Company_GetById]
	@CompanyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
	   COM.[Id]
      ,COM.[Name]
      ,COM.[Address1]
      ,COM.[Address2]
      ,COM.[Address3]
      ,COM.[Postcode]
      ,COM.[Country]
      ,COM.[Active]
      ,COM.[InsuranceEndDate]
	FROM
		[dbo].[Company] COM
	WHERE
		COM.[Id] = @CompanyId
	    
END
GO

CREATE PROCEDURE [dbo].[All_Claims_GetByCompany]
	@CompanyId int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT
	   [UCR]
      ,[CompanyId]
      ,[ClaimDate]
      ,[LossDate]
      ,[AssuredName]
      ,[IncurredLoss]
      ,[Closed]
	FROM 
		[dbo].[Claims] CLA
	WHERE	
		CLA.CompanyId = @CompanyId
END
GO




