class GameController {
    private readonly IBoard Board;
    private readonly List<IPlayer> Players;
    private readonly ITileBag TileBag;
    private readonly IDictionary Dictionary;
    private int CurrentPlayerIndex;
    private GameStatus Status;
    private readonly Func<string, bool> ValidateWord;
    private readonly Action<IPlayer> OnTrunAdvanced;

    public GameController(Func<string, bool> validation, Action<IPlayer> trunAdvanced){
        this.Board = new Board();
        this.Players = new List<IPlayer>();
        this.TileBag = new TileBag();
        this.Dictionary = new Dictionary();
        this.ValidateWord = validation;
        this.OnTrunAdvanced = trunAdvanced;
        this.CurrentPlayerIndex = 0;
        this.Status = GameStatus.NotStarted;
    }

    public void StartGame(){
        this.Status = GameStatus.InProgress;
        Console.WriteLine("Game Started");
        Board.Render();
    }

    public void AdvanceTurn(){
        if (Players == null || Players.Count == 0){
            throw new InvalidOperationException("No players in the game");
        }
        this.CurrentPlayerIndex = (CurrentPlayerIndex + 1) % this.Players.Count;
        this.OnTrunAdvanced(Players[CurrentPlayerIndex]);
    }

    //pass swap tiles
    public void SwapTiles(IPlayer player, List<Tile> tiles){
        player.GetName();
        // this.TileBag.SwapTiles(tiles);
    }

    //pass passturn
    public void PassTurn(IPlayer player){
        this.AdvanceTurn();
    }

    public void ChallengeWord(IPlayer challenger) => ValidateWord("Example");

    //pass IsGameOver
    public bool IsGameOver(){
        return this.Status == GameStatus.GameOver;
    }

    //pass CalculateFinalScore
    public void CalculateFinalScore(){
        if(this.Status == GameStatus.Completed){
            foreach(IPlayer player in this.Players){
                player.GetScore();
            }
        }    
    }

    //pass GetStatus
    public GameStatus GetStatus(){
        return this.Status;
    }
    
    public void EndGame(){
        this.Status = GameStatus.Completed;
        Console.WriteLine("Game Over!");
    }
    
    //pass RenderBoard
    public void RenderBoard(){
        this.Board.Render();
    }
    
    //pass PlaceWord
    public int PlaceWord(IPlayer player, Word word){
        if(ValidateWordPlacement(word.ToString())){
            return this.Board.PlaceWorld(player, word);
        }

        return 1;
    }
    
    //pass ValidateWordPlacement
    public bool ValidateWordPlacement(string word){
        return this.Dictionary.IsValidWord(word);
    }
    
    //pass ClaculateWordScore
    public int CalculateWordScore(Word word) {
        int score = 0;
        foreach (Tile tile in word.Tiles) {
            score += tile.Value;
        }
        return score;
    }

    //pass ApplyPremiumMultipliers
    public int ApplyPremiumMultipliers(Word word) {
        return 0;
    }

    //pass IsValidPlacement
    public bool IsValidPlacement(Word word) {
        return false;
    }

    //pass IsAdjacentToExisting
    public bool IsAdjacentToExisting(Word word) {
        return false;
    }
    
    //pass IsCentered
    public bool IsCentered(Word word) {
        return false;
    }
}