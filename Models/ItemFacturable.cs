namespace facturacion_taller_p3.Models
{
    public abstract class ItemFacturable
    {
        public abstract decimal Precio { get; set;}
        public string Nombre { get; set; } = string.Empty;
        public int Tiempo { get; set; } = 0;
    }
}