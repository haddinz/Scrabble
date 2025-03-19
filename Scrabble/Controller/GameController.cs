class GameController {
    private IBoard Board;
    private List<IPlayer> Players;
    private ITileBag TileBag;
    private IDictionary Dictionary;
    private int CurrentPlayerIndex;
    private GameStatus Status;
    private Func<string, bool> ValidateWord; 
    private Action<IPlayer> OnTrunAdvanced;

    public GameController(Func<string, bool> validation, Action<IPlayer> trunAdvanced){
        this.ValidateWord = validation;
        this.OnTrunAdvanced = trunAdvanced;

        this.Board = new Board();
        this.Players = new List<IPlayer>();
        this.TileBag = new TileBag();
        this.Dictionary = new Dictionary();
        this.Status = GameStatus.NotStarted;

        this.CurrentPlayerIndex = 0;
    }

    public void StartGame(){
        Players.Add(new Player("Player 1"));
        Players.Add(new Player("Player 2"));

        this.Status = GameStatus.InProgress;

        foreach (var player in Players) {
            player.Tiles = TileBag.DrawTiles(7);
        }
        
        Console.WriteLine("Game Started");
        Console.WriteLine(" ");
    }

    public void PassTurn(IPlayer player){
        Console.WriteLine($"{player.GetName()} passed their turn.");

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
        if (TileBag.TilesRemaining() < tiles.Count){
            Console.WriteLine("Not enough tiles in the bag to swap.");
            Console.WriteLine();
            return;
        }

        foreach (var tile in tiles) {
            if(!player.Tiles.Contains(tile)) {
                Console.WriteLine($"Tile '{tile.Letter}' is not in your rack. Please enter valid tiles to swap.");
                Console.WriteLine();
                return;
            }
        }

        foreach (var tile in tiles) {
            player.Tiles.Remove(tile);
        }

        foreach (var tile in tiles) {
            TileBag.ReturnTiles(tile);
        }

        List<Tile> newTiles = TileBag.DrawTiles(tiles.Count);
        player.Tiles.AddRange(newTiles);
        Console.WriteLine($"{player.GetName()} swapped {tiles.Count} tiles.");
        Console.WriteLine();
    }

    public bool ChallengeWord(IPlayer challenger){
        Console.WriteLine($"{challenger.GetName()} challenged the word.");
        Console.WriteLine();
        return true;
    }

    public bool IsGameOver(){
        return this.Status == GameStatus.Completed;
    }

    public void CalculateFinalScore(){
        foreach (var player in Players)
        {
            if (player.GetScore() < 0) {
                player.AddScore(-player.GetScore());
            }
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

        if(!ValidateWord(wordString)){
            Console.WriteLine();
            Console.WriteLine($"Invalid word: {wordString}");
            return 0;
        }

        if (!IsValidPlacement(word)) {
            Console.WriteLine();
            Console.WriteLine("Invalid word placement.");
            return 0;
        }
        
        int score = CalculateWordScore(player ,word);
        player.AddScore(score);
        return score;
    }
    
    public bool ValidateWordPlacement(Word word){
        return true;
    }
    
    public int CalculateWordScore(IPlayer player, Word word) {
        int score = this.Board.PlaceWorld(player, word);

        return score;
    }

    public int ApplyPremiumMultipliers(Word word) {
    int wordScore = 0; 
    int wordMultiplier = 1; 

    foreach (var position in word.GetCoveredPositions()) {
        Cell cell = Board.GetCell(position.X, position.Y);
        int tileValue = cell.Tile.Value; 

        switch (cell.PremiumType) {
            case PremiumSquareType.DL: 
                tileValue *= 2;
                break;
            case PremiumSquareType.TL: 
                tileValue *= 3;
                break;
            case PremiumSquareType.DW: 
                wordMultiplier *= 2;
                break;
            case PremiumSquareType.TW: 
                wordMultiplier *= 3;
                break;
        }

        wordScore += tileValue; 
    }

    return wordScore * wordMultiplier;
}

    public bool IsValidPlacement(Word word) {
        if (word.IsHorizontal && (word.Start.X + word.Tiles.Count > 15)) {
            return false;
        }

        if (word.IsHorizontal && (word.Start.Y + word.Tiles.Count > 15)) {
            return false;
        }

        if(Board.IsFirstWordPlaced() && !Board.IsAdjacentToExisting(word)) {
            return false;
        }

        return true;
    }

    public bool IsAdjacentToExisting(Word word) {
        return this.Board.IsAdjacentToExisting(word);
    }
    
    public bool IsCentered(Word word) {
        return true;
    }
}