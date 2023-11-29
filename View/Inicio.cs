namespace facturacion_taller_p3.View
{
    public class Inicio
    {
        string[] inicioOpciones = { "Ir A los Kits", "Ir A las Piezas", "Facturar", "Salir" };
        int windowsWidth = Console.WindowWidth;

        public KitView _kitView { get; }
        public PiezasView _piezasView { get; }
        public FacturaView _facturaView { get; }

        public Inicio(List<Kits> kits, List<Pieza> piezas)
        {
            _kitView = new KitView(kits, piezas);
            _piezasView = new PiezasView(piezas);
            _facturaView = new FacturaView(kits, piezas);
        }

        public void Mostrar()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=".PadRight(windowsWidth, '='));
                Console.WriteLine("==== Elige tu Opcion =".PadRight(windowsWidth, '='));
                Console.WriteLine("=".PadRight(windowsWidth, '='));
                Console.WriteLine("\n");

                for (int i = 0; i < inicioOpciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.- {inicioOpciones[i]}");
                }

                Console.Write("\nOpcion: ");
                if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > inicioOpciones.Length)
                {
                    Console.WriteLine("Opcion No valida Intentalo de Nuevo, Presiona Enter Para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (opcion == inicioOpciones.Length)
                {
                    Console.Clear();
                    Console.WriteLine("=".PadRight(windowsWidth, '='));
                    Console.WriteLine("==== ADIOS =".PadRight(windowsWidth, '='));
                    Console.WriteLine("=".PadRight(windowsWidth, '='));
                    break;
                }


                switch (opcion)
                {
                    case 1:
                        _kitView.Inicio();
                        break;
                    case 2:
                        _piezasView.Inicio();
                        break;
                    case 3:
                        _facturaView.Inicio();
                        break;
                    default:
                        throw new NotImplementedException();
                }

            } while (true);

        }

    }
}