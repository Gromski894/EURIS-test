using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.Entities
{

    [MetadataType(typeof(Product))]
    public partial class Product
    { }

    public class Product_Validation
    {
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
