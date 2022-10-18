namespace Models
{
    public class FacturaDetalle
    {
        public int FacturaId { get; set; } 
        public int NoLinea { get; set; }
        public int ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}