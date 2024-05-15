using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Vista
{
    public partial class FrmAtencion : Form
    {
        public FrmAtencion()
        {
            InitializeComponent();
        }

        private void FrmAtencion_Load(object sender, EventArgs e)
        {
            lstMedicos.Items.Add(new PersonalMedico("Gustavo", "Rivas", new DateTime(1999, 12, 12), false));
            lstMedicos.Items.Add(new PersonalMedico("Lautaro", "Galarza", new DateTime(1951, 11, 12), true));
            lstPacientes.Items.Add(new Paciente("Mathias", "Bustamante", new DateTime(1998, 6, 16), "Tigre"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Ferrini", new DateTime(1989, 1, 21), "DF"));
            lstPacientes.Items.Add(new Paciente("Lucas", "Rodriguez", new DateTime(1912, 12, 12), "LaBoca"));
            lstPacientes.Items.Add(new Paciente("John Jairo", "Trelles", new DateTime(1978, 8, 30), "Medellin"));
        }

        private void FrmAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        private void btnAtender_Click(object sender, EventArgs e)
        {
            int indiceMedico = lstMedicos.SelectedIndex;
            int indicePaciente = lstPacientes.SelectedIndex;
            if (indiceMedico >= 0 && indicePaciente >= 0)
            {
                PersonalMedico doctorElegido = (PersonalMedico)lstMedicos.SelectedItem;
                Paciente pacienteElegido = (Paciente)lstPacientes.SelectedItem;
                Consulta consultaNueva = doctorElegido + pacienteElegido;
                pacienteElegido.Diagnostico = "Curado";

                MessageBox.Show($"{consultaNueva.ToString()}{Environment.NewLine}{Paciente.FichaPersonal(pacienteElegido)}", "Atención finalizada", MessageBoxButtons.OK);
                rtbInfoMedico.Text = PersonalMedico.FichaPersonal(doctorElegido);
                lstMedicos.SelectedIndex = -1;
                lstPacientes.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Medico y un Paciente para poder continuar.", "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceMedico = lstMedicos.SelectedIndex;
            if (indiceMedico >= 0)
            {
                PersonalMedico doctorElegido = (PersonalMedico)lstMedicos.SelectedItem;
                rtbInfoMedico.Text = PersonalMedico.FichaPersonal(doctorElegido);
            }
        }





    }
}
