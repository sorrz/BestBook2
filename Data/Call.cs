using System.Data;
using Microsoft.Data.SqlClient;
using BestBook2.Options;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace BestBook2.Data
//using (sqlCon = new SqlConnection("Server=DESKTOP-1EIDEBF\\SQLEXPRESS; Database=BestBook; User Id=bestbook; Password=testar123; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))


{
    public class Call : ICall
    {
        //SqlConnection SqlCon;
        private readonly SqlDbOptions _dbOptions;

        public Call(IOptions<SqlDbOptions> dbOptions)  
        {
            _dbOptions = dbOptions.Value;
        }


        public void Test(long isbn_value, long fromStore, long toStore, int stockChange)
        {
            SqlConnection sqlCon;
            using (sqlCon = new SqlConnection(_dbOptions.DefaultConnection))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("dbo.MoveBook", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ISBN", SqlDbType.BigInt).Value = isbn_value;
                sql_cmnd.Parameters.AddWithValue("@FromStore", SqlDbType.BigInt).Value = fromStore;
                sql_cmnd.Parameters.AddWithValue("@ToStore", SqlDbType.BigInt).Value = toStore;
                sql_cmnd.Parameters.AddWithValue("@StockChange", SqlDbType.Int).Value = stockChange;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}
