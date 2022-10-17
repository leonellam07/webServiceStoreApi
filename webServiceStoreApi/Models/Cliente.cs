using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string Apellidos { get; set; }
        public string NIT { get; set; }
        public string? Direccion { get; set; }
        public string IdTipoCliente { get; set; }
    }
}
