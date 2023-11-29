namespace facturacion_taller_p3.Models
{
    public class Pieza : ItemFacturable
    {
        public int NumeroDePieza { get; set; } = 0;
        public override decimal Precio { get; set;} = 0;
    }
}