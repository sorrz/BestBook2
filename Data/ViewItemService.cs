using BestBook2.Options;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace BestBook2.Data
{
    public class ViewItemService
    {
        static string connection = "Server=DESKTOP-1EIDEBF\\SQLEXPRESS; Database=BestBook; User Id=bestbook; Password=testar123; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true";

        public static List<ViewItem> GetViewItems()
        {
            List<ViewItem> newRow = new List<ViewItem>();
            SqlConnection cnn; 
            cnn = new SqlConnection(connection); 
            cnn.Open(); 
            SqlCommand command = new SqlCommand(); 
            command.Connection = cnn; 
            command.CommandText = $"SELECT * FROM dbo.View_1";

            SqlDataReader reader = command.ExecuteReader();
            {
                while (reader.Read())
                {
                    var current = new ViewItem();

                    var _ISBN = reader[0].ToString();
                    current.ISBN = _ISBN;
                    var _currentStock = reader[1].ToString();
                    current.CurrentStock = _currentStock;
                    var _pricePerItem = reader[2].ToString();
                    current.PricePerItem = _pricePerItem;
                    var _authorName = reader[3].ToString();
                    current.AuthorName = _authorName;
                    var _birthdate = reader[4].ToString();
                    current.Birthdate = _birthdate;
                    var _totalWorth = reader[5].ToString();
                    current.TotalWorth = _totalWorth;

                    newRow.Add(current);
                }
            }
            cnn.Close();
            return newRow;

            


        }


    }

 
}
