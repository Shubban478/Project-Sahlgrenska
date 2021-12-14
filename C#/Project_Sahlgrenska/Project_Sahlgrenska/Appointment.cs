using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Project_Sahlgrenska
{
    class Appointment
    {
        public Appointment(int AppointmentId, string PatientId, int DoctorId, string Reason, string Time, int RoomId)
        {

            Bot.Update("insert into appointments values (" + AppointmentId + ", '" + Time + "', '" + Reason + "');");
            Bot.Update("insert into appointments_has_rooms values (" + AppointmentId + ", " + RoomId + ");");
            Bot.Update("insert into patients_has_appointments values('" + PatientId + "', " + AppointmentId + ");");
            Bot.Update("insert into doctors_has_appointments values(" + DoctorId + ", " + AppointmentId + ");");
            Bot.Update("insert into patients_has_rooms values('" + PatientId + "', " + RoomId + ");");
            Bot.Update("update rooms set beds = beds -1 where id =" + RoomId + ";");
            Bot.Update("call update_vaccant()");
            MessageBox.Show(AppointmentId + "\n" +
                            PatientId + "\n" +
                            DoctorId + "\n" +
                            Reason + "\n" +
                            Time + "\n" +
                            RoomId + " added to database."
    );
        }

    }
}
