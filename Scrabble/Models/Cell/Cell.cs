class Cell {
    public Tile? Tile{get; private set;}
    public bool IsOccupied => this.Tile != null;
    public PremiumSquareType PremiumType;
    public bool IsPremiumUsed{get;}

    public Cell() => Tile = null;

    public void PlaceTile(Tile tile) => this.Tile = tile;
}