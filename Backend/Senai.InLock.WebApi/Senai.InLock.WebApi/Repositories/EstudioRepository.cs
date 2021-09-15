using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source= DESKTOP-TUQ4VJR\\SQLEXPRESS; initial catalog= INLOCK_GAMES_MANHA; user id= sa; pwd= senai@132 ";
     
        public List<EstudioDomain> ListarEstudiosJogos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            //List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM ESTUDIO;";
               

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        List<JogoDomain> listaJogos = new List<JogoDomain>();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString(),
                        };

                        using(SqlConnection con2 = new SqlConnection(stringConexao))
                        {
                            string querySelectGames = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM JOGOS WHERE idEstudio = @idEstudio";

                            con2.Open();

                            SqlDataReader rdrGames;

                            using(SqlCommand cmdGames = new SqlCommand(querySelectGames, con2))
                            {
                                cmdGames.Parameters.AddWithValue("@idEstudio", estudio.idEstudio);

                                rdrGames = cmdGames.ExecuteReader();

                                while(rdrGames.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        idJogo = Convert.ToInt32(rdrGames[0]),
                                        nomeJogo = rdrGames[1].ToString(),
                                        descricao = rdrGames[2].ToString(),
                                        dataLancamento = Convert.ToDateTime(rdrGames[3]),
                                        valor = Convert.ToDecimal(rdrGames[4])
                                    };

                                    listaJogos.Add(jogo);
                                }
                            }

                            estudio.listaJogos = listaJogos;
                            listaEstudio.Add(estudio);

                        }

                       
                    }

                    
                } 
             return listaEstudio;
            }
        }



        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeEstudio FROM ESTUDIO";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            nomeEstudio = rdr[0].ToString()
                        };

                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }}

    


