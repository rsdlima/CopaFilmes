using CopaFimes.Domain.Model;
using CopaFimes.Domain.Services;
using System;
using Xunit;

namespace CopaFilmeTests
{
    public class DisputaTest
    {
        [Theory]
        [ClassData(typeof(FilmesTestData))]
        public static void VerificaVencedorCorreto(Filme filmeA, Filme filmeB, Filme filmeVencedor)
        {
            //arrange
            Disputas disputas = new Disputas();
            //act
            bool vencedorCorreto = filmeVencedor.Id == disputas.Disputa(filmeA, filmeB).Id;
            //asert
            Assert.True(vencedorCorreto);
        }        

    }
}
