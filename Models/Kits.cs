namespace facturacion_taller_p3.Models
{
    public class Kits : ItemFacturable
    {
        public int NumeroDeKit { get; set; } = 0;
        public List<ItemFacturable> Piezas { get; set; } = new List<ItemFacturable>();
        public override decimal Precio
        {
            get
            {
                decimal rawTotal = Piezas.Sum(p => p.Precio);
                decimal discount = rawTotal * (decimal)0.10;
                decimal total = rawTotal - discount;
                return total;
            }
            set
            {
                throw new NotImplementedException("No se puede modificar el precio de kits");
            }
        }

        public void AddPieza(ItemFacturable pieza)
        {
            Piezas.Add(pieza);
        }

        public void Details()
        {
            Console.WriteLine("Piezas del Kit");

            if (Piezas.Count == 0)
            {
                Console.WriteLine("No hay piezas para mostrar");
                return;
            }

            for (int i = 0; i < Piezas.Count; i++)
            {
                Console.WriteLine($"{Piezas[i].Nombre} - Precio: ${Piezas[i].Precio} - Tiempo: {Piezas[i].Tiempo} horas");
            }

        }
    }
}