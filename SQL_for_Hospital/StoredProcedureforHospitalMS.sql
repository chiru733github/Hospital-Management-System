CREATE PROCEDURE AddDoctor
(
	@DoctorName varchar(50),
	@DoctorEmail varchar(50),
	@PhoneNumber varchar(10),
	@DoctorAge int,
	@Gender varchar(10),
	@DoctorAddress varchar(50),
	@Qualification varchar(10),
	@Specialization varchar(30),
	@Experience float,
	@DoctorImage VARCHAR(100)
)
AS
BEGIN
	BEGIN TRY
		IF(@DoctorName=null OR @DoctorEmail=null OR @PhoneNumber=null OR @DoctorAge=0 OR @Gender=null OR @DoctorAddress=null OR 
		@Qualification=null OR @Specialization=null OR @Experience=0 OR @DoctorImage=null)
		BEGIN
			PRINT 'Required all parameters';
		END
		ELSE IF EXISTS (SELECT 1 FROM Doctor WHERE DoctorEmail=@DoctorEmail)
		BEGIN
			PRINT 'DOCTOR Email already in use';
		END
		ELSE
		BEGIN
			INSERT INTO Doctor(DoctorName,DoctorEmail,PhoneNumber,DoctorAge,Gender,DoctorAddress,Qualification,Specialization,Experience,
					DoctorImage,IsTrash)
			VALUES(@DoctorName,@DoctorEmail,@PhoneNumber,@DoctorAge,@Gender,@DoctorAddress,@Qualification,@Specialization,@Experience,
					@DoctorImage,0)
			PRINT 'Doctor details inserted successfully.';
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR(@ErrorMessage,16,1);
	END CATCH
END;
go
drop proc AddDoctor
CREATE PROCEDURE GetDoctor
(@DoctorId int=0)
AS
BEGIN
	BEGIN TRY
		IF(@DoctorId>0 AND EXISTS(SELECT 1 FROM Doctor WHERE DoctorId=@DoctorId))
		BEGIN
			SELECT * FROM Doctor
			WHERE DoctorId=@DoctorId
		END
		ELSE
		BEGIN
			PRINT 'Invaild DoctorId'
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        THROW 50003, @ErrorMessage, 1;
	END CATCH
END;
go
CREATE PROCEDURE AllDoctorDetails
AS
BEGIN
	SELECT * FROM Doctor
END
GO
CREATE PROCEDURE UpdateDoctor
(
	@DoctorId int,
	@DoctorName varchar(50),
	@DoctorEmail varchar(50),
	@PhoneNumber varchar(10),
	@DoctorAge int,
	@Gender varchar(10),
	@DoctorAddress varchar(50),
	@Qualification varchar(10),
	@Specialization varchar(30),
	@Experience float,
	@DoctorImage varchar(100)
)
AS
BEGIN
	BEGIN TRY
		IF(@DoctorId>0 AND EXISTS(SELECT 1 FROM Doctor WHERE DoctorId=@DoctorId))
		BEGIN
			Update Doctor
			SET DoctorName=@DoctorName,DoctorEmail=@DoctorEmail,PhoneNumber=@PhoneNumber,DoctorAge=@DoctorAge,
				Gender=@Gender,DoctorAddress=@DoctorAddress,Qualification=@Qualification,
				Specialization=@Specialization,Experience=@Experience,DoctorImage=@DoctorImage
			WHERE DoctorId=@DoctorId
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR(@ErrorMessage,16,1);
	END CATCH
END;
GO
CREATE PROCEDURE DeleteDoctor
(@DoctorId int=0)
AS
BEGIN
	BEGIN TRY
		IF(@DoctorId>0 AND EXISTS(SELECT 1 FROM Patient WHERE PatientID=@DoctorId))
		BEGIN
			DELETE FROM Doctor WHERE DoctorId=@DoctorId
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR(@ErrorMessage,16,1);
	END CATCH
END;