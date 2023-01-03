using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conEmpresa.Utiles
{
    public class Rut
    {
        //Atributos
        private int numero;
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private char dVerificador;
        public char DVerificador
        {
            get { return dVerificador; }
            set { dVerificador = value; }
        }


        public Rut()
        {
            this.numero = 0;
            this.dVerificador = '0';
        }

        //dddddddd o ddddddd
        public Rut(int r)
        {
            this.numero = r;
            this.dVerificador = CalcularDV();
        }

        //dddddddd-c  o  ddddddd-c
        public Rut(String r)
        {
            String[] datos;
            datos = r.Split('-');
            if (datos.Length == 0)
            {
                //Error. Dejamos el Rut 0-0
                numero = 0;
                this.dVerificador = '0';
            }
            else
            {
                int.TryParse(datos[0], out numero);
                this.dVerificador = datos[1][0];
            }

            //Error. Dejamos el Rut 0-0
            if (!EsValido())
            {
                numero = 0;
                this.dVerificador = '0';
            }
        }


        public Rut(Rut r)
        {
            this.numero = r.numero;
            this.dVerificador = r.dVerificador;
        }

        public bool EsValido()
        {
            return this.dVerificador == CalcularDV();
        }

        public char CalcularDV()
        {
            int num = numero;
            int factor = 2;
            int suma = 0;
            int digito;

            while (num > 0)
            {
                digito = num % 10;
                suma = suma + digito * factor;
                factor++;
                if (factor > 7)
                {
                    factor = 2;
                }
                num = num / 10;
            }
            int dv = 11 - suma % 11;

            char cDV;

            switch (dv)
            {
                case 11:
                    cDV = '0';
                    break;
                case 10:
                    cDV = 'K';
                    break;
                default:
                    cDV = (char)(48 + dv);
                    break;
            }
            return cDV;
        }

        public override String ToString()
        {
            return numero + "-" + dVerificador;
        }

        //Dos objetos de la clase Rut son iguales si sus números son iguales.
        public override bool Equals(Object obj)
        {
            if (obj != null && obj is Rut)
            {
                Rut r = (Rut)obj;
                return this.numero == r.numero;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
