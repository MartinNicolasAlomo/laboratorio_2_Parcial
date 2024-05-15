using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public sealed class Paciente : Persona
    {
        private string diagnostico;


        public Paciente(string nombre, string apellido, DateTime nacimiento, string barrioResidencia/*, string diagnostico*/)
             : base(nombre, apellido, nacimiento, barrioResidencia)
        {
            //this.diagnostico = diagnostico;
        }


        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }


        internal override string FichaExtra()
        {
            StringBuilder text = new StringBuilder();
            text/*.AppendLine($"{FichaPersonal(this)}")*/
                .AppendLine($"Reside en: {barrioResidencia}")
                .AppendLine($"{diagnostico}")
                ;
            return text.ToString();
        }



    }
}
