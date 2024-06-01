function EndTimeSetting(startTime) {
    var startTimeforAppointment = document.getElementById("start");
    var EndTimeforAppointment = document.getElementById("end");
    var [hour, Minute] = startTime.split(":");
    var EndHour = parseInt(hour, 10);
    var EndMinute = parseInt(Minute, 10) + 30;
    if (EndMinute >= 60) {
        EndMinute -= 60;
        EndHour = (EndHour+1)%24;
    }
    var formattedEndTime = ('0' + EndHour).slice(-2) + ':' + ('0' + EndMinute).slice(-2);
    EndTimeforAppointment.value = formattedEndTime;

}
function validateAppointmentDate() {
    var AppointmentDate = document.getElementById('Appointmentdate');
    var selectedDate = new Date(AppointmentDate.value);
    var currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);
    if (selectedDate < currentDate) {
        alert('Please select a future date for Appointment.');
        AppointmentDate = '';
    }
}