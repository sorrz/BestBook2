using System.ComponentModel.DataAnnotations;

namespace BestBook2.Data
{
    public class BookMaster
    {

        [Key]
        public Int64 ISBN { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
        public string RealeaseDate { get; set; }




    }
}
