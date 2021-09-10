using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]


    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }



        /// <summary>
        /// Autentica um usuário
        /// </summary>
        /// <param name="usuarioLogado"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult LoginPost(UsuarioDomain usuarioLogado)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.Login(usuarioLogado.email, usuarioLogado.senha);

            if (usuarioBuscado != null)
            {
                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim( ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inLock-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLock.WebApi",

                    audience: "InLock.WebApi",

                    claims: minhasClaims,

                    expires: DateTime.Now.AddHours(1),

                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

               
            }

            return NotFound("Email ou senha inválidos");
        }
    }
}
