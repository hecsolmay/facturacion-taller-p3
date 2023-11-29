namespace facturacion_taller_p3.Service
{
    public class PiezaServices : IPiezaService
    {
        private List<Pieza> _piezas { get; }
        public PiezaServices(List<Pieza> piezas)
        {
            _piezas = piezas;

        }


        public void Crear(Pieza pieza)
        {
            pieza.NumeroDePieza = _piezas.Count + 1;
            _piezas.Add(pieza);
        }

        public void Actualizar(int numeroDePieza, decimal precio)
        {
            var foundPieza = _piezas.FirstOrDefault(p => p.NumeroDePieza == numeroDePieza);

            if (foundPieza is null)
            {
                throw new Exception("Pieza no encontrada");
            }

            foundPieza.Precio = precio;
        }

        public Pieza? ObtenerPieza(int numeroDePieza)
        {
            return _piezas.FirstOrDefault(p => p.NumeroDePieza == numeroDePieza);
        }
    }
}