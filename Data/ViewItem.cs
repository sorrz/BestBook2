using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace BestBook2.Data
{
    public class ViewItem
    {
        private ViewItem viewItem;

        //public ViewItem(ViewItem viewItem)
        //{
        //    this.viewItem = viewItem;
        //}

        [Key]
        public string ISBN { get; set; }

        public string CurrentStock { get; set; }
        public string PricePerItem { get; set; }
        public string? AuthorName { get; set; }
        public string Birthdate { get; set; }
        public string TotalWorth {  get; set; }

    }
}
