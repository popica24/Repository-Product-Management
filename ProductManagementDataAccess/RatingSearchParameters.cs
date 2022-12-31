using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDataAccess
{
    public class RatingSearchParameters
    {
        int? UserId { get; set; }
        int? ProductId { get; set; }
        int? Value { get; set; }
    }
}
