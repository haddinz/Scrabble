// static void HandlePlaceWord(IPlayer player, GameController gameController, bool isFirstMove)
// {
//     Console.Write("Enter the word to place: ");
//     string wordInput = Console.ReadLine().ToUpper();

//     int x, y;
//     if (isFirstMove)
//     {
//         // First word must start at the center position [7, 7]
//         x = 7;
//         y = 7;
//         Console.WriteLine($"First word must start at the center position: ({x}, {y})");
//     }
//     else
//     {
//         // For subsequent words, allow the player to choose the starting position
//         Console.Write("Enter starting position (X Y): ");
//         string[] positionInput = Console.ReadLine().Split();
//         x = int.Parse(positionInput[0]);
//         y = int.Parse(positionInput[1]);
//     }

//     Console.Write("Is the word horizontal? (Y/N): ");
//     bool isHorizontal = Console.ReadLine().ToUpper() == "Y";

//     // Create tiles for the word
//     List<Tile> tiles = new List<Tile>();
//     foreach (char letter in wordInput)
//     {
//         tiles.Add(new Tile(letter, GetTileValue(letter), false)); // Assume no wildcards for simplicity
//     }

//     // Create the word
//     Word word = new Word(tiles, new Position(x, y), isHorizontal);

//     // Place the word
//     int score = gameController.PlaceWord(player, word);
//     if (score > 0)
//     {
//         Console.WriteLine($"{player.GetName()} placed the word '{wordInput}' and scored {score} points.");
//     }
// }