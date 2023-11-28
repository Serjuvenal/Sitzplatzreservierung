using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Sitzplatzreservierung
{
    internal class FlugzeugRepository : IFlugzeugRepository
    {
        public FlugzeugRepository() { }

        string myConnectionString = "SERVER=192.168.178.207;" +
                                   "DATABASE=sergioDB_Sitzplatzreservierung;" +
                                   "UID=Admin;" +
                                   "PASSWORD=System1!;";


        public void FlugzeugTabelleErzeugen()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);

            string mycreateQuery = "CREATE TABLE Flugzeug (ID_Flugzeug INT NOT NULL AUTO_INCREMENT,MARKE VARCHAR(255) NOT NULL,MODELL VARCHAR(255) NOT NULL,ANZAHLDERSITZPLAETZE INT NOT NULL,REIHEANZAHL INT NOT NULL,PRIMARY KEY (ID_Flugzeug)) ENGINE = InnoDB;";

            MySqlCommand myCommand = new MySqlCommand(mycreateQuery);

            myCommand.Connection = connection;
            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void FlugzeugSpeichern(Flugzeug t_flugzeug)
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);

            string myInsertQuery = "INSERT INTO Flugzeug (MARKE, MODEL, ANZAHLDERSITZPLAETZE, REIHEANZAHL) " +
                                   "Values('" + t_flugzeug.Marke + "','" + t_flugzeug.Modell + "','" + t_flugzeug.AnzahlDerSitzplaetze + ',' + t_flugzeug.Reihenanzahl + "');";

            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

            myCommand.Connection = connection;
            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Flugzeug> LadeListeAlleFlugzeuge()
        {
            List<Flugzeug> t_flugzeugListe = new List<Flugzeug>();
            Flugzeug t_flugzeug;

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Flugzeug;";
            MySqlDataReader reader;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    t_flugzeug = new Flugzeug();
                    t_flugzeug.Marke = reader.GetString("MARKE");
                    t_flugzeug.Modell = reader.GetString("MODELL");
                    t_flugzeug.AnzahlDerSitzplaetze = Convert.ToInt32(reader.GetString("ANZAHLDERSITZPLAETZE"));
                    t_flugzeug.Reihenanzahl = Convert.ToInt32(reader.GetString("REIHENANZAHL"));
                    t_flugzeugListe.Add(t_flugzeug);
                }
                connection.Close();
                return t_flugzeugListe;

            }
            catch (Exception)
            {

                throw;
            }

        }

        
    }
}
