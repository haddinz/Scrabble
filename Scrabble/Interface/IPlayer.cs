interface IPlayer {
    string GetName();
    int GetScore();
    void AddScore(int score);
    List<Tile> Tiles{get;}
}