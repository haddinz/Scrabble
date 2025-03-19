// See https://aka.ms/new-console-template for more information
class Program {

    static void Main() {

        Func<string, bool> validateWord = word => {
            return new Dictionary().IsValidWord(word);
        };

        Action<IPlayer> turnAdvanced = player => Console.WriteLine($"{player.GetName()}'s turn advanced.");

        GameController gameController = new(validateWord, turnAdvanced);

        Console.WriteLine("Welcome to Scrabble!");      

        gameController.StartGame();  
        bool isHorizontal = true;

        while(!gameController.IsGameOver()) {
            gameController.RenderBoard();
            gameController.DisplayAllPlayerScores();  

            IPlayer currentPlayer = gameController.GetCurrentPlayer();  
            Console.WriteLine($"\n{currentPlayer.GetName()}'s turn. Score: {currentPlayer.GetScore()}");

            currentPlayer.DisplayRack();

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Place a word");
            Console.WriteLine("2. Pass Turn");
            Console.WriteLine("3. Shuffle Rack");
            Console.WriteLine("4. Swap Tiles");
            Console.WriteLine("5. End Game");
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Game Status: {gameController.GetStatus()}");

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the word : ");
                    string wordInput = Console.ReadLine()?.ToUpper() ?? string.Empty;
                    
                    Console.WriteLine("Enter startting position (X, Y) : ");
                    string[] positionInput = Console.ReadLine()?.Split(",") ?? new string[0];
                    int x = int.Parse(positionInput[0]) - 1;
                    int y = int.Parse(positionInput[1]) - 1;

                    Console.Write("Is the word vertical? (Y / N): ");
                    isHorizontal = Console.ReadLine()?.ToUpper() == "Y";

                    TileBag tileBag = new();
                    List<Tile> tiles = new List<Tile>();

                    foreach (char letter in wordInput) {
                        tiles.Add(new Tile(letter, false));
                    }

                    Word word = new Word(tiles, new Position(x, y), isHorizontal);

                    int score = gameController.PlaceWord(currentPlayer, word);
                    if(score > 0) {
                        Console.WriteLine($"{currentPlayer.GetName()} placed the word '{wordInput}' and scored {score} points.");
                    }

                    gameController.AdvanceTurn();
                    break;

                case "2":
                    gameController.PassTurn(currentPlayer);
                    break;

                case "3":
                    currentPlayer.ShuffleRack();
                    break;

                case "4":
                    Console.Write("Enter the letter to swap = ");
                    string letterToSwap = Console.ReadLine()?.ToUpper() ?? string.Empty;

                    List<Tile> tilesToSwap = new List<Tile>();
                    foreach (char letter in letterToSwap) {
                        Tile tile = currentPlayer.Tiles.FirstOrDefault(t => t.Letter == letter);
                        if(tile != null) {
                            tilesToSwap.Add(tile);
                        } else {
                            Console.WriteLine($"Tile '{letter}' is not in your rack. Please enter valid tiles to swap.");
                            tilesToSwap.Clear();
                            break;
                        }
                    }

                    if (tilesToSwap.Count > 0) {
                        gameController.SwapTiles(currentPlayer, tilesToSwap);
                    } else {
                        Console.WriteLine("No valid tiles selected to swap.");
                    }

                    gameController.PassTurn(currentPlayer);
                    break;
                    
                case "5":
                    gameController.EndGame();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }
        }

        Console.WriteLine("\nGame over!");
        gameController.CalculateFinalScore();
        IPlayer winner = gameController.GameWinner();
        Console.WriteLine($"{winner.GetName()} with {winner.GetScore()} points!");

    }
        
}


