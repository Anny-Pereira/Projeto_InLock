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
                string querySelectAll = "SELECT nomeEstudio, nomeJogo FROM ESTUDIO LEFT JOIN JOGOS ON ESTUDIO.idEstudio = JOGOS.idEstudio;";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            nomeEstudio = rdr[0].ToString(),

                            jogoDomain = new List<JogoDomain>()
                            {
                                JogoDomain novojogo = new JogoDomain()
                                {
                                    nomeJogo = rdr[1].ToString()
                                }
                                
                            }
                            
                           
                        };

                        listaEstudio.Add(estudio);
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

    


