class Player : IPlayer{
    public string Name{get; set;}
    public int Score{get; set;}

    public Player(string name){
        this.Name = name;
        this.Score = 0;
    }

    public string GetName(){
        return this.Name;
    }

    public int GetScore(){
        return this.Score;
    }
}