using CopaFimes.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmeTests
{
    public class FilmesTestData : IEnumerable<object[]>
    {
        public IEnumerator<Object[]> GetEnumerator()
        {
            yield return new object[] {
                new Filme
                {
                    Id="1",
                    Titulo ="A espera de um milagre",
                    Ano = 1999,
                    Nota = 10
                },
                new Filme
                {
                    Id="2",
                    Titulo ="Matrix",
                    Ano = 1999,
                    Nota = 9.5
                },
                new Filme
                {
                 Id = "1"
                },
                };

            yield return new object[] {
                new Filme
                {
                    Id="1",
                    Titulo ="A espera de um milagre",
                    Ano = 1999,
                    Nota = 10
                },
                new Filme
                {
                    Id="2",
                    Titulo ="Matrix",
                    Ano = 1999,
                    Nota = 10
                },
                new Filme
                {
                 Id = "1"
                },
                };

            yield return new object[] {
                new Filme
                {
                    Id="1",
                    Titulo ="A espera de um milagre",
                    Ano = 1999,
                    Nota = 9
                },
                new Filme
                {
                    Id="2",
                    Titulo ="Matrix",
                    Ano = 1999,
                    Nota = 9.5
                },
                new Filme
                {
                 Id = "2"
                },
                };


        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
