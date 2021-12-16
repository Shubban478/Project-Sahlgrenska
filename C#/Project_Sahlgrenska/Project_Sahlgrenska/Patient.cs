using System.Windows;

namespace Project_Sahlgrenska
{
    class Patient
    {
        public Patient(string Id, string Name, string Adress, string Gender, string Date, string Critical)
        {
            Bot.Update("INSERT INTO patients(ID,Name,Address,Gender,Admitted,Critical) VALUES('" + Id + "','" + Name + "','" + Adress + "','" + Gender + "','" + Date.Substring(0, 10) + "','" + Critical + "')");
            MessageBox.Show(Id + "\n" +
                Name + "\n" +
                Adress + "\n" +
                Gender + "\n" +
                Date.Substring(0, 10) + "\n added to database.");
        }
    }
}
