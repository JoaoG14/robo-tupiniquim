using System;

namespace RoboTupiniquim.ConsoleApp
{
    public class Robo
    {
        public string Nome { get; private set; }
        public int PosicaoX { get; private set; }
        public int PosicaoY { get; private set; }
        public char Orientacao { get; private set; }
        public bool DentroLimites { get; private set; }

        public Robo(string nome, int posicaoX, int posicaoY, char orientacao)
        {
            Nome = nome;
            PosicaoX = posicaoX;
            PosicaoY = posicaoY;
            Orientacao = orientacao;
            DentroLimites = true;
        }

        public void ExecutarInstrucoes(string instrucoes, Area area)
        {
            foreach (char instrucao in instrucoes)
            {
                switch (instrucao)
                {
                    case 'M':
                        MoverParaFrente(area);
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

        private void MoverParaFrente(Area area)
        {
            int novoX = PosicaoX;
            int novoY = PosicaoY;
            
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
            
            bool posicaoValida = area.PosicaoValida(novoX, novoY);
            
            if (posicaoValida)
            {
                PosicaoX = novoX;
                PosicaoY = novoY;
            }
            else
            {
                DentroLimites = false;
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

        public override string ToString()
        {
            return $"{PosicaoX} {PosicaoY} {Orientacao}";
        }

        public static Robo LerPosicaoInicial(string nome, Area area)
        {
            bool posicaoValida = false;
            int x = 0, y = 0;
            char orientacao = ' ';
            
            Console.WriteLine($"Posição inicial e orientação do {nome} (X Y O):");
            
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
                    
                    bool dentroLimites = area.PosicaoValida(x, y);
                    bool orientacaoValida = (orientacao == 'N' || orientacao == 'S' || 
                                            orientacao == 'L' || orientacao == 'O');
                    
                    if (!dentroLimites)
                    {
                        Console.WriteLine($"Posição fora dos limites da área! A área vai de (0,0) até ({area.LimiteX},{area.LimiteY}). Digite novamente:");
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
            
            return new Robo(nome, x, y, orientacao);
        }
        
        public static string LerInstrucoesValidas()
        {
            bool instrucoesValidas = false;
            string instrucoes = "";
            
            Console.WriteLine("Instruções (M = mover, E = virar à esquerda, D = virar à direita):");
            
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
    }
} 