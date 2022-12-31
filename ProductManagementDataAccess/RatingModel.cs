using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    public class RatingModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Value { get; set; }
    }
}
