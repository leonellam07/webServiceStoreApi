using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class InvoiceDetail
    {
        public int Noline { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
 
        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Vat { get; set; }

        [Required]
        public int Total { get; set; }

    }
}
