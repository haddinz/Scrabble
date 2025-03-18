interface IPlayer {
    string GetName();
    int GetScore();
    void AddScore(int score);
    List<Tile> Tiles{get; set;}

    void DisplayRack();
    void ShuffleRack();
}