using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace BestBook2.Data


{
    public class ExampleModel
    {


        public string isbn { get; set; }
        public string fromStore { get; set; }
        public string toStore { get; set; }
        public string stockChange { get; set; }


    }
}
