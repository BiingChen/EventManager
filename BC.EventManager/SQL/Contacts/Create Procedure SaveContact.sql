ALTER PROCEDURE SaveContact
@ContactId INT = NULL,
@FirstName NVARCHAR(100),
@LastName NVARCHAR(100),
@PhoneNumber NVARCHAR(30),
@Email NVARCHAR(100),
@Company NVARCHAR(100)
AS
BEGIN
	IF(@ContactId IS NULL OR @ContactId = 0)
	BEGIN
		INSERT INTO dbo.Contacts
		(
		    FirstName,
		    LastName,
		    PhoneNumber,
		    Email,
		    Company
		)
		VALUES
		(  	@FirstName,
			@LastName,
			@PhoneNumber,
			@Email,
			@Company
		)

		SET @ContactId = SCOPE_IDENTITY();
		

	END
	ELSE
	BEGIN
		UPDATE dbo.Contacts
		SET
			FirstName = @FirstName,
			LastName = @LastName,
			PhoneNumber = @PhoneNumber,
			Email = @Email,
			Company = @Company
		WHERE ContactId = @ContactId
	END

	SELECT @ContactId AS ContactId

END