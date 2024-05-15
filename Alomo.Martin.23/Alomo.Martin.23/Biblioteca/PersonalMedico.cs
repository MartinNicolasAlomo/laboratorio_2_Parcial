using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Biblioteca
{
    public sealed class PersonalMedico : Persona
    {
        private List<Consulta> consultas;
        private bool esResidente;


        public PersonalMedico(string nombre, string apellido, DateTime nacimiento, bool esResidente)
             : base(nombre, apellido, nacimiento)
        {
            consultas = new List<Consulta>();
            this.esResidente = esResidente;
        }


        internal override string FichaExtra()
        {
            string terminoResidencia = esResidente ? "SI" : "NO";

            StringBuilder text = new StringBuilder();
            text/*.AppendLine($"{FichaPersonal(this)}")*/
                .AppendLine($"¿Finalizó la residencia? {terminoResidencia}")
                .AppendLine().AppendLine($"ATENCIONES:");
            foreach (Consulta consulta in consultas)
            {
                text.AppendLine(consulta.ToString());
            }
            return text.ToString();
        }


        public static Consulta operator +(PersonalMedico doctor, Paciente paciente)
        {
            Consulta consultaNueva = new Consulta(DateTime.Now, paciente);
            doctor.consultas.Add(consultaNueva);
            return consultaNueva;
        }



    }
}
