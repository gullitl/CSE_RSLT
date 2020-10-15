using System;
using System.Collections.Generic;

namespace LAB03AritmeticaApp
{
    public class ServiceAritmetica
    {
        public string AcharIntervadoNumero(double numero, (double a, double b, double c, double d) extremidade)
        {
            double extremidadeA = extremidade.a < extremidade.b ? extremidade.a : extremidade.b;
            double extremidadeB = extremidade.b > extremidade.a ? extremidade.b : extremidade.a;
            double extremidadeC = extremidade.c < extremidade.d ? extremidade.c : extremidade.d;
            double extremidadeD = extremidade.d > extremidade.c ? extremidade.d : extremidade.c;

            if((numero < extremidadeA && numero < extremidadeC) || (numero > extremidadeB && numero > extremidadeD))
                return string.Empty;
            else
            {
                if((numero >= extremidadeA) && (numero <= extremidadeB) && (numero >= extremidadeC) && (numero <= extremidadeD))
                    return $"[{extremidade.a},{extremidade.b}] & [{extremidade.c},{extremidade.d}]";
                else
                {
                    if((numero >= extremidadeA) && (numero <= extremidadeB))
                        return $"[{extremidade.a},{extremidade.b}]";
                    else
                        return $"[{extremidade.c},{extremidade.d}]";
                }
            }
        }
        public (int digito1, int digito2, int digito3, int digito4) ExtrairDigitoNumero(int numero)
        {
            int digito1 = (numero / 1000) % 10;
            int digito2 = (numero / 100) % 10;
            int digito3 = (numero / 10) % 10;
            int digito4 = (numero % 10);

            return (digito1, digito2, digito3, digito4);
        }

        public IEnumerable<(int contador, int m, int exp, double soma, double parcela, double somatorio)> CalcularSomaTermosSerie(double numero)
        {
            var results = new List<(int contador, int m, int exp, double soma, double parcela, double somatorio)>();
            int contador = 1;
            int m = 1;
            int exp = 25;
            double soma = 0;
            double parcela;
            double somatorio = 0;

            do
            {
                parcela = ((Math.Pow(numero, exp)) / contador);
                soma += parcela;
                if (contador == 1)
                {
                    results.Add((contador, m, exp, soma, parcela, somatorio));
                    somatorio = soma;
                }
                else
                {
                    results.Add((contador, m, exp, soma, parcela, somatorio));
                    somatorio = soma;
                }

                m *= -1;
                exp--;
                contador++;

            } while (contador <= 25);

            return results;

        }

        public double CalcularExpressao()
        {
            int num = 1;
            int m = 1;
            int cont = 0;
            double result = 0;
            double parcela;

            do
            {
                parcela = (num / (Math.Pow(num, 2))) * m;
                m *= -1;
                result += parcela;
                num += 1;
                cont++;
            } while (num <= 10);

            return result;
        }
    }
}
