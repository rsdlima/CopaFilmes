using CopaFimes.Domain.Model;
using CopaFimes.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CopaFimes.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        public string Buscar()
        {
            ConectarApiExterna apiExterna = new ConectarApiExterna("http://copafilmes.azurewebsites.net/api/filmes");
            return apiExterna.Buscar();
        }
        public List<Filme> ExecutarCopa(List<Filme> filmes)
        {
            filmes = filmes.OrderBy(x => x.Titulo).ToList();
            Disputas disputa = new Disputas();
            List<Filme> classificadosPrimeiraFase = new List<Filme>();
            List<Filme> classificadosSegundaFase = new List<Filme>();
            List<Filme> campeoes = new List<Filme>();
            int indiceConcorrenteA = 0;
            int indiceConcorrenteB = filmes.Count - 1;

            foreach (Filme filme in filmes)
            {
                if (indiceConcorrenteA > 3)
                    break;
                classificadosPrimeiraFase.Add(disputa.Disputa(filmes[indiceConcorrenteA], filmes[indiceConcorrenteB]));
                indiceConcorrenteA++;
                indiceConcorrenteB--;

            }
            classificadosPrimeiraFase = classificadosPrimeiraFase.OrderBy(x => x.Titulo).ToList();
            classificadosSegundaFase.Add(disputa.Disputa(classificadosPrimeiraFase[0], classificadosPrimeiraFase[3]));
            classificadosSegundaFase.Add(disputa.Disputa(classificadosPrimeiraFase[1], classificadosPrimeiraFase[2]));

            classificadosSegundaFase = classificadosSegundaFase.OrderBy(x => x.Titulo).ToList();
            campeoes.Add(disputa.Disputa(classificadosSegundaFase[0], classificadosSegundaFase[1]));
            campeoes.Add(classificadosSegundaFase.Where(x => x.Id != campeoes[0].Id).First());
            return campeoes;
        }
    }
}