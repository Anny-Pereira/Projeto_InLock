using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns></returns>
        List<EstudioDomain> ListarTodos();

        List<EstudioDomain> ListarEstudiosJogos();
    }
}
