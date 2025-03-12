class Player : IPlayer{
    private string Name;
    private int Score;
    public List<Tile>? Tiles{get; set;}

    public Player(string name){
        this.Name = name;
        this.Score = 0;
    }

    public string GetName() => this.Name;
    public int GetScore() => this.Score;
    public void AddScore(int score) => this.Score += score;

}