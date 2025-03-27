using System;

namespace RoboTupiniquim.ConsoleApp
{
    public static class Robo
    {
        public static (int x, int y, char orientacao) LerPosicaoValida(int areaX, int areaY, string nomeRobo)
        {
            bool posicaoValida = false;
            int x = 0, y = 0;
            char orientacao = ' ';
            
            Console.WriteLine("Posição inicial e orientação (X Y O):");
            
            while (!posicaoValida)
            {
                try
                {
                    string entrada = Console.ReadLine();
                    string[] posicaoInicial = entrada.Split(' ');
                    
                    if (posicaoInicial.Length != 3)
                    {
                        Console.WriteLine("Formato inválido! Digite três valores separados por espaço (X Y O):");
                        continue;
                    }
                    
                    if (!int.TryParse(posicaoInicial[0], out x) || !int.TryParse(posicaoInicial[1], out y))
                    {
                        Console.WriteLine("Coordenadas inválidas! Digite valores numéricos para X e Y:");
                        continue;
                    }
                    
                    if (posicaoInicial[2].Length != 1)
                    {
                        Console.WriteLine("Orientação inválida! A orientação deve ser um único caractere (N, S, L ou O):");
                        continue;
                    }
                    
                    orientacao = char.Parse(posicaoInicial[2].ToUpper());
                    
                    bool dentroLimites = Area.PosicaoValida(x, y, areaX, areaY);
                    bool orientacaoValida = (orientacao == 'N' || orientacao == 'S' || 
                                            orientacao == 'L' || orientacao == 'O');
                    
                    if (!dentroLimites)
                    {
                        Console.WriteLine($"Posição fora dos limites da área! A área vai de (0,0) até ({areaX},{areaY}). Digite novamente:");
                    }
                    else if (!orientacaoValida)
                    {
                        Console.WriteLine("Orientação inválida! A orientação deve ser N, S, L ou O. Digite novamente:");
                    }
                    else
                    {
                        posicaoValida = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Entrada inválida! Digite novamente a posição inicial (X Y O):");
                }
            }
            
            return (x, y, orientacao);
        }
        
        public static string LerInstrucoesValidas()
        {
            bool instrucoesValidas = false;
            string instrucoes = "";
            
            while (!instrucoesValidas)
            {
                instrucoes = Console.ReadLine().ToUpper();
                
                if (string.IsNullOrWhiteSpace(instrucoes))
                {
                    Console.WriteLine("Instruções vazias! Digite alguma instrução:");
                    continue;
                }
                
                bool todasInstrucoesValidas = true;
                foreach (char instrucao in instrucoes)
                {
                    if (instrucao != 'M' && instrucao != 'E' && instrucao != 'D')
                    {
                        Console.WriteLine($"Instrução inválida encontrada: '{instrucao}'. Use apenas M (mover), E (esquerda) ou D (direita). Digite novamente:");
                        todasInstrucoesValidas = false;
                        break;
                    }
                }
                
                instrucoesValidas = todasInstrucoesValidas;
            }
            
            return instrucoes;
        }
        
        public static bool ExecutarInstrucoes(ref int x, ref int y, ref char orientacao, string instrucoes, int limiteX, int limiteY)
        {
            bool dentroLimites = true;
            
            foreach (char instrucao in instrucoes)
            {
                switch (instrucao)
                {
                    case 'M':
                        dentroLimites = MoverParaFrente(ref x, ref y, orientacao, limiteX, limiteY) && dentroLimites;
                        break;
                    case 'E':
                        VirarEsquerda(ref orientacao);
                        break;
                    case 'D':
                        VirarDireita(ref orientacao);
                        break;
                    default:
                        break;
                }
            }
            
            return dentroLimites;
        }
        
        public static bool MoverParaFrente(ref int x, ref int y, char orientacao, int limiteX, int limiteY)
        {
            int novoX = x;
            int novoY = y;
            
            switch (orientacao)
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
            
            bool posicaoValida = Area.PosicaoValida(novoX, novoY, limiteX, limiteY);
            
            if (posicaoValida)
            {
                x = novoX;
                y = novoY;
                return true;
            }
            
            return false;
        }
        
        public static void VirarEsquerda(ref char orientacao)
        {
            switch (orientacao)
            {
                case 'N':
                    orientacao = 'O';
                    break;
                case 'O':
                    orientacao = 'S';
                    break;
                case 'S':
                    orientacao = 'L';
                    break;
                case 'L':
                    orientacao = 'N';
                    break;
            }
        }
        
        public static void VirarDireita(ref char orientacao)
        {
            switch (orientacao)
            {
                case 'N':
                    orientacao = 'L';
                    break;
                case 'L':
                    orientacao = 'S';
                    break;
                case 'S':
                    orientacao = 'O';
                    break;
                case 'O':
                    orientacao = 'N';
                    break;
            }
        }
    }
} 