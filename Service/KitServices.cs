namespace facturacion_taller_p3.Service
{
    public class KitServices : IKitService
    {
        private List<Kits> _kits { get; }
        public KitServices(List<Kits> kits)
        {
            _kits = kits;
        }

        public void Crear(Kits newKit)
        {
            newKit.NumeroDeKit = _kits.Count + 1;
            _kits.Add(newKit);
        }

        public Kits? ObtenerKit(int numeroDeKit)
        {
            return _kits.FirstOrDefault(k => k.NumeroDeKit == numeroDeKit);
        }

        public void Actualizar(int numeroDeKit, decimal price)
        {
            var foundKit = _kits.FirstOrDefault(k => k.NumeroDeKit == numeroDeKit);
            
            if (foundKit == null)
            {
                throw new Exception("Kit no encontrado");
            }

            foundKit.Precio = price;
        }
    }
}