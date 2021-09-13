using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "O nome do Estúdio é Obrigatório!")]
        public string nomeEstudio { get; set; }

        public List<JogoDomain> listaJogos { get; set; }

        
    }
}
