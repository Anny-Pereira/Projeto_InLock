using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]

    //TESTAR EM BREVE
    //[Authorize]

    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudioRepository();
        }

        [HttpGet("Jogos")]
        public IActionResult GetJogos()
        {
            try
            {
                return Ok(_EstudioRepository.ListarEstudiosJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _EstudioRepository.ListarTodos();
                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
