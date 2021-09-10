using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source= DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= INLOCK_GAMES_MANHA; user id= sa; pwd= senai@132 ";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = "SELECT idUsuario, email, senha, tituloTipoUsuario FROM USUARIO LEFT JOIN TIPOUSUARIO ON USUARIO.idTipoUsuario = TIPOUSUARIO.idTipoUsuario WHERE email = @email AND senha = @senha";

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            tipoUsuario = new TipoUsuarioDomain() { tituloTipoUsuario = rdr["tituloTipoUsuario"].ToString()}
                        };

                        return usuario;
                    }

                    return null;
                }
            }
        }
    }
}


