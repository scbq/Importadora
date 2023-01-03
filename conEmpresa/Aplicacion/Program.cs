using conEmpresa.Clases;
using conEmpresa.Colecciones;
using conEmpresa.Utiles;
using System.Collections;

internal class Program
{
    //Felipe Aguilera Fuentealba Rut:15771527-5
    private static void Main(string[] args)
    {
        Rut rut = new Rut(157715275);
        Importadora miImportadora = new Importadora("Mi Importadora", rut, "cotizaciones.txt");

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("---Importadora---");
            Console.WriteLine("1.- Mostrar Cotizaciones");
            Console.WriteLine("2.- Agregar Cotizacion");
            Console.WriteLine("3.- Buscar Numero de Cotizacion");
            Console.WriteLine("4.- Cotizaciones Pendientes");
            Console.WriteLine("5.- Unidades Pagadas");
            Console.WriteLine("0.- Para Salir");
            Console.Write("Ingrese una opcion: ");
            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    Console.WriteLine(miImportadora.ToString());
                    Console.ReadKey();
                    break;

                case 2:
                    miImportadora.Agregar(AgregaCotizacion());
                    Console.ReadKey();
                    break;

                case 3:
                    int buscar;
                    Console.WriteLine("Ingrese un numero de cotizacion: ");
                    buscar = int.Parse(Console.ReadLine());
                    miImportadora.Buscar(buscar);
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Cotizaciones Pendientes:  " + miImportadora.Pendientes());
                    Console.ReadKey();
                    break;

                case 5:
                    Console.WriteLine("Cotizaciones Pagadas:  " + miImportadora.UnidadesPagadas());
                    Console.ReadKey();
                    break;
            }
        }
        while (opcion != 0);
    }

    private static string AgregaCotizacion()
    {
        Console.Clear();
        string nCotizacion, fecha, rut, cProducto, unidades, estado;
        bool cotiza = false;
        if (cotiza.Equals(string.Empty))
        {
            Console.WriteLine("No corresponde a una Cotizacion");
            Console.ReadKey();
            return string.Empty;
        }
        else
        {
            Console.WriteLine("---Nueva Cotizacion---");
            Console.Write("Ingrese Numero de Cotizacion: ");
            nCotizacion = Console.ReadLine();
            Console.Write("Ingrese Fecha (dd/mm/aa): ");
            fecha = Console.ReadLine();
            Console.Write("Ingrese Rut (sin punto ni digito verificador): ");
            rut = Console.ReadLine();
            Console.Write("Ingrese Codigo del Producto Cotizado: ");
            cProducto = Console.ReadLine();
            Console.Write("Ingrese numero de Unidades Cotizadas: ");
            unidades = Console.ReadLine();
            Console.Write("Ingrese Estado (Pagada-Pendiente-Rechazada-No asignada): ");
            estado = Console.ReadLine();
            cotiza = true;
            return nCotizacion + "," + fecha + "," + rut + "," + cProducto + "," + unidades + "," + estado;
        }
    }
}