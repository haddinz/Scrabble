// See https://aka.ms/new-console-template for more information
class Program {
    static void Main() {

        Func<string, bool> validation = word => !string.IsNullOrEmpty(word) && word.Length > 2;
        Action<IPlayer> onTurnAdvanced = player => Console.WriteLine($"Player {player.GetName()} next turn");

        GameController game = new GameController(validation, onTurnAdvanced);
        game.StartGame();
        // game.AdvanceTurn();
        game.AdvanceTurn();
        game.EndGame();
    }
}
