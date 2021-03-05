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
    public partial class FrmAluno : Form
    {
        public FrmAluno()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            Aluno aluno = new Aluno();

            var lista = aluno.ObterAlunos();

            foreach (var estudante in lista)
            {
                if (estudante.Ativo)
                {
                    listBox3.Items.Add(estudante.Id + " - " + estudante.Nome + " - " + estudante.Email + " - " + estudante.Senha);
                }           
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtNome.Text,txtEmail.Text,txtSenha.Text);

            aluno.Inserir();

            txtId.Text = aluno.Id.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();

                button9.Text = "Buscar";
                btnAdd.Enabled = false;
            }
            else if (button9.Text == "Buscar")
            {
                txtId.ReadOnly = true;
                button9.Text = "...";
                button8.Enabled = true;

                Aluno aluno = new Aluno();

                aluno.BuscarPorId(int.Parse(txtId.Text));

                txtNome.Text = aluno.Nome;
                txtEmail.Text = aluno.Email;
                txtEmail.Enabled  = false;
                chkAtivo.Checked = aluno.Ativo;
                chkAtivo.Enabled = true;
                txtSenha.Text = "";
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();

            aluno.Id = int.Parse(txtId.Text);
            aluno.Nome = txtNome.Text;
            aluno.Email = txtEmail.Text;
            aluno.Senha = txtSenha.Text;
            aluno.Ativo = chkAtivo.Checked;

            if (aluno.Atualizar())
            {
                txtId.Clear();
                txtNome.Clear();
                txtEmail.Clear();
                txtSenha.Clear();

                MessageBox.Show("Aluno atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro!");
            }
        }
    }
}
