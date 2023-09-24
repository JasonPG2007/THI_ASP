using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
