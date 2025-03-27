# Robô Tupiniquim - Simulador de Exploração

## Descrição do Projeto

O Robô Tupiniquim é um simulador de exploração que permite controlar dois robôs em uma área retangular. Os robôs podem se mover e girar através de comandos simples, permitindo a navegação pelo terreno definido.

## Funcionalidades

- Define uma área retangular para exploração
- Controla dois robôs independentes
- Movimenta os robôs através de comandos específicos
- Detecta quando um robô ultrapassa os limites da área
- Exibe a posição final dos robôs após a execução dos comandos

## Como Utilizar

Ao iniciar o programa, você será guiado pelos seguintes passos:

1. **Definir a área de exploração:**

   - Digite as coordenadas do canto superior direito da área (X Y)
   - Os valores devem ser inteiros positivos
   - A área começa em (0,0) e vai até (X,Y)

2. **Configurar o Robô 1:**

   - Digite a posição inicial e orientação do primeiro robô (X Y O)
   - X e Y são as coordenadas iniciais
   - O é a orientação (N = Norte, S = Sul, L = Leste, O = Oeste)
   - Em seguida, digite as instruções de movimento

3. **Configurar o Robô 2:**

   - Repita o mesmo processo para o segundo robô

4. **Instruções de Movimento:**

   - **M** = Mover para frente (na direção atual)
   - **E** = Girar 90° para a esquerda
   - **D** = Girar 90° para a direita

5. **Resultado:**
   - O programa exibirá a posição final de cada robô
   - Caso um robô ultrapasse os limites, será exibida sua última posição válida

## Exemplos de Entrada e Saída

**Entrada:**

![Demonstração do projeto](https://i.imgur.com/aV7kT60.gif)

```
5 5
1 2 N
EMEMEMEMM
3 3 L
MMDMMDMDDM
```

**Saída:**

```
Posição final do Robô 1: 1 3 N
Posição final do Robô 2: 5 1 L
```

## Estrutura do Projeto

O projeto está organizado em três componentes principais:

- **Program.cs**: Ponto de entrada do programa e coordenação geral da aplicação
- **Area.cs**: Gerencia a área de exploração e validação de limites
- **Robo.cs**: Implementa a lógica de movimento e orientação dos robôs

## Requisitos

- .NET 5.0 ou superior
- Sistema operacional compatível com .NET (Windows, macOS, Linux)

## Como utilizar

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

```
dotnet restore
```

4. Em seguida, compile a solução utilizando o comando:

```
dotnet build --configuration Release
```

5. Para executar o projeto compilando em tempo real

```
dotnet run --project JogoDosDados.ConsoleApp
```

6. Para executar o arquivo compilado, navegue até a pasta `./JogoDosDados.ConsoleApp/bin/Release/net8.0/` e execute o arquivo:

```
JogoDosDados.ConsoleApp.exe
```
