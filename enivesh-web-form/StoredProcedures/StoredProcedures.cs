#region UserID
/*
 Insert User In Master Table
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert User
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUser'))
BEGIN
    DROP PROCEDURE InsUser
END
GO

CREATE PROCEDURE InsUser
	-- Parameters
    @userId int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    INSERT INTO MasterTable
    (
		DateOfCreation
    )
    VALUES
    (
		GETDATE()
    )
    SET @userId = SCOPE_IDENTITY()
END
GO
 */
#endregion

#region PersonalInformation
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Personal Information
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetPersonalInformation'))
BEGIN
    DROP PROCEDURE GetPersonalInformation
END
GO

CREATE PROCEDURE GetPersonalInformation 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		IndividualCount,
		FirstName,
		LastName,
		DoB,
		Gender,
		Smoker,
		MaritalStatus,
		DateOfMarriage,
		DesiredRetirementAge,
		LifeExpectancy,
		HomeAddress,
		City,
		State,
		Zip,
		PhoneNumber,
		EmailAddress,
		Employer,
		Designation
		 
	FROM PersonalInformation WHERE UserID = @userID
END
GO
----------------
*** Insert Update ***

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Personal Information
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdPersonalInformation'))
BEGIN
    DROP PROCEDURE InsUpdPersonalInformation
END
GO

