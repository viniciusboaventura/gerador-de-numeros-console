using System;
using System.ComponentModel.DataAnnotations;

namespace gerador_de_numeros_aleatorios
{
    public class Program
    {

        static void Main(string[] args)
        {
            int iSim;
            string sSim; // variaveis do menu

            string sMenor;
            string sMaior;
            /* Variaveis de número mínimo e máximo, 
             * utilizando o metodo de tryparse para validação de entrada*/

            int iMenor = 0;
            int iMaior = 0;

            Random random = new Random(); //instanciando o Random

            Console.WriteLine("======== GERADOR DE NÚMEROS ALEATÓRIOS ========\n - Digite 1 para começar o programa \n - Digite qualquer outra tecla para sair");

            sSim = Console.ReadLine();

            int.TryParse(sSim, out iSim); //Verificando a entrada do usuario


            while (iSim == 1)
            {
                Console.WriteLine("Digite o número mínimo e o número máximo do gerador");
                
                sMenor = Console.ReadLine().Trim();

                sMaior = Console.ReadLine().Trim();

                while (sMenor == "" || sMaior == "")
                {
                    Console.WriteLine("Digite algum número!");
                    
                    sMenor = Console.ReadLine().Trim();

                    sMaior = Console.ReadLine().Trim();
                }

                 iMenor = int.Parse(sMenor);
                 iMaior = int.Parse(sMaior);

                 bool bValida = Validacao.Valida(sMenor, iMenor) || Validacao.Valida(sMaior, iMaior);


                while (bValida == false || iMaior <= iMenor) //Aplicando o método de validação, além de checar caso o segundo número digitado seja maior que o primeiro.
                {
                    Console.WriteLine("Digite um número válido!");

                    sMenor = Console.ReadLine();
                    sMaior = Console.ReadLine();

                    if (!int.TryParse(sMenor, out iMenor) || !int.TryParse(sMaior, out iMaior))
                    {
                        bValida = false;
                        
                    }
                    else
                    {
                        bValida = true;
                    }
                    
                }


                iMenor = int.Parse(sMenor); // atribuindo o valor validado às variaveis int
                iMaior = int.Parse(sMaior);


                int final = random.Next(iMenor, iMaior); //variavel responsavel por armazenar o valor gerado

                Console.WriteLine("O Número gerado foi: \n" + final + "\n");

                Console.ReadLine(); //tecla de confirmação

                Console.WriteLine("Gostaria de gerar mais um número?\n - SIM -> 1 \n - NÃO -> pressione qualquer outra tecla ");

                sSim = Console.ReadLine();
                
                int.TryParse(sSim, out iSim);
            }
            Console.WriteLine("======== Obrigado por usar meu gerador! ======== \n \n Vinícius Boaventura Siqueira");
        }
        public class Validacao  //metodo de validação simples, retorna false caso não seja um número válido.
        {
            public static bool Valida(string s, int i)
            {
                if (string.IsNullOrEmpty(s) || !int.TryParse(s, out i))
                {
                    return false;
                }
                else
                {
                    return true;

                }


            }
           
        }



    }
}