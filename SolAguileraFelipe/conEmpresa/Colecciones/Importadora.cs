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
            set { nombreImportadora = value;}
        }
        public Rut RutPersona
        {
            get { return rutPersona; }
            set { rutPersona = value; }
        }

        //Constructores
        public Importadora()
        {
            this.nombreImportadora= string.Empty;
            this.rutPersona= new Rut();
            this.cotizaciones= new List<Cotizacion>();
        }
        public Importadora(string nombreImportadora, Rut rutPersona, string archivo)
        {
            this.nombreImportadora = nombreImportadora;
            this.rutPersona = new Rut();
            cotizaciones= new List<Cotizacion>();
            CargaArchivos(archivo);
        }

        //Metodo para Cargar txt
        public bool CargaArchivos(string arch)
        {
            try
            {
                FileStream f = new FileStream(arch, FileMode.Open, FileAccess.Read);
                StreamReader rf = new StreamReader(f);
                string[] campo;
                string linea;

                while (!rf.EndOfStream)
                {
                    linea = rf.ReadLine();
                    campo = linea.Split(',');
                }
                rf.Close();
                f.Close();
                return true;
            }
            catch (Exception ex)
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

            foreach (Cotizacion rutper in cotizaciones)
            {
                sb.Append("\n" + rutper.ToString() + "\n");
            }
            return sb.ToString();
        }

        //Metodos Propios
        public void Agregar(Cotizacion cotizacion)
        {
            cotizaciones.Add(cotizacion);
        }

        public void Buscar(string cotiz)
        {
            bool existe = false;

            for (int i = 0; i < cotizaciones.Count; i++)
            {
                if (cotizaciones[i].NumeroCotizacion.Equals(cotiz))
                {
                    existe = true;
                    Console.WriteLine(cotizaciones[i].ToString());
                }
            }
            if (existe)
            {
                Console.WriteLine("La cotizacion existe");
            }
            else
            {
                Console.WriteLine("La cotizacion NO existe");
            }
        }
        public void UnidadesPagadas(Cotizacion cotiz)
        {
            foreach (var varAux in cotizaciones)
            {
                Console.WriteLine(varAux);
            }
            Console.ReadKey();
        }

    }
}
