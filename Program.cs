global using facturacion_taller_p3.Models;
global using facturacion_taller_p3.Service;
global using facturacion_taller_p3.Interface;
global using facturacion_taller_p3.View;


List<Pieza> piezas = new List<Pieza> {
  new Pieza {Nombre = "Prueba", NumeroDePieza = 1, Precio = 10, Tiempo = 5}
};
List<Kits> kits = new List<Kits>();

Inicio inicio = new Inicio(kits, piezas);

inicio.Mostrar();