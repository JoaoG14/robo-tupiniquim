using System;

namespace RoboTupiniquim.ConsoleApp
{
    public class Area
    {
        public int LimiteX { get; private set; }
        public int LimiteY { get; private set; }

        public Area(int limiteX, int limiteY)
        {
            if (limiteX <= 0 || limiteY <= 0)
                throw new ArgumentException("As dimensões da área devem ser maiores que zero.");

            LimiteX = limiteX;
            LimiteY = limiteY;
        }

        public bool PosicaoValida(int x, int y)
        {
            return x >= 0 && x <= LimiteX && y >= 0 && y <= LimiteY;
        }

        public static Area LerDimensoes()
        {
            int areaX = 0, areaY = 0;
            bool dimensoesValidas = false;
            
            Console.WriteLine("Digite as coordenadas do canto superior direito da área (X Y):");
            
            while (!dimensoesValidas)
            {
                try
                {
                    string[] dimensoes = Console.ReadLine().Split(' ');
                    
                    if (dimensoes.Length != 2)
                    {
                        Console.WriteLine("Formato inválido! Digite dois números separados por espaço (X Y):");
                        continue;
                    }
                    
                    areaX = int.Parse(dimensoes[0]);
                    areaY = int.Parse(dimensoes[1]);
                    
                    if (areaX <= 0 || areaY <= 0)
                    {
                        Console.WriteLine("Dimensões inválidas! Os valores devem ser maiores que zero. Digite novamente:");
                        continue;
                    }
                    
                    dimensoesValidas = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida! Digite apenas números inteiros para as coordenadas:");
                }
            }
            
            return new Area(areaX, areaY);
        }
    }
} 