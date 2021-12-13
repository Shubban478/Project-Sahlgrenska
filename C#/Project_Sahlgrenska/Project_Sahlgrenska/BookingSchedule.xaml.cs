﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for BookingSchedule.xaml
    /// </summary>
    public partial class BookingSchedule : Window
    {
        List<string> appointmentsAvailable = new List<string>();
        public BookingSchedule()
        {
            InitializeComponent();

            calendar.SelectedDate = DateTime.UtcNow;



        }

        private void PopulateAppointments()
        {
            string tid = calendar.SelectedDate.ToString().Substring(0, 10);
            if (allDoctors.IsChecked == true)
            {
                Bot.ReadAll("SELECT * FROM appointments_overview where tid like '" + tid + "%';", appointmentsTable);
            }
            else
            {
                Bot.ReadAll("SELECT * FROM appointments_overview where doktor = '" + Hem.doctorId + "' and tid like '" + tid + "%';", appointmentsTable);
            }


        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateAppointments();
        }

    }
}