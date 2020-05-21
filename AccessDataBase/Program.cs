using System;
using MySql.Data.MySqlClient;


namespace AccessDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "company";

            if (dbCon.IsConnect())
            {
                try
                {
                    string query = "SELECT firstname,lastname FROM employee";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string someStringFromColumnZero = reader.GetString(0);
                        string someStringFromColumnOne = reader.GetString(1);
                        Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                    }
                }
                catch (Exception ex)
                {
                    dbCon.Close();
                }
            }

        }
    }
}
