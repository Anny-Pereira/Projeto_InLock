using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    // [Authorize]



    public class JogosController : ControllerBase
    {

        private IJogoRepository _JogoRepository { get; set; }


        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }
    }
}
