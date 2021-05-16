--DROP TABLE Contacts

CREATE TABLE Contacts
(
	ContactId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Contacts PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(30) NULL, -- How to deal with errant formatting?  Where to cleanse it?
	Email NVARCHAR(200) NULL,
	Company NVARCHAR(100) NULL
)

--Test Data

INSERT INTO dbo.Contacts
(
    FirstName,
    LastName,
    PhoneNumber,
    Email,
    Company
)
VALUES
(   N'Bing', -- FirstName - nvarchar(100)
    N'Chen', -- LastName - nvarchar(100)
    N'6263214321', -- PhoneNumber - nvarchar(10)
    N'bingchen@gmail.com', -- Email - nvarchar(200)
    N'Decisive Decisions'  -- Company - nvarchar(100)
    )

SELECT * FROM dbo.Contacts

TRUNCATE TABLE dbo.Contacts