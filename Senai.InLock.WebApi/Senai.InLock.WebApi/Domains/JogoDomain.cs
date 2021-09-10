using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "Por favor, informe a qual estúdio este Jogo pertence!")]
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "O nome do Jogo é Obrigatório!")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "Uma Descrição é necessária para o Jogo!")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Por Favor, informe a data de lançamento!")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor do Jogo!")]
        public decimal valor { get; set; }
        public EstudioDomain estudio { get; set; }
    }
}
