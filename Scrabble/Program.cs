class Program {

    static void Main() {

        IDisplay display = new Display();

        Func<string, bool> validateWord = word => {
            return new Dictionary().IsValidWord(word);
        };

        Action<IPlayer> turnAdvanced = player => display.SetMessage($"{player.GetName()}'s turn advanced.");

        GameController gameController = new(validateWord, turnAdvanced); 

        display.DisplayBanner();

        gameController.StartGame();  
        bool isHorizontal = true;

        while(!gameController.IsGameOver()) {
            display.RenderBoard(gameController);
            gameController.DisplayAllPlayerScores();  

            IPlayer currentPlayer = gameController.GetCurrentPlayer();  
            display.SetMessage($"\n{currentPlayer.GetName()}'s turn. Score: {currentPlayer.GetScore()}");

            currentPlayer.DisplayRack();

            display.SetMessage("Choose an action:");
            display.SetMessage("1. Place a word");
            display.SetMessage("2. Pass Turn");
            display.SetMessage("3. Shuffle Rack");
            display.SetMessage("4. Swap Tiles");
            display.SetMessage("5. End Game");

            display.SetInputValue("Enter your choice (1-4) dari display: ");
            string choice = display.GetInputValue();

            display.SetMessage($"Game Status: {gameController.GetStatus()}");

            switch (choice)
            {
                case "1":

                    display.SetInputValue("Enter the word : ");
                    string wordInput = display.GetInputValue().ToUpper();

                    display.SetInputValue("Enter startting position (X, Y) : ");
                    string[] positionInput = display.GetInputValue().Split(",");

                    int x = int.Parse(positionInput[0]) - 1;
                    int y = int.Parse(positionInput[1]) - 1;

                    display.SetInputValue("Is the word vertical? (Y / N): ");
                    isHorizontal = display.GetInputValue()?.ToUpper() == "Y";

                    TileBag tileBag = new();
                    List<Tile> tiles = new List<Tile>();

                    foreach (char letter in wordInput) {
                        tiles.Add(new Tile(letter, false));
                    }

                    Word word = new Word(tiles, new Position(x, y), isHorizontal);

                    int score = gameController.PlaceWord(currentPlayer, word);
                    if(score > 0) {
                        display.SetMessage($"{currentPlayer.GetName()} placed the word '{wordInput}' and scored {score} points.");
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
                    display.SetInputValue("Enter the letter to swap = ");
                    string letterToSwap = display.GetInputValue().ToUpper() ?? string.Empty;

                    List<Tile> tilesToSwap = new List<Tile>();
                    foreach (char letter in letterToSwap) {
                        Tile? tile = currentPlayer.Tiles.FirstOrDefault(t => t.Letter == letter);
                        if(tile != null) {
                            tilesToSwap.Add(tile);
                        } else {
                            display.SetMessage($"Tile '{letter}' is not in your rack. Please enter valid tiles to swap.");
                            tilesToSwap.Clear();
                            break;
                        }
                    }

                    if (tilesToSwap.Count > 0) {
                        gameController.SwapTiles(currentPlayer, tilesToSwap);
                    } else {
                        display.SetMessage("No valid tiles selected to swap.");
                    }

                    gameController.PassTurn(currentPlayer);
                    break;
                    
                case "5":
                    gameController.EndGame();
                    break;

                default:
                    display.SetMessage("Invalid choice. Please try again.");
                    continue;
            }
        }

        display.SetMessage("\nGame over!");
        gameController.CalculateFinalScore();
        IPlayer? winner = gameController.GameWinner();
        display.SetMessage($"{winner?.GetName()} with {winner?.GetScore()} points!");
    }
        
}


