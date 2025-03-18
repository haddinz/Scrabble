class Player : IPlayer{
    private string Name;
    private int Score;
    public List<Tile> Tiles{get; set;}

    public Player(string name){
        this.Name = name;
        this.Score = 0;
        this.Tiles = new List<Tile>();
    }

    public string GetName() => this.Name;
    public int GetScore() => this.Score;
    public void AddScore(int score) => this.Score += score;

    public void DisplayRack() {
        if (Tiles == null || Tiles.Count == 0) {
            Console.WriteLine($"{Name}'s Rack: (Empty)");
        } else {
            Console.WriteLine($"{Name}'s Rack: {string.Join(" ", Tiles?.Select(t => t.Letter) )}");
        }
        Console.WriteLine();
    }

    public void ShuffleRack() {
        Random random = new();
        Tiles = Tiles.OrderBy(t => random.Next()).ToList();
        Console.WriteLine($"{this.Name} rack has been suffle");
    }

}