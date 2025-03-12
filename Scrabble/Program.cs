// See https://aka.ms/new-console-template for more information
class Program {
    static void Main() {

        Func<string, bool> validateWord = word => true;
        Action<IPlayer> turnAdvanced = player => Console.WriteLine($"{player.GetName()}'s turn advanced.");

        GameController game = new(validateWord, turnAdvanced);
        game.StartGame();

        Player player1 = new Player("Alice");
        Player player2 = new Player("Bob");

        game.AdvanceTurn();
    }
}
