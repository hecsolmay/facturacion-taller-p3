namespace facturacion_taller_p3.Interface
{
    public interface IKitService
    {
        void Crear(Kits newKit);
        void Actualizar(int numeroDeKit, decimal price);
    }
}