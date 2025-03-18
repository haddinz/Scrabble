// See https://aka.ms/new-console-template for more information
class Program {

    static void Main() {

        Func<string, bool> validateWord = word => true;
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
            Console.WriteLine("4. End Game");
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine() ?? string.Empty;

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
                    // foreach (char letter in wordInput) {
                    //     tiles.Add(new Tile(letter, tileBag.GetTileValue(letter), false));
                    // }

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
                    // gameController.EndGame(currentPlayer);
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


