class GameController {
    private IBoard Board;
    private List<IPlayer> Players;
    private ITileBag TileBag;
    private IDictionary Dictionary;
    private int CurrentPlayerIndex;
    private GameStatus Status;
    private Func<string, bool> ValidateWord;
    private Action<IPlayer> OnTrunAdvanced;

    private int ConsecutivePasses;

    public GameController(Func<string, bool> validation, Action<IPlayer> trunAdvanced){
        this.ValidateWord = validation;
        this.OnTrunAdvanced = trunAdvanced;

        this.Board = new Board();
        this.Players = new List<IPlayer>();
        this.TileBag = new TileBag();
        this.Dictionary = new Dictionary();
        this.Status = GameStatus.NotStarted;

        this.CurrentPlayerIndex = 0;
        this.ConsecutivePasses = 0;
    }

    public void AddPlayer(IPlayer player){
        this.Players.Add(player);
        Console.WriteLine($"{player.GetName()} has been added to the game.");
    }

    public void StartGame(){
        if (Players == null || Players.Count == 0) {
            throw new InvalidOperationException("Not enough players to start the game");
        }
        this.Status = GameStatus.InProgress;

        Console.WriteLine(" ");
        Console.WriteLine("Game Started");
    }

    public void PassTurn(IPlayer player){
        Console.WriteLine($"{player.GetName()} passed their turn.");
        ConsecutivePasses++;

        // if(this.ConsecutivePasses >= Players.Count){
        //     Console.WriteLine("All players have passed consecutively. Ending the game.");
        //     EndGame();
        //     return;
        // }

        AdvanceTurn();
    }

    public void AdvanceTurn(){
        if (Players.Count == 0){
            throw new InvalidOperationException("No players in the game");
        }

        this.CurrentPlayerIndex = (CurrentPlayerIndex + 1) % this.Players.Count;
        Console.WriteLine($"Turn advanced to: {GetCurrentPlayer().GetName()}");

        this.OnTrunAdvanced?.Invoke(this.GetCurrentPlayer());
    }

    public IPlayer GetCurrentPlayer(){
        return Players[CurrentPlayerIndex];
    }

    public void DisplayAllPlayerScores() {
        foreach (var player in Players) {
            Console.WriteLine($"{player.GetName()}: {player.GetScore()} points");
        }
    }

    public void SwapTiles(IPlayer player, List<Tile> tiles){
        foreach(var tile in tiles){
            player.Tiles.Remove(tile);
            player.Tiles.Add(TileBag.DrawTiles(1).First());
        }

        TileBag.DrawTiles(tiles.Count);
    }

    public bool ChallengeWord(IPlayer challenger){
        Console.WriteLine($"{challenger.GetName()} challenged the word.");
        return true;
    }

    public bool IsGameOver(){
        // return this.Status == GameStatus.Completed || this.ConsecutivePasses >= Players.Count;
        return this.Status == GameStatus.Completed;
    }

    public void CalculateFinalScore(){
        foreach (var player in Players)
        {
            int penalty = player.Tiles.Sum(t => t.Value);
            player.AddScore(-penalty);
        }    
    }

    public GameStatus GetStatus(){
        return this.Status;
    }
    
    public void EndGame(){
        this.Status = GameStatus.Completed;
        Console.WriteLine("Game ended!");
    }
    
    public IPlayer GameWinner(){
        var orderedPlayer = Players.OrderByDescending(p => p.GetScore()).ToList();
        if (orderedPlayer.Count > 1 && orderedPlayer[0].GetScore() == orderedPlayer[1].GetScore()) {
            Console.WriteLine("The Game Is Draw! ");
            return null;
        }

        return orderedPlayer.First();
    }

    public void RenderBoard(){
        this.Board.Render();
    }
    
    public int PlaceWord(IPlayer player, Word word){
        string wordString = new string(word.Tiles.Select(t => t.Letter).ToArray());

        if(!Dictionary.IsValidWord(wordString)){
            Console.WriteLine($"Invalid word: {wordString}");
            return 0;
        }

        // if(!Board.ValidateWordPlacement(word)) {
        //     Console.WriteLine("Invalid Word Placement.");
        //     return 0;
        // };

        if(!ValidateWordPlacement(word)) {
            Console.WriteLine("Invalid Word Placement.");
            return 0;
        }

        if (Board.IsFirstWordPlaced() && !Board.IsAdjacentToExisting(word))
        {
            Console.WriteLine("New word must be adjacent to an existing word.");
            return 0;
        }
        
        int score = this.Board.PlaceWorld(player, word);
        player.AddScore(score);

        this.ConsecutivePasses = 0;

        return score;
    }
    
    public bool ValidateWordPlacement(Word word){
        return this.Board.IsValidPlacement(word);
        // && this.Dictionary.IsValidWord(word);
        // return true;
    }
    
    public int CalculateWordScore(Word word) {
        int score = word.Tiles.Sum(t => t.Value);
        return ApplyPremiumMultipliers(word, score);
    }

    public int ApplyPremiumMultipliers(Word word, int score) {
        return score;
    }

    public bool IsValidPlacement(Word word) {
        return this.Board.IsValidPlacement(word);
    }

    public bool IsAdjacentToExisting(Word word) {
        return this.Board.IsAdjacentToExisting(word);
    }
    
    // public bool IsCentered(Word word) {
    //     return this.Board.IsCentered(word);
    // }
}