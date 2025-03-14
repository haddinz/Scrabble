// See https://aka.ms/new-console-template for more information
class Program {
    static void Main() {

        Func<string, bool> validateWord = word => true;
        Action<IPlayer> turnAdvanced = player => Console.WriteLine($"{player.GetName()}'s turn advanced.");

        GameController gameController = new(validateWord, turnAdvanced);

        Console.WriteLine("Welcome to Scrabble!");
        // Console.WriteLine("How many players are playing?");
        // int playerCount = int.Parse(Console.ReadLine() ?? "0");

        // if (playerCount < 2) {
        //     Console.WriteLine("You need at least 2 players to start the game.");
        //     return;
        // } else if (playerCount >= 3) {
        //     Console.WriteLine("Too many players. Only 2 players can play at a time.");
        //     return;
        // }

        // for (int i = 1; i <= playerCount; i++) {
        //     Console.WriteLine($"Enter Player : {i}");
        //     string playerName = Console.ReadLine() ?? string.Empty;
        //     gameController.AddPlayer(new Player(playerName));
        // }        

        gameController.AddPlayer(new Player("Player 1"));
        gameController.AddPlayer(new Player("Player 2"));

        gameController.StartGame();        
        bool isFirstInput = true;
        bool isHorizontal = true;

        while(!gameController.IsGameOver()) {
            IPlayer currentPlayer = gameController.GetCurrentPlayer();
            Console.WriteLine($"\n{currentPlayer.GetName()}'s turn. Score: {currentPlayer.GetScore()}");

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Place a word");
            Console.WriteLine("2. Swap tiles");
            Console.WriteLine("3. Pass turn");
            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine() ?? string.Empty;

            IPlayer player = gameController.GetCurrentPlayer();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the word : ");
                    string wordInput = Console.ReadLine()?.ToUpper() ?? string.Empty;
                    
                    int x;
                    int y;

                    if (isFirstInput) {
                        x = 7;
                        y = 7;
                        isFirstInput = false;
                    } else {
                        Console.WriteLine("Enter startting position (X, Y) : ");
                        string[] positionInput = Console.ReadLine()?.Split(",") ?? new string[0];
                        x = int.Parse(positionInput[0]);
                        y = int.Parse(positionInput[1]);

                        Console.Write("Is the word horinzontal? (Y / N): ");
                        isHorizontal = Console.ReadLine()?.ToUpper() == "Y";
                    }

                    List<Tile> tiles = new List<Tile>();
                    foreach (char letter in wordInput) {
                        tiles.Add(new Tile(letter, GetTileValue(letter), false));
                    }

                    Word word = new Word(tiles, new Position(x, y), isHorizontal);

                    int score = gameController.PlaceWord(player, word);
                    if(score > 0) {
                        Console.WriteLine($"{player.GetName()} placed the word '{wordInput}' and scored {score} points.");
                    }

                    break;
                case "2":

                    Console.WriteLine("Enter the letters of the tiles of swap : ");
                    string tilesToSwapInput = Console.ReadLine()?.ToUpper() ?? string.Empty;

                    List<Tile> tilesToSwap = new List<Tile>();
                    foreach(char letter in tilesToSwapInput) {
                        Tile? tile = player.Tiles.FirstOrDefault(t => t.Letter == letter);
                        if (tile != null) {
                            tilesToSwap.Add(tile);
                        }

                    }
                    
                    if (tilesToSwap.Count > 0) {
                        gameController.SwapTiles(player, tilesToSwap);
                        Console.WriteLine($"{player.GetName()} swapped tiles. ");
                    } else {
                        Console.WriteLine("No valid tiles to swap");
                    }

                    break;
                case "3":
                    gameController.PassTurn(currentPlayer);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            gameController.RenderBoard();
            gameController.AdvanceTurn();
        }

        static int GetTileValue(char letter) {
            Dictionary<char, int> tileValue = new Dictionary<char, int>
            {
                { 'A', 1 }, { 'B', 3 }, { 'C', 3 }, { 'D', 2 }, { 'E', 1 },
                { 'F', 4 }, { 'G', 2 }, { 'H', 4 }, { 'I', 1 }, { 'J', 8 },
                { 'K', 5 }, { 'L', 1 }, { 'M', 3 }, { 'N', 1 }, { 'O', 1 },
                { 'P', 3 }, { 'Q', 10 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
                { 'U', 1 }, { 'V', 4 }, { 'W', 4 }, { 'X', 8 }, { 'Y', 4 },
                { 'Z', 10 }
            };

            return tileValue.ContainsKey(letter) ? tileValue[letter] : 0;
        }

    }

    
}


