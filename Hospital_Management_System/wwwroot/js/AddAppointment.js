
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