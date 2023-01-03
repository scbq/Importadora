using conEmpresa.Clases;
using conEmpresa.Colecciones;

Cotizacion coti1 = new Cotizacion();
Console.WriteLine(coti1.ToString());

Importadora imp1= new Importadora();
Console.WriteLine(imp1.UnidadesPagadas());

Importadora imp2 = new Importadora();
Console.WriteLine(imp2.Buscar("cotizacion"));

Importadora imp3 = new Importadora();
Console.WriteLine(imp3.UnidadesPagadas());