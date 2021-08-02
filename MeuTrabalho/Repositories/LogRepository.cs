using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories
{
    public class LogRepository
    {
        SqlConnection _connection;

        public LogRepository(SqlConnection connection)
        {
            this._connection = connection;
        }

        public int TotalRegistros()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM tbLog", this._connection);

                var reader = command.ExecuteReader();
                int total = 0;
                while (reader.HasRows)
                {
                    total = total + 1;
                    reader.Read();
                }

                reader.Close();

                return total;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
