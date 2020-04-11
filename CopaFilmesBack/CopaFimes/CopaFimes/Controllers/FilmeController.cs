using CopaFimes.Domain.Model;
using CopaFimes.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        [EnableCors("ApiCorsPolicy")]
        public ActionResult<string> Buscar()
        {

            return _filmeService.Buscar();
        }

        [HttpPost]
        [EnableCors("ApiCorsPolicy")]
        public ActionResult<List<Filme>> ComecarCopa([FromBody] List<Filme> filmes)
        {
            return _filmeService.ExecutarCopa(filmes);
        }
    }
}
