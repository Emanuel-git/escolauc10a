using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace escolauc10a.Class
{
    public class Aluno
    {
        // construtores
        public Aluno()
        {

        }
        public Aluno(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public Aluno(int id, string nome, string email, string senha, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }

        // propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        // métodos de negócio (inserir/alterar...)
        public List<Aluno> ObterAlunos()
        {
            List<Aluno> lista = new List<Aluno>();

            // recheio...
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM alunos";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Aluno(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetBoolean(4)
                        ));
                }
            }

            return lista;
        }
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandText = "INSERT alunos (nome, email, senha, ativo)" +
                    " VALUES ('"+Nome+"','"+Email+"',MD5('"+Senha+"'),DEFAULT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";

                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            
        }
        public bool Atualizar()
        {
            try
            {
                var cmd = Banco.Abrir();

                cmd.CommandText = "UPDATE alunos SET nome = '" + Nome + "', senha = MD5('" + Senha + "'), ativo = " + Ativo + " WHERE id = " + Id;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;

                throw e;
            }
            
        }
        public void BuscarPorId(int id)
        {
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM alunos WHERE id = " + id;

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Nome = dr.GetString(1);
                    Email = dr.GetString(2);
                    Ativo = dr.GetBoolean(4);
                }
            }
        }
    }
}
