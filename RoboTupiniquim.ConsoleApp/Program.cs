using System;
using System.Collections.Generic;

namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cabeçalho do programa
            Console.WriteLine("=============================================");
            Console.WriteLine("| Robô Tupiniquim - Simulador de Exploração |");
            Console.WriteLine("=============================================");
            
            // Configuração da área
            Area area = Area.LerDimensoes();
            
            // Lista para armazenar os robôs
            List<Robo> robos = new List<Robo>();
            
            // Primeiro robô
            Console.WriteLine("\nRobô 1");
            Robo robo1 = Robo.LerPosicaoInicial("Robô 1", area);
            string instrucoes1 = Robo.LerInstrucoesValidas();
            robo1.ExecutarInstrucoes(instrucoes1, area);
            robos.Add(robo1);
            
            // Segundo robô
            Console.WriteLine("\nRobô 2");
            Robo robo2 = Robo.LerPosicaoInicial("Robô 2", area);
            string instrucoes2 = Robo.LerInstrucoesValidas();
            robo2.ExecutarInstrucoes(instrucoes2, area);
            robos.Add(robo2);
            
            // Exibição dos resultados
            Console.WriteLine("\nResultados:");
            
            for (int i = 0; i < robos.Count; i++)
            {
                Robo robo = robos[i];
                string nomeRobo = $"Robô {i + 1}";
                
                if (robo.DentroLimites)
                {
                    Console.WriteLine($"Posição final do {nomeRobo}: {robo}");
                }
                else
                {
                    Console.WriteLine($"{nomeRobo} ultrapassou os limites da área definida.");
                    Console.WriteLine($"Última posição válida: {robo}");
                }
            }
            
            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
