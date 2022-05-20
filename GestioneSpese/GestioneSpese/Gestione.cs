using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public class Gestione
    {
        static string connectionStringSQL = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GestioneSpese; Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

        public static void InsertSpesa()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }
                DateTime data = new DateTime(2015, 12, 31, 5, 10, 20);
                int categoria = 103;
                string descrizione = "this is a description";
                string utente = "Matteo";
                decimal importo = 312;
                bool approvato = false;

                string insertSQL = $"insert into Spese values ('{data}', '{categoria}', '{descrizione}', '{utente}', '{importo}', '{approvato}')";
                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;

                int Insert = insertCommand.ExecuteNonQuery();

                if (Insert >= 1)
                {
                    Console.WriteLine($"{Insert} expense has been entered correctly");
                }
                else
                {
                    Console.WriteLine("something went wrong, check your expense");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }


        public static void UpdateSpesa()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }
                byte approvato = 1;
                int id = 3;

                string insertSQL = $"UPDATE Spese SET Approvato = {approvato} WHERE id = {id}";

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;

                int Insert = insertCommand.ExecuteNonQuery();

                if (Insert >= 1)
                {
                    Console.WriteLine($"{Insert} expense has been updated correctly");
                }
                else
                {
                    Console.WriteLine("something went wrong, check your expense");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }


        public static void DeleteSpesa()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }
                int id = 5;

                string insertSQL = $"DELETE FROM Spese WHERE id = {id}";

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;

                int Insert = insertCommand.ExecuteNonQuery();

                if (Insert >= 1)
                {
                    Console.WriteLine($"{Insert} expense has been deleted correctly");
                }
                else
                {
                    Console.WriteLine("something went wrong, check your expense");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }


        //public static void ShowAllApproveSpesa()
        //{
        //    using SqlConnection connessione = new SqlConnection(connectionStringSQL);
        //    try
        //    {
        //        connessione.Open();

        //        if (connessione.State == System.Data.ConnectionState.Open)
        //        {
        //            Console.WriteLine("connected to the database");
        //        }
        //        else
        //        {
        //            Console.WriteLine("not connected to the database");
        //        }

        //        string insertSQL = $"SELECT * FROM Spese WHERE Approvato = 1";

        //        SqlCommand comando = new SqlCommand();
        //        comando.Connection = connessione;
        //        comando.CommandType = System.Data.CommandType.Text;
        //        comando.CommandText = insertSQL;


        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var id = (int)reader["id"];
        //            var data = (DateTime)reader["Data"];
        //            var categoria = (int)reader["Categoria"];
        //            var descrizione = (string)reader["Descrizione"];
        //            var utente = (string)reader["Utente"];
        //            var importo = (decimal)reader["Importo"];
        //            var approvato = (bool)reader["Approvato"];

        //            Console.WriteLine($"{id} - {data} - {categoria} - {descrizione} - {utente} - {importo} - {approvato}");
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"Errore SQL: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Errore: {ex.Message}");
        //    }
        //    finally
        //    {
        //        connessione.Close();
        //        Console.WriteLine("connection closed");
        //    }
        //}


        public static void ShowSpecificPersonSpesa()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }

                string utentespecifico = "Luca";
                string insertSQL = $"SELECT * FROM Spese WHERE Utente LIKE '{utentespecifico}'";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = insertSQL;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["id"];
                    var data = (DateTime)reader["Data"];
                    var categoria = (int)reader["Categoria"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var importo = (decimal)reader["Importo"];
                    var approvato = (bool)reader["Approvato"];

                    Console.WriteLine($"{id} - {data} - {categoria} - {descrizione} - {utente} - {importo} - {approvato}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }


        public static void TotalSpese()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();
                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }
                string insertSQL = $"SELECT SUM(Importo) FROM Spese WHERE Categoria = 103"; //non inserisce la query

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;

                int Insert = insertCommand.ExecuteNonQuery();

                if (Insert >= 1)
                {
                    Console.WriteLine($"{Insert} expense has been entered correctly");
                }
                else
                {
                    Console.WriteLine("something went wrong, check your expense");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }
    }
}
