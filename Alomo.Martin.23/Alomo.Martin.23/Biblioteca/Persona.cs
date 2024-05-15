using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        protected DateTime nacimiento;
        protected string barrioResidencia;


        public Persona(string nombre, string apellido, DateTime nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
            barrioResidencia = "No ingresado";
        }

        public Persona(string nombre, string apellido, DateTime nacimiento, string barrioResidencia) : this(nombre, apellido, nacimiento)
        {
            this.barrioResidencia = barrioResidencia;
        }


        public string NombreCompleto
        {
            get { return $"{apellido}, {nombre}"; }
        }

        public int Edad
        {
            get { return DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1; }
        }


        public override string ToString()
        {
            return NombreCompleto;
        }

        public static string FichaPersonal(Persona persona)
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(persona.NombreCompleto)
                .AppendLine($"EDAD: {persona.Edad}")
                .AppendLine($"{persona.FichaExtra()}")    //      {Datos del objeto instanciado}
                ;
            return text.ToString();
        }

        internal abstract string FichaExtra();





    }
}
