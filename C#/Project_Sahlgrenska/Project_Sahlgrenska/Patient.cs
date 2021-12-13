using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Sahlgrenska
{
    class Patient
    {
        public Patient(string Id, string Name, string Adress, string Gender, string Date)
        {
            Bot.Update("INSERT INTO patients(ID,Name,Address,Gender,Admitted) VALUES('" + Id + "','" + Name + "','" + Adress + "','" + Gender + "','" + Date.Substring(0, 10) + "')");
        }
    }
}
