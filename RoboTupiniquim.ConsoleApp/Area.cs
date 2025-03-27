using System;

namespace RoboTupiniquim.ConsoleApp
{
    public static class Area
    {
        public static (int limiteX, int limiteY) LerDimensoesValidas()
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
            
            return (areaX, areaY);
        }

        public static bool PosicaoValida(int x, int y, int limiteX, int limiteY)
        {
            return x >= 0 && x <= limiteX && y >= 0 && y <= limiteY;
        }
    }
} 