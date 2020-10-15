using System;
using System.Collections.Generic;

namespace LAB03AritmeticaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\t\tData: {DateTime.Now}\t\tLAB03");
            ServiceAritmetica service = new ServiceAritmetica();
            int opcao;
            bool opcaoValida = true;
            string resposta = "Sim";
            string subline = "______________________________________________________________________________________";
            do
            {
                Console.Write("\n\t\tEscolha uma opção do menu: \n" +
                    "\n\t\t\t1 - Achar intervado de número" +
                    "\n\t\t\t2 - Extrair cada dígito de um número" +
                    "\n\t\t\t3 - Calcular a função: f(x,y) = (((x^2) + 3x + (y^2)) / ((xy) - 5y - 3x + 15))" +
                    "\n\t\t\t4 - Calcular a série: (x^25)/1 - (x^24)/2 + (x^23)/3 - (x^22)/4 + ... + (x)/25" +
                    "\n\t\t\t5 - Calcular uma expressão da seguinte forma: s = 1/1 - 2/4 + 3/9 - 4/16 + 5/25 - 6/36 + ... - 10/100" +
                    $"\n\t\t{subline}\n" +
                    "\n\t\t\t\tQual sua opção?: ");

                opcao = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"\t\t{subline}\n");

                switch(opcao)
                {
                    case 1:
                        {
                            Console.Write("\t\tInforme o número: ");
                            double numero = Double.Parse(Console.ReadLine());

                            Console.Write("\n\t\tInforme o valor da extremidade A: ");
                            double extremidadeA = Double.Parse(Console.ReadLine());
                            Console.Write("\t\tInforme o valor da extremidade B: ");
                            double extremidadeB = Double.Parse(Console.ReadLine());

                            Console.Write("\n\t\tInforme o valor da extremidade C: ");
                            double extremidadeC = Double.Parse(Console.ReadLine());
                            Console.Write("\t\tInforme o valor da extremidade D: ");
                            double extremidadeD = Double.Parse(Console.ReadLine());

                            string intervalo = service.AcharIntervadoNumero(numero, (extremidadeA, extremidadeB, extremidadeC, extremidadeD));

                            Console.WriteLine($"\n\t\tO número {numero}" + (intervalo != string.Empty ?
                                $" pertence ao intervalo: {intervalo}" :
                                $" não pertence a nenhum dos intervalos: [{extremidadeA},{extremidadeB}] & [{extremidadeC},{extremidadeD}]"));

                            break;
                        }

                    case 2:
                        {
                            Console.Write("\n\t\tInforme o Número: ");
                            int numero = Int32.Parse(Console.ReadLine());

                            if(numero < 1000 || numero > 9999)
                            {
                                Console.Write("\n\t\t\t\tNúmero inválido!");
                                break;
                            }

                            var (digito1, digito2, digito3, digito4) = service.ExtrairDigitoNumero(numero);

                            Console.WriteLine($"\n\t\tOs dígitos do número fornecido são: {digito1}, {digito2}, {digito3} e {digito4}");
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("\t\tCálculo da função: \n\t\tf(x,y) = (((x^2) + 3x + (y^2)) / ((xy) - 5y - 3x + 15))\n");

                            double f;
                            for (int x = 1; x <= 5; x++)
                            {
                                for (int y = 0; y <= 5; y++)
                                {
                                    f = (Math.Pow(x, 2)) + 3 * x + (Math.Pow(y, 2));
                                    Console.WriteLine($"\t\tf({x},{y}) = {f}");
                                }
                                Console.WriteLine();
                            } 
                            break;
                        }

                    case 4:
                        {
                            string mensagem = string.Empty;
                            Console.Write("\n\t\tInforme um número: ");

                            double numero = Double.Parse( Console.ReadLine());

                            IEnumerable<(int contador, int m, int exp, double soma, double parcela, double somatorio)> results = service.CalcularSomaTermosSerie(numero);


                            foreach(var (contador, m, exp, soma, parcela, somatorio) in results)
                            {
                                if (contador == 1)
                                    mensagem += $"\t\t({numero}^{exp}) / {contador} = {parcela}\n\n";
                                else
                                    mensagem += $"\t\t({numero}^{exp}) / {contador} = {parcela}\n\t\t{somatorio} " + (m == 1 ? "+" : "-") + $" {parcela} = {soma}\n\n";
                            }

                            Console.WriteLine($"\n\t\tResultado:\n\n {mensagem}");

                            break;
                        }

                    case 5:
                        {
                            double result = service.CalcularExpressao();
                            Console.WriteLine($"\n\t\tA soma dos 10 termos da série é: {result}");
                            
                            break;
                        }

                    default:
                        {
                            opcaoValida = false;
                            Console.Write("\t\t\t\tOpção Inválida! Tente outra vez!");
                            break;
                        }

                }

                Console.WriteLine($"\n\t\t{subline}");

                if(opcaoValida)
                {
                    Console.Write("\n\t\tDeseja continuar?, digite \"Sim\" para prosseguir: ");
                    resposta = Console.ReadLine();
                    Console.Clear();
                }
                

            } while(string.Equals(resposta, "sim", StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(resposta, "s", StringComparison.CurrentCultureIgnoreCase));

            Console.WriteLine($"\t\t{subline}");
            Console.WriteLine();
        }


        
    }
}
