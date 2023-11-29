namespace facturacion_taller_p3.View
{
    public class PiezasView
    {
        string[] inicioOpciones = { "Crear Pieza", "Actualizar Pieza", "Ver Piezas", "Regresar" };
        int windowsWidth = Console.WindowWidth;
        public PiezaServices _piezaServices { get; }
        public List<Pieza> _piezas { get; }

        public PiezasView(List<Pieza> piezas)
        {
            _piezas = piezas;
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
                        Actualizar();
                        break;
                    case 3:
                        Ver();
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
            Console.WriteLine("==== Datos de la Pieza =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));

            Console.Write("\nNombre: ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Precio: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Write("Tiempo en horas: ");

            if (!int.TryParse(Console.ReadLine(), out int tiempo))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            _piezaServices.Crear(new Pieza
            {
                Nombre = nombre,
                Precio = precio,
                Tiempo = tiempo
            });

            Console.WriteLine("Pieza Creada Correctamente, Presiona Enter Para continuar");
            Console.ReadKey();
            Console.Clear();

        }

        public void Actualizar()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Actualizar Pieza =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));

            Console.Write("\nNumero de pieza: ");

            if (!int.TryParse(Console.ReadLine(), out int numeroDePieza))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.Write("Nuevo Precio: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.WriteLine("Numero no valido Intentalo de Nuevo, Presiona Enter Para continuar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            try
            {
                _piezaServices.Actualizar(numeroDePieza, precio);
                Console.WriteLine("Pieza Actualizada Correctamente, Presiona Enter Para continuar");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo encontrar la pieza, Presiona Enter Para continuar");

            }
            finally
            {
                Console.ReadKey();
                Console.Clear();
            }


        }

        public void Ver()
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine("==== Datos de la Pieza =".PadRight(windowsWidth, '='));
            Console.WriteLine("=".PadRight(windowsWidth, '='));
            Console.WriteLine();

            if (_piezas.Count == 0)
            {
                Console.WriteLine("No hay piezas para mostrar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            for (int i = 0; i < _piezas.Count; i++)
            {
                var pieza = _piezas[i];
                Console.WriteLine($"{pieza.NumeroDePieza}.- Nombre: {pieza.Nombre} - Precio: ${pieza.Precio} - Tiempo: {pieza.Tiempo} horas");
            }

            Console.ReadKey();
            Console.Clear();
        }

    }
}