using CopaFimes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFimes.Interfaces
{
    public interface IFilmeService
    {
        string Buscar();

        List<Filme> ExecutarCopa(List<Filme> filmes);
        

    }
}
