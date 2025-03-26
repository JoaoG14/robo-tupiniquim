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
            
            Console.WriteLine("Digite as coordenadas do canto superior direito da área (X Y):");
            string[] dimensoes = Console.ReadLine().Split(' ');
            int areaX = int.Parse(dimensoes[0]);
            int areaY = int.Parse(dimensoes[1]);
            
            Area area = new Area(areaX, areaY);
            
            Console.WriteLine("\nRobô");
            Console.WriteLine("Posição inicial e orientação (X Y O):");
            string[] posicaoInicial1 = Console.ReadLine().Split(' ');
            int x1 = int.Parse(posicaoInicial1[0]);
            int y1 = int.Parse(posicaoInicial1[1]);
            char orientacao1 = char.Parse(posicaoInicial1[2]);
            
            Console.WriteLine("Instruções para o Robô:");
            string instrucoes1 = Console.ReadLine();
            
            Robo robo1 = new Robo(x1, y1, orientacao1, area);
            robo1.ExecutarInstrucoes(instrucoes1);
            
            string posicaoFinal1 = robo1.ObterPosicaoFinal();
            
            Console.WriteLine("\nResultados:");
            Console.WriteLine("Posição final do Robô: " + posicaoFinal1);
            
            Console.ReadKey();
        }
    }
    
    class Area
    {
        // Implementar a lógica para inicializar a área
    }
    
    class Robo
    {
        
        public Robo(int x, int y, char orientacao, Area area)
        {
            // Implementar a lógica para inicializar o robô
        }
        
        public void ExecutarInstrucoes(string instrucoes)
        {
            // Implementar a lógica para executar as instruções
        }
        
        private void MoverParaFrente()
        {
            // Implementar a lógica para mover para frente
        }
        
        private void VirarEsquerda()
        {
            // Implementar a lógica para virar para a esquerda
        }
        
        private void VirarDireita()
        {
            // Implementar a lógica para virar para a direita
        }
        
    }
}
