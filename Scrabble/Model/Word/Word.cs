class Word {
    public List<Tile> Tiles;
    public Position Start;
    public bool IsHorizontal;

    public Word(List<Tile> tiles, Position start, bool isHorizontal){
        this.Tiles = tiles;
        this.Start = start;
        this.IsHorizontal = isHorizontal;
    }
}