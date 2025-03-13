// class TempController
// {
//     private List<IPlayer> players;
//     private int currentPlayerIndex;
//     private IBoard board;
//     private ITileBag tileBag;
//     private IDictionary dictionary;

//     public TempController()
//     {
//         players = new List<IPlayer>();
//         currentPlayerIndex = 0;
//         board = new Board();
//         tileBag = new TileBag();
//         dictionary = new Dictionary();
//     }

//     public void AddPlayer(IPlayer player)
//     {
//         players.Add(player);
//         Console.WriteLine($"{player.GetName()} has been added to the game.");
//     }

//     public void StartGame()
//     {
//         if (players.Count == 0)
//         {
//             throw new InvalidOperationException("Cannot start game: No players added.");
//         }
//         Console.WriteLine("Game started!");
//     }

//     public void AdvanceTurn()
//     {
//         currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
//     }

//     public IPlayer GetCurrentPlayer()
//     {
//         return players[currentPlayerIndex];
//     }

//     public void RenderBoard()
//     {
//         board.Render();
//     }

//     public int PlaceWord(IPlayer player, Word word)
//     {
//         if (!board.ValidateWordPlacement(word))
//         {
//             Console.WriteLine("Invalid word placement.");
//             return 0;
//         }

//         int score = board.PlaceWord(player, word);
//         player.AddScore(score);
//         return score;
//     }

//     public void SwapTiles(IPlayer player, List<Tile> tiles)
//     {
//         foreach (var tile in tiles)
//         {
//             player.Tiles.Remove(tile);
//             player.Tiles.Add(tileBag.DrawTiles(1).First());
//         }
//         tileBag.DrawTiles(tiles.Count); // Return tiles to the bag
//     }

//     public void PassTurn(IPlayer player)
//     {
//         Console.WriteLine($"{player.GetName()} passed their turn.");
//     }

//     public bool IsGameOver()
//     {
//         return tileBag.TilesRemaining() == 0 && players.All(p => p.Tiles.Count == 0);
//     }

//     public void CalculateFinalScore()
//     {
//         foreach (var player in players)
//         {
//             int penalty = player.Tiles.Sum(t => t.value);
//             player.AddScore(-penalty);
//         }
//     }

//     public IPlayer GameWinner()
//     {
//         return players.OrderByDescending(p => p.GetScore()).First();
//     }
// }

// Player alice = new Player("Alice");
        // Player bob = new Player("Bob");

        // Word aliceWord = new Word(new List<Tile> { new Tile('C', 3, false), new Tile('A', 1, false), new Tile('T', 1, false) }, new Position(7, 7), true);
        // int aliceScore = gameController.PlaceWord(alice, aliceWord);
        // Console.WriteLine($"{alice.GetName()} placed the word 'CAT' and scored {aliceScore} points.");

        // gameController.RenderBoard();
        // gameController.AdvanceTurn();

        // Word bobWord = new Word(new List<Tile> { new Tile('D', 2, false), new Tile('O', 1, false), new Tile('G', 2, false) }, new Position(7, 8), false);
        // int bobScore = gameController.PlaceWord(bob, bobWord);
        // Console.WriteLine($"{bob.GetName()} placed the word 'DOG' and scored {bobScore} points.");

        // gameController.RenderBoard();
        // gameController.AdvanceTurn();

        // List<Tile> tilesToSwap = new List<Tile> { new Tile('A', 1, false), new Tile('B', 3, false) };

        // gameController.SwapTiles(alice, tilesToSwap);
        // Console.WriteLine($"{alice.GetName()} swapped tiles.");

        // gameController.PassTurn(bob);
        // Console.WriteLine($"{bob.GetName()} passed his turn.");

        // bool challengeResult = gameController.ChallengeWord(alice);
        // Console.WriteLine($"{alice.GetName()} challenged the word. Result: {challengeResult}");

        // if (gameController.IsGameOver())
        // {
        //     Console.WriteLine("The game is over!");
        //     gameController.CalculateFinalScore();
        //     IPlayer winner = gameController.GameWinner();
        //     Console.WriteLine($"{winner.GetName()} wins with {winner.GetScore()} points!");
        // }
        // else
        // {
        //     Console.WriteLine("The game continues...");
        // }