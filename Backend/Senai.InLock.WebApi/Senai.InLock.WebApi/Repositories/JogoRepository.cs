using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source= DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= INLOCK_GAMES_MANHA; user id= sa; pwd= senai@132 ";
        public void AtualizarUrl(int idJogo, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE JOGOS SET idEstudio = @novoIdEstudio, nomeJogo = @novoNomeJogo, descricao = @novaDescricao, dataLancamento = @novaDataLancamento, valor = @novoValor WHERE idJogo = @idJogoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idjogoAtualizado", idJogo);
                    cmd.Parameters.AddWithValue("@novoIdEstudio", jogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@novoNomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDescricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@novaDataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@novoValor", jogoAtualizado.valor);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectId = "SELECT nomeEstudio ,nomeJogo, descricao, dataLancamento, valor FROM JOGOS LEFT JOIN ESTUDIO ON ESTUDIO.idEstudio = JOGOS.idEstudio WHERE idJogo = @idJogoBuscado";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectId, con))
                {
                    cmd.Parameters.AddWithValue("@idJogoBuscado", idJogo);

                    con.Open();
                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            estudio = new EstudioDomain() { nomeEstudio = rdr[0].ToString()},
                            nomeJogo = rdr[1].ToString(),
                            descricao = rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDecimal(rdr[4])
                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain NovoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO JOGOS (idEstudio, nomeJogo, descricao, dataLancamento, valor) VALUES (@idEstudio, @nomeJogo, @descricao, @dataLancamento, @valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", NovoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@NomeJogo", NovoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", NovoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", NovoJogo.valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM JOGOS WHERE idJogo = @idJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, nomeEstudio, descricao, dataLancamento, valor FROM JOGOS LEFT JOIN ESTUDIO ON ESTUDIO.idEstudio = JOGOS.idEstudio";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            estudio = new EstudioDomain() {nomeEstudio = rdr[1].ToString()},
                            nomeJogo = rdr[2].ToString(),
                            descricao = rdr[3].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[4]),
                            valor = Convert.ToDecimal(rdr[5])
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}
