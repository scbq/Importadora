using conEmpresa.Clases;
using conEmpresa.Utiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conEmpresa.Colecciones
{
    //Felipe Aguilera Fuentealba Rut:15771527-5
    public class Importadora
    {
        //Atrivutos
        private string nombreImportadora;
        private Rut rutPersona;
        private List<Cotizacion> cotizaciones;

        //Propiedades
        public string NombreImportadora
        {
            get { return nombreImportadora; }
            set { nombreImportadora = value; }
        }
        public Rut RutPersona
        {
            get { return rutPersona; }
            set { rutPersona = value; }
        }

        //Constructores
        public Importadora()
        {
            this.nombreImportadora = string.Empty;
            this.rutPersona = new Rut();
            this.cotizaciones = new List<Cotizacion>();
        }
        public Importadora(string nombreImportadora, Rut rutPersona, string archivo)
        {
            this.nombreImportadora = nombreImportadora;
            this.rutPersona = new Rut();
            cotizaciones = new List<Cotizacion>();
            CargaArchivo(archivo);
        }

        //Metodo para Cargar txt
        private bool CargaArchivo(string arch)
        {
            try
            {
                FileStream f = new FileStream(arch, FileMode.Open, FileAccess.Read);
                StreamReader sf = new StreamReader(f);
                string linea;
                Cotizacion co;
                int tipo;

                while (!sf.EndOfStream)
                {
                    linea = sf.ReadLine();
                    tipo = linea[0];
                    linea = linea.Substring(0);

                    if (tipo == 0)
                    {
                        Console.WriteLine("No existe");
                    }
                    else
                    {
                        co = new Cotizacion(linea);
                        cotizaciones.Add(co);
                    }

                }
                sf.Close();
                f.Close();
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-----Importadora-----");
            sb.Append("\n Nombre de la Iportadora:  ");
            sb.Append(this.nombreImportadora);
            sb.Append("\n Rut de la Persona: ");
            sb.Append(this.rutPersona);

            foreach (Cotizacion rutper in cotizaciones)
            {
                sb.Append("\n" + rutper.ToString() + "\n");
            }
            return sb.ToString();
        }
        public bool Agregar(string str)
        {
            if (str.Equals(string.Empty))
            {
                Console.WriteLine("Cotizacion NO ingresada");
                return false;
            }
            else
            {
                Console.WriteLine("Cotizacion ingresada con exito!!!");
                return true;
            }
        }

        public bool Buscar(int nro)
        {
            bool existe = false;
            foreach (Cotizacion t in cotizaciones)
            {
                if (t.NumeroCotizacion == nro)
                {
                    existe = true;
                    Console.WriteLine("La cotizacion existe");
                    return true;
                }
                else
                {
                    existe = false;
                    Console.WriteLine("La cotizacion NO existe");
                    return false;
                }
            }
            return existe;
        }
        public bool UnidadesPagadas(Cotizacion cotiz)
        {
            foreach (var varAux in cotizaciones)
            {
                Console.WriteLine(varAux);
            }
            Console.ReadKey();
            return true;
        }
        public int Pendientes()
        {
            ArrayList pendientes = new ArrayList();
            int total = 0;

            foreach(Cotizacion c in cotizaciones)
            {
                if (c.Estado.Contains("Pendiente"))
                {
                    pendientes.Add("Pendientes" + c);
                    total++;
                }
            }
            return total;
        }
        public int UnidadesPagadas()
        {
            int total = 0;
            foreach (Cotizacion t in cotizaciones)
            {
                if (t.Estado.Contains("Pagada"))
                {
                    total++;
                }
            }
            return total;
        }
    }
}

