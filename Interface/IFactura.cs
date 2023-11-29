namespace facturacion_taller_p3.Interface
{
    public interface IFactura
    {
        void CrearPieza();
        void CrearKit();
        void ActualizarPrecioKit(int id, decimal nuevoPrecio);
        void ActualizarPrecioPieza(int id, decimal nuevoPrecio);
    }
}