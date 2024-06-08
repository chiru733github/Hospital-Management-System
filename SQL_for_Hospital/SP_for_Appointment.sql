CREATE PROCEDURE AllAppointmentDetails
AS
BEGIN
	SELECT * FROM Appointment
END
go
CREATE PROCEDURE AddAppointment
(
	@DoctorId int,
	@PatientId int,
	@AppointmentDate Date,
	@StartTime time,
	@EndTime time,
	@Concern Varchar(50)
)
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT 1 FROM DOCTOR WHERE DoctorId=@DoctorId)
		BEGIN
			Throw 50000,'Invaild doctor Id.',1;
		END

		ELSE IF NOT EXISTS(SELECT 1 FROM Patient WHERE PatientID=@PatientId)
		BEGIN
			Throw 50001,'Invaild Patient Id.',1;
		END

		ELSE IF @AppointmentDate < CAST(GETDATE() AS DATE)
        BEGIN
            THROW 50002, 'Invalid Appointment Date.', 1;
        END

		ELSE
		BEGIN
			INSERT into Appointment(DoctorFkId,PatientFkId,AppointmentDate,StartTime,EndTime,concern)
			values(@DoctorId,@PatientId,@AppointmentDate,@StartTime,@EndTime,@Concern)
		END
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();

        -- Raise the captured error message
        THROW 50003, @ErrorMessage, 1;
	END CATCH
END;
drop proc AddAppointment
go
CREATE PROCEDURE getDoctorwithPatientDetails
AS
BEGIN
	BEGIN TRY
		select d.DoctorName as DoctorNames,d.DoctorImage as DoctorImages,p.*,a.concern as Concern
		from Doctor d join Appointment a
		on d.DoctorId=a.DoctorFkId 
		join Patient p
		on p.PatientID=a.PatientFkId
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();

        -- Raise the captured error message
        THROW 50003, @ErrorMessage, 1;
	END CATCH
END

