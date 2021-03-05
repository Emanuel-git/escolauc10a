using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using escolauc10a.Class;

namespace escolauc10a.Forms
{
    public partial class FrmProfessor : Form
    {
        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Professor professor = new Professor();

            var lista = professor.ObterProfessores();

            foreach (var lecionador in lista)
            {
                listBox1.Items.Add(lecionador.Nome + " - " + lecionador.Email + " - " + lecionador.Cpf + " - " + lecionador.Telefone);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor(txtNome.Text,txtCpf.Text,txtEmail.Text,txtTel.Text);

            professor.Inserir();

            txtId.Text = professor.Id.ToString();
        }
    }
}
