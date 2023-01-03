using conEmpresa.Utiles;
using System;
using System.Text;

namespace conEmpresa.Clases
{
	public class Cotizacion
	{
		//atributos
		private int numeroCotizacion;
		private DateTime fecha;
		private string codigoProductoCotizado;
		private int unidadesCotizadas;
		private string estado;
		protected Rut rut;

		//Propiedades
		public int NumeroCotizacion
		{
			get { return numeroCotizacion; }
			set { numeroCotizacion = value; }
		}

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}

		public string CodigoProductoCotizado
		{
			get { return codigoProductoCotizado; }
			set { codigoProductoCotizado = value; }
		}

		public int UnidadesCotizadas
		{
			get { return unidadesCotizadas; }
			set { unidadesCotizadas = value; }
		}

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		public Rut Rut
		{
			get { return rut; }
			set { rut = value; }
		}

		//Constructores
		//Constructor por defecto
		public Cotizacion() 
		{
			this.rut= new Rut();
			this.fecha = DateTime.Now;
			this.numeroCotizacion= 0;
			this.codigoProductoCotizado = "";
			this.unidadesCotizadas= 0;
			this.estado = "";
		}

		//Con parametros
		public Cotizacion(Rut rut, DateTime fecha,int numeroCotizacion,string codigoProductoCotizado, int unidadesCotizadas, string estado)
		{
			this.rut= new Rut (rut);
			this.fecha= fecha;
			this.numeroCotizacion= numeroCotizacion;
			this.codigoProductoCotizado=codigoProductoCotizado;
			this.unidadesCotizadas= unidadesCotizadas;
			this.estado= estado;
		}

		//Para cargar archivo
		public Cotizacion(string cotizacion)	//No esta dispopnible el txt el orden fue a imaginacion
		{
			string[] campo = cotizacion.Split(',');
			this.numeroCotizacion = int.Parse(campo[0]);
			this.rut= new Rut(campo[2]);
			this.codigoProductoCotizado = campo[3];
			this.unidadesCotizadas = int.Parse(campo[4]);
			this.estado = campo[5];

			string[] fecha = campo[1].Split('-');
			int año, mes, dia;
			int.TryParse(fecha[0], out dia);
			int.TryParse(fecha[1], out mes);
			int.TryParse(fecha[2], out año);
		}

		//Copia
		public Cotizacion(Cotizacion c)
		{
			this.rut = c.rut;
			this.fecha= c.fecha;
			this.numeroCotizacion=c.numeroCotizacion;
			this.codigoProductoCotizado=c.codigoProductoCotizado;
			this.unidadesCotizadas = c.unidadesCotizadas;
			this.estado = c.estado;
		}

        //Sobreescritura
        public override string ToString()
        {
			StringBuilder sb= new StringBuilder();
			sb.Append("---Cotizaciones---");
			sb.Append("\n Numero de cotizacion: ");
			sb.Append(this.numeroCotizacion);
			sb.Append("\n Fecha: ");
			sb.Append(this.fecha);
			sb.Append("\n Rut del Cliente:  ");
			sb.Append(this.rut);
			sb.Append("\n Codigo del Producto: ");
			sb.Append(this.codigoProductoCotizado);
			sb.Append("\n Unidades Cotizadas: ");
			sb.Append(this.unidadesCotizadas);
			sb.Append("\n Estado (Pagada - Pendiente - Rechazada - No asignada)");
			sb.Append(this.estado);
            return sb.ToString();
        }
    }
}

