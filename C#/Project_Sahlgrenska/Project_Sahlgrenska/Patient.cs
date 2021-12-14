using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Project_Sahlgrenska
{
    class Patient
    {
        public Patient(string Id, string Name, string Adress, string Gender, string Date)
        {
            Bot.Update("INSERT INTO patients(ID,Name,Address,Gender,Admitted) VALUES('" + Id + "','" + Name + "','" + Adress + "','" + Gender + "','" + Date.Substring(0, 10) + "')");
            MessageBox.Show(Id+"\n" +
                Name+"\n" +
                Adress+"\n" +
                Gender+"\n" +
                Date.Substring(0,10)+ "\n added to database.");
        }
    }
}
