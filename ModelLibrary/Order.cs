using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string CreatedDate { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
