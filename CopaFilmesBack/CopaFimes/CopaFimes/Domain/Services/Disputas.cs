using CopaFimes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFimes.Domain.Services
{
    public class Disputas
    {
        public Filme Disputa(Filme concorrenteA, Filme concorrenteB)
        {
            if (concorrenteA.Nota - concorrenteB.Nota < 0)
                return concorrenteB;
            else
                return concorrenteA;
        }
    }
}
