using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Digite seu E-Mail, Por favor!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Digite sua Senha, Por favor!")]
        public string senha { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
