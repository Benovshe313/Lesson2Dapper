

using System.Data.SqlClient;

namespace Library.Data
{
    internal class Database:IDisposable
    {
        public SqlConnection Connection { get; set; }
        public Database(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Dispose();
            GC.SuppressFinalize(this);
        }

        ~Database() { 
            Dispose();
        }
    }
}
