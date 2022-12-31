using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    public class ProductSearchParameters
    {
        public int? ProductId { get; set; }
        public string Description { get; set; }
        public int? BottomPrice { get; set; }
        public int? TopPrice { get; set; }
        public DateTime? DateManufactured { get; set; }
        public int? CategoryId { get; set; }
        public int? Rating { get; set; }
    }
}
