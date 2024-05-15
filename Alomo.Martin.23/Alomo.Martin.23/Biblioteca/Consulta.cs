namespace Biblioteca
{
    public class Consulta
    {
        private DateTime fecha;
        private Paciente paciente;


        public Consulta(DateTime fecha, Paciente paciente)
        {
            this.fecha = fecha;
            this.paciente = paciente;
        }


        public DateTime Fecha
        {
            get { return fecha; }
        }

        protected Paciente Paciente
        {
            get { return paciente; }
        }


        public override string ToString()
        {
            return $"{Fecha} se ha atendido a {paciente.NombreCompleto}";
        }



    }
}
