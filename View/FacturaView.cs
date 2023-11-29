namespace facturacion_taller_p3.View
{
    public class FacturaView
    {
        string[] inicioOpciones = { "Facturar Kit", "Facturar Pieza", "Regresar" };
        int windowsWidth = Console.WindowWidth;
        public KitServices _kitServices { get; }
        public PiezaServices _piezaServices { get; }

        public FacturaView(List<Kits> kits, List<Pieza> piezas)
        {
            _kitServices = new KitServices(kits);
            _piezaServices = new PiezaServices(piezas);
        }

        public void Inicio()
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
                    break;
                }


                switch (opcion)
                {
                    case 1:
                        FacturarKit();
                        break;
                    case 2:
                        FacturarPieza();
                        break;
                    default:
                        throw new NotImplementedException();
                }

            } while (true);
        }


        public void FacturarKit()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Factura De Kit =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("\n");

            Console.Write("Numero del Kit: ");

            if (!int.TryParse(Console.ReadLine(), out int numeroDeKit))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            var kit = _kitServices.ObtenerKit(numeroDeKit);

            if (kit is null)
            {
                Console.WriteLine("Kit no encontrado, Intentalo de Nuevo");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Detalles =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("\n");

            Console.WriteLine($"Numero de Kit: {kit.NumeroDeKit}");
            Console.WriteLine($"Nombre: {kit.Nombre}");
            Console.WriteLine($"Precio: ${kit.Precio}");
            Console.WriteLine($"Tiempo: {kit.Tiempo} horas");

            Console.Write("\nPresiona Enter Para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void FacturarPieza()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Factura De Pieza =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("\n");

            Console.Write("Numero de la Pieza: ");

            if (!int.TryParse(Console.ReadLine(), out int numeroDepieza))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            var pieza = _piezaServices.ObtenerPieza(numeroDepieza);

            if (pieza is null)
            {
                Console.WriteLine("Kit no encontrado, Intentalo de Nuevo");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Detalles =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("\n");

            Console.WriteLine($"Numero de pieza: {pieza.NumeroDePieza}");
            Console.WriteLine($"Nombre: {pieza.Nombre}");
            Console.WriteLine($"Precio: ${pieza.Precio}");
            Console.WriteLine($"Tiempo: {pieza.Tiempo} horas");

            Console.Write("\nPresiona Enter Para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}