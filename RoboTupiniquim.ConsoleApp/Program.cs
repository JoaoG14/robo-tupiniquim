using System;

namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("| Robô Tupiniquim - Simulador de Exploração |");
            Console.WriteLine("=============================================");
            
            (int areaX, int areaY) = Area.LerDimensoesValidas();
            
            Console.WriteLine("\nRobô 1");
            (int x1, int y1, char orientacao1) = Robo.LerPosicaoValida(areaX, areaY, "Robô 1");
            
            Console.WriteLine("Instruções para o Robô 1:");
            string instrucoes1 = Robo.LerInstrucoesValidas();
            
            bool robo1DentroLimites = Robo.ExecutarInstrucoes(ref x1, ref y1, ref orientacao1, instrucoes1, areaX, areaY);
            
            string posicaoFinal1 = $"{x1} {y1} {orientacao1}";
            
            Console.WriteLine("\nRobô 2");
            (int x2, int y2, char orientacao2) = Robo.LerPosicaoValida(areaX, areaY, "Robô 2");
            
            Console.WriteLine("Instruções para o Robô 2:");
            string instrucoes2 = Robo.LerInstrucoesValidas();
            
            bool robo2DentroLimites = Robo.ExecutarInstrucoes(ref x2, ref y2, ref orientacao2, instrucoes2, areaX, areaY);
            
            string posicaoFinal2 = $"{x2} {y2} {orientacao2}";
            
            Console.WriteLine("\nResultados:");
            if (robo1DentroLimites)
            {
                Console.WriteLine("Posição final do Robô 1: " + posicaoFinal1);
            }
            else
            {
                Console.WriteLine("Robô 1 ultrapassou os limites da área definida.");
                Console.WriteLine("Última posição válida: " + posicaoFinal1);
            }
            
            if (robo2DentroLimites)
            {
                Console.WriteLine("Posição final do Robô 2: " + posicaoFinal2);
            }
            else
            {
                Console.WriteLine("Robô 2 ultrapassou os limites da área definida.");
                Console.WriteLine("Última posição válida: " + posicaoFinal2);
            }
            
            Console.ReadKey();
        }
    }
}
