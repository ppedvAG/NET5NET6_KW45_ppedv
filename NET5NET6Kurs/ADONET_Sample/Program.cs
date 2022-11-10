using Microsoft.Data.SqlClient;

namespace ADONET_Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(args[0]);
            await conn.OpenAsync();

            SqlCommand sqlCommand = new SqlCommand(conn.ConnectionString);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); 
            //sqlDataAdapter.Fill()
            
        }
    }
}