using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Factura
    {

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public bool Cancelada { get; set; }
        public bool Cerrada { get; set; }
    }
}