CREATE PROCEDURE InsUpdPersonalInformation 
	-- Parameters
    @userId int,
    @individualCount int,
    @firstName varchar(50),
	@lastName varchar(50),
    @dob date,
	@gender bit,
	@smoker bit,
	@maritalStatus bit,
	@dateOfMarriage date = NULL,
	@retirementAge int,
	@lifeExpectancy int,
	@homeAddress varchar(MAX),
	@city varchar(50),
	@state varchar(50),
	@zip varchar(50),
	@phoneNumber varchar(50),
	@emailAddress varchar(50),
	@employer varchar(50),
	@designation varchar(50),
	@operationType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO PersonalInformation
		(
            UserID,
            IndividualCount,
            FirstName,
            LastName,
            DoB,
            Gender,
            Smoker,
            MaritalStatus,
            DateOfMarriage,
            DesiredRetirementAge,
            LifeExpectancy,
            HomeAddress,
            City,
            State,
            Zip,
            PhoneNumber,
            EmailAddress,
            Employer,
            Designation
        )
        VALUES
        (
            @userId,
            @individualCount,
            @firstName,
            @lastName,
            @dob,
            @gender,
            @smoker,
            @maritalStatus,
            @dateOfMarriage,
            @retirementAge,
            @lifeExpectancy,
            @homeAddress,
            @city,
            @state,
			@zip,
			@phoneNumber,
			@emailAddress,
			@employer,
			@designation
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE PersonalInformation SET
		
			FirstName = @firstName,
			LastName = @lastName,
			DoB = @dob,
			Gender = @gender,
			Smoker = @smoker,
			MaritalStatus = @maritalStatus,
			DateOfMarriage = @dateOfMarriage,
			DesiredRetirementAge = @retirementAge,
			LifeExpectancy = @lifeExpectancy,
			HomeAddress = @homeAddress,
			City = @city,
			State = @state,
			Zip = @zip,
			PhoneNumber = @phoneNumber,
			EmailAddress = @emailAddress,
			Employer = @employer,
			Designation = @designation
        
		WHERE (UserID = @userId AND IndividualCount = @individualCount)
    END
END
GO
 */
#endregion

#region LiquidAssets
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Liquid Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetAssetsLiquid'))
BEGIN
   DROP PROCEDURE GetAssetsLiquid
END
GO

CREATE PROCEDURE GetAssetsLiquid 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       BankAccountSelf,
       BankAccountSpouse,
       BankAccountRemarks,
       BankFdSelf,
       BankFdSpouse,
       BankFdRemarks

   FROM AssetsLiquid WHERE UserID = @userID
END
GO
--------------------
Insert-Update Liquid Assets
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert - Update Stored Procedure For Liquid Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdAssetsLiquid'))
BEGIN
    DROP PROCEDURE InsUpdAssetsLiquid
END
GO

CREATE PROCEDURE InsUpdAssetsLiquid 
	-- Parameters
    @userId int,
    @bankAccountSelf money,
    @bankAccountSpouse money,
    @bankAccountRemarks varchar(MAX),
    @cashBankFdSelf money,
    @cashBankFdSpouse money,
    @cashBankFdRemarks varchar(MAX),
	@operationType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO AssetsLiquid
		(
            UserID,
            BankAccountSelf,
            BankAccountSpouse,
            BankAccountRemarks,
            BankFdSelf,
            BankFdSpouse,
            BankFdRemarks
        )
        VALUES
        (
            @userId,
            @bankAccountSelf,
            @bankAccountSpouse,
            @bankAccountRemarks,
            @cashBankFdSelf,
            @cashBankFdSpouse,
            @cashBankFdRemarks
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE AssetsLiquid SET
        
			BankAccountSelf = @bankAccountSelf,
			BankAccountSpouse = @bankAccountSpouse,
			BankAccountRemarks = @bankAccountRemarks,
            BankFdSelf = @cashBankFdSelf,
            BankFdSpouse = @cashBankFdSpouse,
            BankFdRemarks = @cashBankFdRemarks
        
		WHERE (UserID = @userId)
    END
END
GO 
*/
#endregion

#region InvestmentAssets
/*
 Get Investment Assets
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Investment Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetAssetsInvestment'))
BEGIN
    DROP PROCEDURE GetAssetsInvestment
END
GO

CREATE PROCEDURE GetAssetsInvestment 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		MutualFundsSelf,
		MutualFundsSpouse,
		MutualFundsRemarks,
		EquitySharesSelf,
		EquitySharesSpouse,
		EquitySharesRemarks,
		OtherInvestmentSelf,
		OtherInvestmentSpouse,
		OtherInvestmentRemarks,
		OtherLiquidAssetsSelf,
		OtherLiquidAssetsSpouse,
		OtherLiquidAssetsRemarks

	FROM AssetsInvestments WHERE UserID = @userID
END
GO
-------------
Insert-Update Stored procedure for Investment Assets

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert - Update Stored Procedure For Investment Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdAssetsInvestment'))
BEGIN
    DROP PROCEDURE InsUpdAssetsInvestment
END
GO

CREATE PROCEDURE InsUpdAssetsInvestment 
	-- Parameters
    @userId int,
    @mutualFundSelf money,
    @mutualFundSpouse money,
    @mutualFundRemarks varchar(MAX),
    @equitySharesSelf money,
    @equitySharesSpouse money,
    @equitySharesRemarks varchar(MAX),
    @otherInvestmentSelf money,
    @otherInvestmentSpouse money,
    @otherInvestmentRemarks varchar(MAX),
    @otherLiquidAssetsSelf money,
    @otherLiquidAssetsSpouse money,
    @otherLiquidAssetsRemarks varchar(MAX),
	@operationType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO AssetsInvestments
		(
            UserID,
            MutualFundsSelf,
            MutualFundsSpouse,
            MutualFundsRemarks,
            EquitySharesSelf,
            EquitySharesSpouse,
            EquitySharesRemarks,
            OtherInvestmentSelf,
            OtherInvestmentSpouse,
            OtherInvestmentRemarks,
            OtherLiquidAssetsSelf,
            OtherLiquidAssetsSpouse,
            OtherLiquidAssetsRemarks
        )
        VALUES
        (
            @userId,
            @mutualFundSelf,
            @mutualFundSpouse,
            @mutualFundRemarks,
            @equitySharesSelf,
            @equitySharesSpouse,
            @equitySharesRemarks,
            @otherInvestmentSelf,
            @otherInvestmentSpouse,
            @otherInvestmentRemarks,
            @otherLiquidAssetsSelf,
            @otherInvestmentSpouse,
            @otherLiquidAssetsRemarks
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE AssetsInvestments SET
        
			MutualFundsSelf = @mutualFundSelf,
            MutualFundsSpouse = @mutualFundSpouse,
            MutualFundsRemarks = @mutualFundRemarks,
            EquitySharesSelf = @equitySharesSelf,
            EquitySharesSpouse = @equitySharesSpouse,
            EquitySharesRemarks = @equitySharesRemarks,
            OtherInvestmentSelf = @otherInvestmentSelf,
            OtherInvestmentSpouse = @otherInvestmentSpouse,
            OtherInvestmentRemarks = @otherInvestmentRemarks,
            OtherLiquidAssetsSelf = @otherLiquidAssetsSelf,
            OtherLiquidAssetsSpouse = @otherLiquidAssetsSpouse,
            OtherLiquidAssetsRemarks = @otherInvestmentRemarks
        
		WHERE (UserID = @userId)
    END
END
GO

 */
#endregion

#region FixedAssets
/*
 Get Fixed Assets
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Fixed Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetAssetsFixed'))
BEGIN
    DROP PROCEDURE GetAssetsFixed
END
GO

CREATE PROCEDURE GetAssetsFixed 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		PrincipalResidenceSelf,
		PrincipalResidenceSpouse,
		PrincipalResidenceRemarks,
		OtherPropertySelf,
		OtherPropertySpouse,
		OtherPropertyRemarks,
		CarSelf,
		CarSpouse,
		CarRemarks,
		FurnishingContentsSelf,
		FurnishingContentsSpouse,
		FurnishingContentsRemarks,
		JewellarySelf,
		JewellarySpouse,
		JewellaryRemarks,
		OtherFixedAssetsSelf,
		OtherFixedAssetsSpouse,
		OtherFixedAssetsRemarks

	FROM AssetsFixed WHERE UserID = @userID
END
GO
-----------
Insert - Update Stored Procedure for Fixed Assets

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert - Update Stored Procedure For Fixed Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdAssetsFixed'))
BEGIN
    DROP PROCEDURE InsUpdAssetsFixed
END
GO

CREATE PROCEDURE InsUpdAssetsFixed 
	-- Parameters
    @userId int,
    @principalResidenceSelf money,
    @principalResidenceSpouse money,
    @principalResidenceRemarks varchar(MAX),
    @otherPropertySelf money,
    @otherPropertySpouse money,
    @otherPropertyRemarks varchar(MAX),
    @carSelf money,
    @carSpouse money,
    @carRemarks varchar(MAX),
    @furnishingContentsSelf money,
    @furnishingContentsSpouse money,
    @furnishingContentsRemarks varchar(MAX),
    @jewellarySelf money,
    @jewellarySpouse money,
    @jewellaryRemarks varchar(MAX),
    @otherFixedAssetsSelf money,
    @otherFixedAssetsSpouse money,
    @otherFixedAssetsRemarks varchar(MAX),
	@operationType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO AssetsFixed
		(
            UserID,
            PrincipalResidenceSelf,
            PrincipalResidenceSpouse,
            PrincipalResidenceRemarks,
            OtherPropertySelf,
            OtherPropertySpouse,
            OtherPropertyRemarks,
            CarSelf,
            CarSpouse,
            CarRemarks,
            FurnishingContentsSelf,
            FurnishingContentsSpouse,
            FurnishingContentsRemarks,
            JewellarySelf,
            JewellarySpouse,
            JewellaryRemarks,
            OtherFixedAssetsSelf,
            OtherFixedAssetsSpouse,
            OtherFixedAssetsRemarks
        )
        VALUES
        (
            @userId,
            @principalResidenceSelf,
            @principalResidenceSpouse,
            @principalResidenceRemarks,
            @otherPropertySelf,
            @otherPropertySpouse,
            @otherPropertyRemarks,
            @carSelf,
            @carSpouse,
            @carRemarks,
            @furnishingContentsSelf,
            @furnishingContentsSpouse,
            @furnishingContentsRemarks,
            @jewellarySelf,
            @jewellarySpouse,
            @jewellaryRemarks,
            @otherFixedAssetsSelf,
            @otherFixedAssetsSpouse,
            @otherFixedAssetsRemarks
            
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE AssetsFixed SET
        
            PrincipalResidenceSelf = @principalResidenceSelf,
            PrincipalResidenceSpouse = @principalResidenceSpouse,
            PrincipalResidenceRemarks = @principalResidenceRemarks,
            OtherPropertySelf = @otherPropertySelf,
            OtherPropertySpouse = @otherPropertySpouse,
            OtherPropertyRemarks = @otherPropertyRemarks,
            CarSelf = @carSelf,
            CarSpouse = @carSpouse,
            CarRemarks = @carRemarks,
            FurnishingContentsSelf = @furnishingContentsSelf,
            FurnishingContentsSpouse = @furnishingContentsSpouse,
            FurnishingContentsRemarks = @furnishingContentsRemarks,
            JewellarySelf = @jewellarySelf,
            JewellarySpouse = @jewellarySpouse,
            JewellaryRemarks = @jewellaryRemarks,
            OtherFixedAssetsSelf = @otherFixedAssetsSelf,
            OtherFixedAssetsSpouse = @otherFixedAssetsSpouse,
            OtherFixedAssetsRemarks = @otherFixedAssetsRemarks
        
		WHERE (UserID = @userId)
    END
END
GO
 */
#endregion

#region OtherAssets
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Other Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetOtherAssets'))
BEGIN
   DROP PROCEDURE GetOtherAssets
END
GO

CREATE PROCEDURE GetOtherAssets 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       LoansGivenSelf,
       LoansGivenSpouse,
       LoansGivenRemarks,
       OtherInvestmentsSelf,
       OtherInvestmentsSpouse,
       OtherInvestmentsRemarks,
       NotLiquidSelf,
       NotLiquidSpouse,
       NotLiquidRemarks,
       AnyOtherAssetsSelf,
       AnyOtherAssetsSpouse,
       AnyOtherAssetsRemarks

   FROM AssetsOther WHERE UserID = @userID
END
GO
------------
Insert - Update Stored Procedure for Other Assets
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert - Update Stored Procedure For Other Assets
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdAssetsOther'))
BEGIN
    DROP PROCEDURE InsUpdAssetsOther
END
GO

CREATE PROCEDURE InsUpdAssetsOther 
	-- Parameters
    @userId int,
    @loansGivenSelf money,
    @loansGivenSpouse money,
    @loansGivenRemarks varchar(MAX),
    @otherInvestmentsSelf money,
    @otherInvestmentsSpouse money,
    @otherInvestmentsRemarks varchar(MAX),
    @notLiquidSelf money,
    @notLiquidSpouse money,
    @notLiquidRemarks varchar(MAX),
    @anyOtherAssetsSelf money,
    @anyOtherAssetsSpouse money,
    @anyOtherAssetsRemarks varchar(MAX),
	@operationType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO AssetsOther
		(
            UserID,
            LoansGivenSelf,
            LoansGivenSpouse,
            LoansGivenRemarks,
            OtherInvestmentsSelf,
            OtherInvestmentsSpouse,
            OtherInvestmentsRemarks,
            NotLiquidSelf,
            NotLiquidSpouse,
            NotLiquidRemarks,
            AnyOtherAssetsSelf,
            AnyOtherAssetsSpouse,
            AnyOtherAssetsRemarks
        )
        VALUES
        (
            @userId,
            @loansGivenSelf,
			@loansGivenSpouse,
			@loansGivenRemarks,
			@otherInvestmentsSelf,
			@otherInvestmentsSpouse,
			@otherInvestmentsRemarks,
			@notLiquidSelf,
			@notLiquidSpouse,
			@notLiquidRemarks,
			@anyOtherAssetsSelf,
			@anyOtherAssetsSpouse,
			@anyOtherAssetsRemarks
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE AssetsOther SET
        
            LoansGivenSelf = @loansGivenSelf,
            LoansGivenSpouse = @loansGivenSpouse,
            LoansGivenRemarks = @loansGivenRemarks,
            OtherInvestmentsSelf = @otherInvestmentsSelf,
            OtherInvestmentsSpouse = @otherInvestmentsSpouse,
            OtherInvestmentsRemarks = @otherInvestmentsRemarks,
            NotLiquidSelf = @notLiquidSelf,
            NotLiquidSpouse = @notLiquidSpouse,
            NotLiquidRemarks = @notLiquidRemarks,
            AnyOtherAssetsSelf = @anyOtherAssetsSelf,
            AnyOtherAssetsSpouse = @anyOtherAssetsSpouse,
            AnyOtherAssetsRemarks = @anyOtherAssetsRemarks
        
		WHERE (UserID = @userId)
    END
END
GO 
*/
#endregion

#region Liabilities
/*
Select Query
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Liabilities
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetLiabilities'))
BEGIN
    DROP PROCEDURE GetLiabilities
END
GO

CREATE PROCEDURE GetLiabilities 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		MortgageSelf,
		MortgageSpouse,
		MortgageInterestRate,
		MortgageMonthlyPayment,
		MortgageTerm,
		CarLoansSelf,
		CarLoansSpouse,
		CarLoansInterestRate,
		CarLoansMonthlyPayment,
		CarLoansTerm,
		CreditorsSelf,
		CreditorsSpouse,
		CreditorsInterestRate,
		CreditorsMonthlyPayment,
		CreditorsTerm,
		InvestmentLoansSelf,
		InvestmentLoansSpouse,
		InvestmentLoansInterestRate,
		InvestmentLoansMonthlyPayment,
		InvestmentLoansTerm,
		PrivateLoansSelf,
		PrivateLoansSpouse,
		PrivateLoansInterestRate,
		PrivateLoansMonthlyPayment,
		PrivateLoansTerm,
		OtherSelf,
		OtherSpouse,
		OtherInterestRate,
		OtherMonthlyPayment,
		OtherTerm
		 
	FROM Liabilities WHERE UserID = @userID
END
GO
---------------
Insert - Update Stored Procedure for Liabilities
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Liabilities
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdLiabilities'))
BEGIN
    DROP PROCEDURE InsUpdLiabilities
END
GO

CREATE PROCEDURE InsUpdLiabilities 
	-- Parameters
    @userID int,
    @mortgageHomeSelf money,
    @mortgageHomeSpouse money,
    @mortgageHomeInterestRate float,
    @mortgageHomeMonthlyPayment money,
    @mortgageHomeTerm float,
    @carSelf money,
    @carSpouse money,
    @carInterestRate float,
    @carMonthlyPayment money,
    @carTerm float,
    @creditorsSelf money,
    @creditorsSpouse money,
    @creditorsInterestRate float,
    @creditorsMonthlyPayment money,
    @creditorsTerm float,
    @investmentSelf money,
    @investmentSpouse money,
    @investmentInterestRate float,
    @investmentMonthlyPayment money,
    @investmentTerm float,
    @privateSelf money,
    @privateSpouse money,
    @privateInterestRate float,
    @privateMonthlyPayment money,
    @privateTerm float,
    @otherSelf money,
    @otherSpouse money,
    @otherInterestRate float,
    @otherMonthlyPayment money,
    @otherTerm float,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO Liabilities
		(
			UserID,
            MortgageSelf,
            MortgageSpouse,
            MortgageInterestRate,
            MortgageMonthlyPayment,
            MortgageTerm,
            CarLoansSelf,
            CarLoansSpouse,
            CarLoansInterestRate,
            CarLoansMonthlyPayment,
            CarLoansTerm,
            CreditorsSelf,
            CreditorsSpouse,
            CreditorsInterestRate,
            CreditorsMonthlyPayment,
            CreditorsTerm,
            InvestmentLoansSelf,
            InvestmentLoansSpouse,
            InvestmentLoansInterestRate,
            InvestmentLoansMonthlyPayment,
            InvestmentLoansTerm,
            PrivateLoansSelf,
            PrivateLoansSpouse,
            PrivateLoansInterestRate,
            PrivateLoansMonthlyPayment,
            PrivateLoansTerm,
            OtherSelf,
            OtherSpouse,
            OtherInterestRate,
            OtherMonthlyPayment,
            OtherTerm
        )
        VALUES
        (
            @userID,
            @mortgageHomeSelf,
			@mortgageHomeSpouse,
			@mortgageHomeInterestRate,
			@mortgageHomeMonthlyPayment,
			@mortgageHomeTerm,
			@carSelf,
			@carSpouse,
			@carInterestRate,
			@carMonthlyPayment,
			@carTerm,
			@creditorsSelf,
			@creditorsSpouse,
			@creditorsInterestRate,
			@creditorsMonthlyPayment,
			@creditorsTerm,
			@investmentSelf,
			@investmentSpouse,
			@investmentInterestRate,
			@investmentMonthlyPayment,
			@investmentTerm,
			@privateSelf,
			@privateSpouse,
			@privateInterestRate,
			@privateMonthlyPayment,
			@privateTerm,
			@otherSelf,
			@otherSpouse,
			@otherInterestRate,
			@otherMonthlyPayment,
			@otherTerm
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE Liabilities SET
		
			MortgageSelf = @mortgageHomeSelf,
            MortgageSpouse = @mortgageHomeSpouse,
            MortgageInterestRate = @mortgageHomeInterestRate,
            MortgageMonthlyPayment = @mortgageHomeMonthlyPayment,
            MortgageTerm = @mortgageHomeTerm,
            CarLoansSelf = @carSelf,
            CarLoansSpouse = @carSpouse,
            CarLoansInterestRate = @carInterestRate,
            CarLoansMonthlyPayment = @carMonthlyPayment,
            CarLoansTerm = @carTerm,
            CreditorsSelf = @creditorsSelf,
            CreditorsSpouse = @creditorsSpouse,
            CreditorsInterestRate = @creditorsInterestRate,
            CreditorsMonthlyPayment = @creditorsMonthlyPayment,
            CreditorsTerm = @creditorsTerm,
            InvestmentLoansSelf = @investmentSelf,
            InvestmentLoansSpouse = @investmentSpouse,
            InvestmentLoansInterestRate = @investmentInterestRate,
            InvestmentLoansMonthlyPayment = @investmentMonthlyPayment,
            InvestmentLoansTerm = @investmentTerm,
            PrivateLoansSelf = @privateSelf,
            PrivateLoansSpouse = @privateSpouse,
            PrivateLoansInterestRate = @privateInterestRate,
            PrivateLoansMonthlyPayment = @privateMonthlyPayment,
            PrivateLoansTerm = @privateTerm,
            OtherSelf = @otherSelf,
            OtherSpouse = @otherSpouse,
            OtherInterestRate = @otherInterestRate,
            OtherMonthlyPayment = @otherMonthlyPayment,
            OtherTerm = @otherTerm
        
		WHERE (UserID = @userId)
    END
END
GO
 */
#endregion

#region LifeInsurance
/*
Select Procedure
--------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Life Insurance
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetLifeInsurance'))
BEGIN
    DROP PROCEDURE GetLifeInsurance
END
GO

CREATE PROCEDURE GetLifeInsurance 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		PolicyNumber,
		Term,
		InsuranceCompany,
		Insured,
		StartDate,
		AnnualPremium,
		SumAssured,
		DeathBenefit
		 
	FROM LifeInsurance WHERE UserID = @userID
END
GO
------------------
Insert - Update Stored Procedure for Life Insurance
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Life Insurance
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdLifeInsurance'))
BEGIN
    DROP PROCEDURE InsUpdLifeInsurance
END
GO

CREATE PROCEDURE InsUpdLifeInsurance 
	-- Parameters
    @userID int,
    @policyNumber int,
    @term float,
    @insuranceCompany varchar(MAX),
    @insured money,
    @startDate date,
    @annualPremium money,
    @sumAssured money,
    @deathBenefit money,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO LifeInsurance
		(
			UserID,
            PolicyNumber,
            Term,
            InsuranceCompany,
            Insured,
            StartDate,
            AnnualPremium,
            SumAssured,
            DeathBenefit
        )
        VALUES
        (
            @userID,
            @policyNumber,
			@term,
			@insuranceCompany,
			@insured,
			@startDate,
			@annualPremium,
			@sumAssured,
			@deathBenefit
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE LifeInsurance SET
		
			Term = @term,
            InsuranceCompany = @insuranceCompany,
            Insured = @insured,
            StartDate = @startDate,
            AnnualPremium = @annualPremium,
            SumAssured = @sumAssured,
            DeathBenefit = @deathBenefit
        
		WHERE (UserID = @userId AND PolicyNumber = @policyNumber)
    END
END
GO
 */
#endregion

#region MediClaim
/*
 Select Procedure
 ----------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Mediclaim
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetMediclaim'))
BEGIN
   DROP PROCEDURE GetMediclaim
END
GO

CREATE PROCEDURE GetMediclaim 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       PolicyCount,
       Floater,
       InsuranceCompany,
       StartDate,
       AnnualPremium,
       SumAssured,
       MembersCovered

   FROM MediClaim WHERE UserID = @userID
END
GO
-------------------
Insert - Update procedure for Mediclaim
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Mediclaim
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdMediclaim'))
BEGIN
    DROP PROCEDURE InsUpdMediclaim
END
GO

CREATE PROCEDURE InsUpdMediclaim 
	-- Parameters
    @userID int,
    @policyCount int,
    @floater varchar(MAX),
    @insuranceCompany varchar(MAX),
    @startDate date,
    @annualPremium money,
    @sumAssured money,
    @membersCovered int,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO MediClaim
		(
			UserID,
            PolicyCount,
            Floater,
            InsuranceCompany,
            StartDate,
            AnnualPremium,
            SumAssured,
            MembersCovered
        )
        VALUES
        (
            @userID,
            @policyCount,
			@floater,
			@insuranceCompany,
			@startDate,
			@annualPremium,
			@sumAssured,
			@membersCovered
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE MediClaim SET
		
			Floater = @floater,
            InsuranceCompany = @insuranceCompany,
            StartDate = @startDate,
            AnnualPremium = @annualPremium,
            SumAssured = @sumAssured,
            MembersCovered = @membersCovered
        
		WHERE (UserID = @userId AND PolicyCount = @policyCount)
    END
END
GO
 */
#endregion

#region ChildrenCollege
/*
 Select Procedure
 ---------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Children & College
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetChildrenCollege'))
BEGIN
   DROP PROCEDURE GetChildrenCollege
END
GO

CREATE PROCEDURE GetChildrenCollege 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       ChildrenCount,
       Name,
       DoB,
       YearOfCollege,
       CourseFees

   FROM ChildrenCollegePlanning WHERE UserID = @userID
END
GO
------------------
Insert - Update Stored Procedure for Children & College
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Children & College
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdChildrenCollege'))
BEGIN
    DROP PROCEDURE InsUpdChildrenCollege
END
GO

CREATE PROCEDURE InsUpdChildrenCollege
	-- Parameters
    @userID int,
    @childrenCount int,
    @name varchar,
    @dob date,
    @yearOfCollege int,
    @courseFees money,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO ChildrenCollegePlanning
		(
			UserID,
            ChildrenCount,
            Name,
            DoB,
            YearOfCollege,
            CourseFees
        )
        VALUES
        (
            @userID,
            @childrenCount,
            @name,
            @dob,
            @yearOfCollege,
            @courseFees
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE ChildrenCollegePlanning SET
		
			Name = @name,
            DoB = @dob,
            YearOfCollege = @yearOfCollege,
            CourseFees = @courseFees
        
		WHERE (UserID = @userId AND ChildrenCount = @childrenCount)
    END
END
GO
 */
#endregion

#region PensionIncome
/*
 Select Procedure
 -------------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Pension Income
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetPensionIncome'))
BEGIN
   DROP PROCEDURE GetPensionIncome
END
GO

CREATE PROCEDURE GetPensionIncome 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       PensionCount,
       Name,
       CompanyBenefit,
       MonthlyBenefit,
       CostOfLiving,
       LumpSum

   FROM PensionIncome WHERE UserID = @userID
END
GO
-------------------
Insert - Update Stored Procedure for Pension Income
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Pension Income
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdPensionIncome'))
BEGIN
    DROP PROCEDURE InsUpdPensionIncome
END
GO

CREATE PROCEDURE InsUpdPensionIncome
	-- Parameters
    @userID int,
    @pensionCount int,
    @name varchar,
    @companyBenefit money,
    @monthlyBenefit money,
    @costOfLiving money,
    @lumpSum money,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO PensionIncome
		(
			UserID,
            PensionCount,
			Name,
			CompanyBenefit,
			MonthlyBenefit,
			CostOfLiving,
			LumpSum
        )
        VALUES
        (
            @userID,
            @pensionCount,
            @name,
            @companyBenefit,
            @monthlyBenefit,
            @costOfLiving,
            @lumpSum
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE PensionIncome SET
		
			Name = @name,
			CompanyBenefit = @companyBenefit,
			MonthlyBenefit = @monthlyBenefit,
			CostOfLiving = @costOfLiving,
			LumpSum = @lumpSum
        
		WHERE (UserID = @userId AND LumpSum = @lumpSum)
    END
END
GO
 */
#endregion

#region OtherIncome
/*
Select Procedure
---------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Other Income
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetOtherIncome'))
BEGIN
   DROP PROCEDURE GetOtherIncome
END
GO

CREATE PROCEDURE GetOtherIncome 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       OtherIncomeCount,
       Name,
       IncomeDescription,
       AnnualAmount,
       AnnualIncDec,
       BeginningAge,
       EndingAge

   FROM OtherIncome WHERE UserID = @userID
END
GO 
------------------------
Insert - Update Stored Procedure for Other Income
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Other Income
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdOtherIncome'))
BEGIN
    DROP PROCEDURE InsUpdOtherIncome
END
GO

CREATE PROCEDURE InsUpdOtherIncome
	-- Parameters
    @userID int,
    @otherIncomeCount int,
    @name varchar,
    @incomeDescription varchar,
    @annualAmount money,
    @annualIncDec float,
    @beginningAge int,
    @endingAge int,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO OtherIncome
		(
			UserID,
            OtherIncomeCount,
            Name,
            IncomeDescription,
            AnnualAmount,
            AnnualIncDec,
            BeginningAge,
            EndingAge
        )
        VALUES
        (
            @userID,
            @otherIncomeCount,
			@name,
			@incomeDescription,
			@annualAmount,
			@annualIncDec,
			@beginningAge,
			@endingAge
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE OtherIncome SET
		
			Name = @name,
            IncomeDescription = @incomeDescription,
            AnnualAmount = @annualAmount,
            AnnualIncDec = @annualIncDec,
            BeginningAge = @beginningAge,
            EndingAge = @endingAge
        
		WHERE (UserID = @userId AND OtherIncomeCount = @otherIncomeCount)
    END
END
GO
 */
#endregion

#region RentalRealEstate
/*
 Select Procedure
 -------------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Rental Real Estate
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetRentalRealEstate'))
BEGIN
   DROP PROCEDURE GetRentalRealEstate
END
GO

CREATE PROCEDURE GetRentalRealEstate 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       PropertyNumber,
       PropertyName,
       CityState,
       PurchasePrice,
       CurrentMarketValue,
       AnnualRent

   FROM RentalRealEstate WHERE UserID = @userID
END
GO
--------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Rental Real Estate
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdRentalRealEstate'))
BEGIN
    DROP PROCEDURE InsUpdRentalRealEstate
END
GO

CREATE PROCEDURE InsUpdRentalRealEstate
	-- Parameters
    @userID int,
    @propertyNumber int,
    @propertyName varchar,
    @cityState varchar,
    @purchasePrice money,
    @currentMarketValue money,
    @annualRent money,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO RentalRealEstate
		(
			UserID,
            PropertyNumber,
            PropertyName,
            CityState,
            PurchasePrice,
            CurrentMarketValue,
            AnnualRent
        )
        VALUES
        (
            @userID,
            @propertyNumber,
			@propertyName,
			@cityState,
			@purchasePrice,
			@currentMarketValue,
			@annualRent
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE RentalRealEstate SET
		
			PropertyName = @propertyName,
            CityState = @cityState,
            PurchasePrice = @purchasePrice,
            CurrentMarketValue = @currentMarketValue,
            AnnualRent = @annualRent
        
		WHERE (UserID = @userId AND PropertyNumber = @propertyNumber)
    END
END
GO
 */
#endregion

#region PersonalExpense
/*
 Select Procedure
 --------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Personal Expense
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetPersonalExpense'))
BEGIN
   DROP PROCEDURE GetPersonalExpense
END
GO

CREATE PROCEDURE GetPersonalExpense 
   -- Parameters
   @userID int
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   SELECT 
       Rent,
       Groceries,
       Eating,
       Utilities,
       Phone,
       Gas,
       AutomobileExpense,
       Recreation,
       DayCare,
       Gifts,
       DomesticHelp,
       Clothing,
       HomeMaintenance,
       HomeFurnishings,
       ChildSupport,
       Alimony,
       Entertainment,
       Vacations,
       Hobbies,
       Gym,
       Subscriptions,
       PetExpense,
       BooksMovies,
       CableTV,
       Internet,
       Haircuts,
       Miscelleneous

   FROM PersonalExpense WHERE UserID = @userID
END
---------------------
Insert - Update Stored Procedure for Personal Expense
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Personal Expense
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdPersonalExpense'))
BEGIN
    DROP PROCEDURE InsUpdPersonalExpense
END
GO

CREATE PROCEDURE InsUpdPersonalExpense
	-- Parameters
    @userID int,
    @rent money,
    @groceries money,
    @eating money,
    @utilities money,
    @phone money,
    @gas money,
    @automobileExpense money,
    @recreation money,
    @dayCare money,
    @gifts money,
    @domesticHelp money,
    @clothing money,
    @homeMaintenance money,
    @homeFurnishing money,
    @childSupport money,
    @alimony money,
    @entertainment money,
    @vacation money,
    @hobbies money,
    @gym money,
    @subscription money,
    @petExpense money,
    @booksMovies money,
    @cableTV money,
    @internet money,
    @haircut money,
    @miscelleneous money,
    @total money,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO PersonalExpense
		(
			UserID,
            Rent,
            Groceries,
            Eating,
            Utilities,
            Phone,
            Gas,
            AutomobileExpense,
            Recreation,
            DayCare,
            Gifts,
            DomesticHelp,
            Clothing,
            HomeMaintenance,
            HomeFurnishings,
            ChildSupport,
            Alimony,
            Entertainment,
            Vacations,
            Hobbies,
            Gym,
            Subscriptions,
            PetExpense,
            BooksMovies,
            CableTV,
            Internet,
            Haircuts,
            Miscelleneous,
            Total
        )
        VALUES
        (
            @userID,
			@rent,
			@groceries,
			@eating,
			@utilities,
			@phone,
			@gas,
			@automobileExpense,
			@recreation,
			@dayCare,
			@gifts,
			@domesticHelp,
			@clothing,
			@homeMaintenance,
			@homeFurnishing,
			@childSupport,
			@alimony,
			@entertainment,
			@vacation,
			@hobbies,
			@gym,
			@subscription,
			@petExpense,
			@booksMovies,
			@cableTV,
			@internet,
			@haircut,
			@miscelleneous,
			@total
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE PersonalExpense SET
		
			Rent = @rent,
            Groceries = @groceries,
            Eating = @eating,
            Utilities = @utilities,
            Phone = @phone,
            Gas = @gas,
            AutomobileExpense = @automobileExpense,
            Recreation = @recreation,
            DayCare = @dayCare,
            Gifts = @gifts,
            DomesticHelp = @domesticHelp,
            Clothing = @clothing,
            HomeMaintenance = @homeMaintenance,
            HomeFurnishings = @homeFurnishing,
            ChildSupport = @childSupport,
            Alimony = @alimony,
            Entertainment = @entertainment,
            Vacations = @vacation,
            Hobbies = @hobbies,
            Gym = @gym,
            Subscriptions = @subscription,
            PetExpense = @petExpense,
            BooksMovies = BooksMovies,
            CableTV = @cableTV,
            Internet = @internet,
            Haircuts = @haircut,
            Miscelleneous = @miscelleneous,
            Total = @total
        
		WHERE (UserID = @userId)
    END
END
GO
GO
---------------
 */
#endregion

#region LargeExpenditures
/*
 Select Procedure
 -----------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Large Expenditure
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetLargeExpenditure'))
BEGIN
    DROP PROCEDURE GetLargeExpenditure
END
GO

CREATE PROCEDURE GetLargeExpenditure 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		LargeExpenditureCount,
		Expense,
		Cost,
		Year,
		Frequency
		
	FROM LargeExpenditures WHERE UserID = @userID
END
GO
---------------------
Insert - Update Stored Procedure for Large Expenditure
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Large Expenditure
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdLargeExpenditure'))
BEGIN
    DROP PROCEDURE InsUpdLargeExpenditure
END
GO

CREATE PROCEDURE InsUpdLargeExpenditure
	-- Parameters
    @userID int,
    @largeExpenditureCount int,
    @expense money,
    @cost money,
    @year int,
    @frequency int,
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO LargeExpenditures
		(
			UserID,
			LargeExpenditureCount,
			Expense,
			Cost,
			Year,
			Frequency
        )
        VALUES
        (
            @userID,
			@largeExpenditureCount,
			@expense,
			@cost,
			@year,
			@frequency
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE LargeExpenditures SET
		
			Expense = @expense,
			Cost = @cost,
			Year = @year,
			Frequency = @frequency
        
		WHERE (UserID = @userId AND LargeExpenditureCount = @largeExpenditureCount)
    END
END
GO
 */
#endregion

#region Notes
/*
 Select Procedure
 -----------------
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Get Notes
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.GetNotes'))
BEGIN
    DROP PROCEDURE GetNotes
END
GO

CREATE PROCEDURE GetNotes 
	-- Parameters
    @userID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SELECT 
		Notes
		
	FROM Notes WHERE UserID = @userID
END
GO
---------------------------
Insert - Update Stored Procedure for Notes
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Chaitanya Shejwal
-- Create date: 14/02/2022
-- Description:	Insert & Update Stored Procedure For Notes
-- =============================================

IF EXISTS(SELECT* FROM sys.objects WHERE type= 'P' AND OBJECT_ID = OBJECT_ID('dbo.InsUpdNotes'))
BEGIN
    DROP PROCEDURE InsUpdNotes
END
GO

CREATE PROCEDURE InsUpdNotes
	-- Parameters
    @userID int,
    @notes varchar(MAX),
    @operationType varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    IF @operationType = 'Insert'

    BEGIN
        INSERT INTO Notes
		(
			UserID,
			Notes
        )
        VALUES
        (
            @userID,
			@notes
        )
    END

    IF @operationType = 'Update'
	BEGIN
        UPDATE Notes SET
		
			Notes = @notes
        
		WHERE (UserID = @userID)
    END
END
GO
 */
#endregion