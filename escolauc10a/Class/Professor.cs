using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace escolauc10a.Class
{
    class Professor
    {
        public Professor()
        {

        }
        public Professor(string nome, string email, string cpf, string telefone)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
        }
        public Professor(int id, string nome, string email, string cpf, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        public List<Professor> ObterProfessores()
        {
            List<Professor> Lista = new List<Professor>();

            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM professor";

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Lista.Add(new Professor(
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4)
                        ));
                }
            }

            return Lista;
        }
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandText = "INSERT professor (nome, cpf, email, telefone)" +
                    " VALUES ('" + Nome + "','" + Cpf + "','" + Email + "','" + Telefone + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";

                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public void BuscarPorId(int id)
        {
            var cmd = Banco.Abrir();

            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM professor WHERE id = " + id;

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Nome = dr.GetString(1);
                    Cpf = dr.GetString(2);
                    Email = dr.GetString(3);
                    Telefone = dr.GetString(4);
                }
            }
        }
    }
}
