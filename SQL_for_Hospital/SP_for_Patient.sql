create PROCEDURE AddPatient
(
	@PatientName varchar(50),
	@PatientEmail varchar(50),
	@PhoneNumber varchar(10),
	@PatientAge int=0,
	@Gender varchar(10),
	@PatientAddress varchar(50),
	@PatientImage varchar(100),
	@BloodGroup varchar(5),
	@SufferFrom varchar(100)
)
AS
BEGIN
	BEGIN TRY
			INSERT INTO Patient(PatientName,PatientEmail,PhoneNumber,PatientAge,Gender,PatientAddress,PatientImage,
					BloodGroup,SufferFrom,IsTrash)
			VALUES(@PatientName,@PatientEmail,@PhoneNumber,@PatientAge,@Gender,@PatientAddress,@PatientImage,
					@BloodGroup,@SufferFrom,0)
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR(@ErrorMessage,16,1);
	END CATCH
END;
go
drop proc AddPatient
Alter PROCEDURE GetPatient
(
	@PatientID int=0
)
AS
BEGIN
	BEGIN TRY
		IF(@PatientID>0 AND EXISTS(SELECT 1 FROM Patient WHERE PatientID=@PatientID and IsTrash=0))
		BEGIN
			SELECT * FROM Patient
			WHERE PatientID=@PatientID
		END
		ELSE
		BEGIN
			PRINT 'Invaild Patient Id'
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        THROW 50003, @ErrorMessage, 1;
	END CATCH
END;
go
Alter PROCEDURE AllPatientDetails
AS
BEGIN
	SELECT * FROM Patient where IsTrash=0
END
GO
CREATE PROCEDURE UpdatePatient
(
	@PatientId int=0,
	@PatientName varchar(50),
	@PatientEmail varchar(50),
	@PhoneNumber varchar(10),
	@PatientAge int,
	@Gender varchar(10),
	@PatientAddress varchar(50),
	@PatientImage varchar(100),
	@BloodGroup varchar(5),
	@SufferFrom varchar(100)
)
AS
BEGIN
	BEGIN TRY
		IF(@PatientID>0 AND EXISTS(SELECT 1 FROM Patient WHERE PatientID=@PatientID))
		BEGIN
			Update Patient
			SET PatientName=@PatientName,PatientEmail=@PatientEmail,PhoneNumber=@PhoneNumber,PatientAge=@PatientAge,
				Gender=@Gender,PatientAddress=@PatientAddress,PatientImage=@PatientImage,BloodGroup=@BloodGroup,SufferFrom=@SufferFrom
			WHERE PatientID=@PatientId
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR(@ErrorMessage,16,1);
	END CATCH
END;
GO
alter PROCEDURE DeletePatient
(@PatientId int)
AS
BEGIN
	BEGIN TRY
		IF(@PatientID>0 AND EXISTS(SELECT 1 FROM Patient WHERE PatientID=@PatientID))
		BEGIN
			UPDATE Patient
			SET IsTrash=1
			where PatientId=@PatientId
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		SELECT @ErrorMessage = ERROR_MESSAGE()
		RAISERROR(@ErrorMessage,16,1);
	END CATCH
END;
go
CREATE PROCEDURE LoginPatient
(
	@PatientId int,
	@PatientName varchar(50)
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS(SELECT 1 FROM Patient WHERE PatientID=@PatientID AND PatientName=@PatientName and IsTrash=0)
		BEGIN
			SELECT PatientId,PatientName FROM Patient WHERE PatientID=@PatientID AND PatientName=@PatientName
		END
		ELSE
		BEGIN
			THROW 50000,'Either Id or Name doesnot exist',1
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();

        -- Raise the captured error message
        THROW 50003, @ErrorMessage, 1;
	END CATCH
END;
select * from Doctor
