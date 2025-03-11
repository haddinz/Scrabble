class Cell {
    public Tile Tile;
    public bool IsOccupied{get; set;}
    public PremiumSquareType PremiumType;
    public bool IsPremiumUsed{get; set;}

    public Cell() {
        this.Tile = null;
        this.IsOccupied = false;
        this.PremiumType = PremiumSquareType.None;
        this.IsPremiumUsed = false;
    }
}