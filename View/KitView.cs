namespace facturacion_taller_p3.View
{
    public class KitView
    {
        string[] inicioOpciones = {
            "Crear Kit",
            "Agregar Pieza a Kit",
            "Ver Kits",
            "Detalles de Kit",
            "Regresar"
        };

        int windowsWidth = Console.WindowWidth;
        public List<Kits> _kits { get; }
        public List<Pieza> _piezas { get; }
        public KitServices _kitServices { get; }
        public PiezaServices _piezaServices { get; }

        public KitView(List<Kits> kits, List<Pieza> piezas)
        {
            _kits = kits;
            _piezas = piezas;
            _kitServices = new KitServices(_kits);
            _piezaServices = new PiezaServices(_piezas);
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
                        Crear();
                        break;
                    case 2:
                        AgregarPiezaAKit();
                        break;
                    case 3:
                        Ver();
                        break;
                    case 4:
                        Detalles();
                        break;
                    default:
                        throw new NotImplementedException();
                }

            } while (true);


        }

        public void Crear()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Datos del Kit =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));

            Console.Write("\nNombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Tiempo en horas: ");

            if (!int.TryParse(Console.ReadLine(), out int tiempo))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            _kitServices.Crear(new Kits
            {
                Nombre = nombre,
                Tiempo = tiempo
            });

            Console.WriteLine("Kit Creada Correctamente, Presiona Enter Para continuar");
            Console.ReadKey();
            Console.Clear();

        }

        public void AgregarPiezaAKit()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Actualizar Kit =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));

            Console.Write("\nNumero de kit: ");

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

            Console.Write("Numero de Pieza o Kit a agregar: ");

            if (!int.TryParse(Console.ReadLine(), out int numeroDePiezaOKit))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            var pieza = _piezaServices.ObtenerPieza(numeroDePiezaOKit);
            var kitAgregar = _kitServices.ObtenerKit(numeroDePiezaOKit);

            if (pieza is null && kitAgregar is null)
            {
                Console.WriteLine("Pieza o Kit no encontrado, Intentalo de Nuevo");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            if (pieza != null)
            {
                kit.AddPieza(pieza);
                Console.WriteLine("Pieza Agregada Correctamente, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            if (kitAgregar != null)
            {
                kit.AddPieza(kitAgregar);
                Console.WriteLine("Kit Agregado Correctamente, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }

        public void Ver()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Datos de los kits =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine();

            if (_kits.Count == 0)
            {
                Console.WriteLine("No hay piezas para mostrar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            for (int i = 0; i < _kits.Count; i++)
            {
                var kit = _kits[i];
                Console.WriteLine($"{kit.NumeroDeKit}.- Nombre: {kit.Nombre} - Precio: ${kit.Precio} - Tiempo: {kit.Tiempo} horas");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void Detalles()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Detalles de un kit =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine();

            Console.Write("\nNumero de kit: ");

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

            Console.WriteLine($"Numero de Kit: {kit.NumeroDeKit}");
            Console.WriteLine($"Nombre: {kit.Nombre}");
            Console.WriteLine($"Precio: ${kit.Precio}");
            Console.WriteLine($"Tiempo: {kit.Tiempo} horas");
            kit.Details();

            Console.ReadKey();
            Console.Clear();
        }
    }
}