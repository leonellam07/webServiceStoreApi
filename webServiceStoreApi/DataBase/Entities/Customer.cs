using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string? SecondName { get; set; }

        [MaxLength(100), Required]
        public string LastName { get; set; }

        [MaxLength(10), Required]
        public string NIT { get; set; }

        [MaxLength(300)]
        public string? Address { get; set; }

        public string IdTypeCustomer { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
