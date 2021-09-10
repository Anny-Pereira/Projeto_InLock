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

    
    [Authorize]



    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }


        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1, 2")]    
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogos = _JogoRepository.ListarTodos();
                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [Authorize(Roles =  "1")] 
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _JogoRepository.Cadastrar(novoJogo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Deleta um jogo pelo seu id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        [Authorize(Roles =  "1")]   
        [HttpDelete("{idJogo}")]
        public IActionResult Delete(int idJogo)
        {
            JogoDomain jogoBuscado = _JogoRepository.BuscarId(idJogo);

            if (jogoBuscado != null)
            {
                try
                {
                    _JogoRepository.Deletar(idJogo);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Nenhum jogo foi encontrado!");
           
        }


        /// <summary>
        /// Busca um jogo pelo seu id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        [Authorize(Roles =  "1, 2")]     
        [HttpGet("{idJogo}")]
        public IActionResult GetById(int idJogo)
        {
            try
            {
                JogoDomain jogoBuscado = _JogoRepository.BuscarId(idJogo);
                return Ok(jogoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Atualiza um jogo através de seu id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <param name="jogoDomain"></param>
        /// <returns></returns>
        [Authorize(Roles = "1, 2")]      
        [HttpPut("{idJogo}")]
        public IActionResult Put(int idJogo, JogoDomain jogoDomain)
        {
            try
            {
                _JogoRepository.AtualizarUrl(idJogo, jogoDomain);
                return Ok(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
