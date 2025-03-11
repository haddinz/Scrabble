class GameController {
    public Board Board;
    public List<IPlayer> Players;
    public ITileBag TileBag;
    public IDictionary Dictionary;
    public int CurrentPlayerIndex;
    public GameStatus Status;
    Func<string, bool> ValidateWord;
    Action<IPlayer> OnTrunAdvanced;

    public GameController(Func<string, bool> validateWord, Action<IPlayer> onTrunAdvanced){
        this.ValidateWord = validateWord;
        this.OnTrunAdvanced = onTrunAdvanced;
    }

    public void StartGame(){
        this.Board = new Board();
        this.Players = new List<IPlayer>();
        this.TileBag = new TileBag();
        this.Dictionary = new Dictionary();
        this.CurrentPlayerIndex = 0;
        this.Status = GameStatus.InProgress;
    }

    public void AdvanceTurn(){
        this.CurrentPlayerIndex = (this.CurrentPlayerIndex + 1) % this.Players.Count;
        this.OnTrunAdvanced(this.Players[this.CurrentPlayerIndex]);
    }

    public void SwapTiles(IPlayer player, List<Tile> tiles){
        player.GetName();
        // this.TileBag.SwapTiles(tiles);
    }

    public void PassTurn(IPlayer player){
        this.AdvanceTurn();
    }

    public void ChallengeWord(IPlayer challenger, string word){
        challenger.GetScore();
    }

}