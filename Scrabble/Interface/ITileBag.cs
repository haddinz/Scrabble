interface ITileBag {
    List<Tile> DrawTiles(int count);
    int TilesRemaining();

    void ReturnTiles(Tile tile);
}