using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório JopgoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Retorna todos os jogos
        /// </summary>
        /// <returns></returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto do tipo jogoDomain que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);


        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="idJogo">id do jogo que será deletado</param>
        void Deletar(int idJogo);


        /// <summary>
        /// Busca um jogo por id
        /// </summary>
        /// <param name="idJogo">id do jogo que será buscado</param>
        /// <returns></returns>
        JogoDomain BuscarId(int idJogo);

        void AtualizarUrl(int idJogo, JogoDomain jogoAtualizado);

    }
}
