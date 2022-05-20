using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public class GestioneDisconnected
    {
        static string connectionStringSQL = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GestioneSpese; Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

        public static void ShowAllApproveSpesa()
        {
            DataSet spesa = new DataSet();

            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("connected to the database");
                else
                    Console.WriteLine("not connected to the database");

                SqlDataAdapter spesaAdap = InizializzaAdapter(conn);
                spesaAdap.Fill(spesa, "Gestione");
                conn.Close();
                Console.WriteLine("Connessione chiusa");
                foreach (DataTable table in spesa.Tables)
                {
                    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");
                }


                Console.WriteLine("Lista spese approvate");
                foreach (DataRow riga in spesa.Tables["Gestione"].Rows)
                {
                    Console.WriteLine($"{riga["id"]} - {riga["Data"]} - {riga["Categoria"]} - {riga["Descrizione"]} - {riga["Utente"]} - {riga["Importo"]} - {riga["Approvato"]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private static SqlDataAdapter InizializzaAdapter(SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM Spese WHERE Approvato = 1;", conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            return adapter;
        }
    }
}
