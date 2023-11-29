namespace facturacion_taller_p3.Interface
{
    public interface IPiezaService
    {
        void Crear(Pieza pieza);
        void Actualizar(int numeroDePieza, decimal precio);
    }
}