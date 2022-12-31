using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime DateManufactured { get; set; }
    }
}
