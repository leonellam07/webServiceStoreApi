using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Column(TypeName="DateTime"), Required]
        public DateTime Created { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        [Required]
        public double Vat { get; set; }

        [Required]
        public double Total { get; set; }

        public bool IsCanceled { get; set; }

        public bool IsClosed { get; set; }
    }
}
