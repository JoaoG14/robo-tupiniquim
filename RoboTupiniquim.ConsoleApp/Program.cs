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
            
            Console.WriteLine("\nRobô 1");
            Console.WriteLine("Posição inicial e orientação (X Y O):");
            string[] posicaoInicial1 = Console.ReadLine().Split(' ');
            int x1 = int.Parse(posicaoInicial1[0]);
            int y1 = int.Parse(posicaoInicial1[1]);
            char orientacao1 = char.Parse(posicaoInicial1[2]);
            
            // Validação da posição inicial do Robô 1
            while (!area.PosicaoValida(x1, y1))
            {
                Console.WriteLine("Posição fora dos limites da área! Digite novamente a posição inicial (X Y O):");
                posicaoInicial1 = Console.ReadLine().Split(' ');
                x1 = int.Parse(posicaoInicial1[0]);
                y1 = int.Parse(posicaoInicial1[1]);
                orientacao1 = char.Parse(posicaoInicial1[2]);
            }
            
            Console.WriteLine("Instruções para o Robô 1:");
            string instrucoes1 = Console.ReadLine();
            
            Robo robo1 = new Robo(x1, y1, orientacao1, area);
            robo1.ExecutarInstrucoes(instrucoes1);
            
            string posicaoFinal1 = robo1.ObterPosicaoFinal();
            
            Console.WriteLine("\nRobô 2");
            Console.WriteLine("Posição inicial e orientação (X Y O):");
            string[] posicaoInicial2 = Console.ReadLine().Split(' ');
            int x2 = int.Parse(posicaoInicial2[0]);
            int y2 = int.Parse(posicaoInicial2[1]);
            char orientacao2 = char.Parse(posicaoInicial2[2]);
            
            // Validação da posição inicial do Robô 2
            while (!area.PosicaoValida(x2, y2))
            {
                Console.WriteLine("Posição fora dos limites da área! Digite novamente a posição inicial (X Y O):");
                posicaoInicial2 = Console.ReadLine().Split(' ');
                x2 = int.Parse(posicaoInicial2[0]);
                y2 = int.Parse(posicaoInicial2[1]);
                orientacao2 = char.Parse(posicaoInicial2[2]);
            }
            
            Console.WriteLine("Instruções para o Robô 2:");
            string instrucoes2 = Console.ReadLine();
            
            Robo robo2 = new Robo(x2, y2, orientacao2, area);
            robo2.ExecutarInstrucoes(instrucoes2);
            
            string posicaoFinal2 = robo2.ObterPosicaoFinal();
            
            Console.WriteLine("\nResultados:");
            Console.WriteLine("Posição final do Robô 1: " + posicaoFinal1);
            Console.WriteLine("Posição final do Robô 2: " + posicaoFinal2);
            
            Console.ReadKey();
        }
    }
    
    class Area
    {
        public int LimiteX { get; private set; }
        public int LimiteY { get; private set; }
        
        public Area(int limiteX, int limiteY)
        {
            LimiteX = limiteX;
            LimiteY = limiteY;
        }
        
        public bool PosicaoValida(int x, int y)
        {
            return x >= 0 && x <= LimiteX && y >= 0 && y <= LimiteY;
        }
    }
    
    class Robo
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Orientacao { get; private set; }
        private Area _area;
        
        public Robo(int x, int y, char orientacao, Area area)
        {
            X = x;
            Y = y;
            Orientacao = orientacao;
            _area = area;
        }
        
        public void ExecutarInstrucoes(string instrucoes)
        {
            foreach (char instrucao in instrucoes)
            {
                switch (instrucao)
                {
                    case 'M':
                        MoverParaFrente();
                        break;
                    case 'E':
                        VirarEsquerda();
                        break;
                    case 'D':
                        VirarDireita();
                        break;
                }
            }
        }
        
        private void MoverParaFrente()
        {
            int novoX = X;
            int novoY = Y;
            
            switch (Orientacao)
            {
                case 'N':
                    novoY++;
                    break;
                case 'S':
                    novoY--;
                    break;
                case 'L':
                    novoX++;
                    break;
                case 'O':
                    novoX--;
                    break;
            }
            
            if (_area.PosicaoValida(novoX, novoY))
            {
                X = novoX;
                Y = novoY;
            }
        }
        
        private void VirarEsquerda()
        {
            switch (Orientacao)
            {
                case 'N':
                    Orientacao = 'O';
                    break;
                case 'O':
                    Orientacao = 'S';
                    break;
                case 'S':
                    Orientacao = 'L';
                    break;
                case 'L':
                    Orientacao = 'N';
                    break;
            }
        }
        
        private void VirarDireita()
        {
            switch (Orientacao)
            {
                case 'N':
                    Orientacao = 'L';
                    break;
                case 'L':
                    Orientacao = 'S';
                    break;
                case 'S':
                    Orientacao = 'O';
                    break;
                case 'O':
                    Orientacao = 'N';
                    break;
            }
        }
        
        public string ObterPosicaoFinal()
        {
            return $"{X} {Y} {Orientacao}";
        }
    }
}
