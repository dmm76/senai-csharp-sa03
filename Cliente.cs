using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD
{
    public class Cliente
    {
        public int Id { get; set; }

        public string nome { get; set; }

        public string celular { get; set; }

        public string email { get; set; }

        public string cidade { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\SENAI_APP\\PROJETO_DE_APLICATIVO_SENAI-20240805T144822Z-001\\PROJETO_DE_APLICATIVO_SENAI\\CRUD\\DbCliente.mdf;Integrated Security=True");
    
        /* METODOS */
        
        public List<Cliente> Listacliente()
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM Cliente";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente cli = new Cliente();
                cli.Id = (int)dr["id"];
                cli.nome = dr["nome"].ToString();
                cli.celular = dr["celular"].ToString();
                cli.email = dr["email"].ToString();
                cli.cidade  = dr["cidade"].ToString();
                li.Add(cli);

            }
            return li;
        }
        
        public void Inserir(string nome, string celular, string email, string cidade)
        {
            try
            {
                string sql = "INSERT INTO Cliente(nome, celular, email, cidade) VALUES ('" + nome + "','" + celular + "','" + email + "','" + cidade + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                
            }
        }
        public void Atualizar(int Id, string nome, string celular, string email, string cidade)
        {
            try
            {
                string sql = "UPDATE Cliente SET '" + nome + "','" + celular + "','" + email + "','" + cidade + "' WHERE Id='"+Id+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }
        public void Excluir(int Id)
        {
            try
            {
                string sql = "DELETE FROM  Cliente WHERE Id='" + Id+ "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }

        public void Localiza(int Id)
        {
            
           string sql = "SELECT * FROM  Cliente WHERE Id='" + Id + "'";
           con.Open();
           SqlCommand cmd = new SqlCommand(sql, con);
           SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
             {
               nome = dr["nome"].ToString();
               celular = dr["celular"].ToString();
               email = dr["email"].ToString();
              cidade = dr["cidade"].ToString();
             }
            con.Close();
            
        }

        public bool RegistroRepetido(string nome, string email)
        {
            string sql = "SELECT * FROM Cliente WHERE nome='"+nome+"' AND email='"+email+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if(result != null) {
                return (int) result > 0 ;
            }
            con.Close();
            return false;
        }

    }
}
