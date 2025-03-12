class Cell {
    public Tile? Tile{get; set;}
    public bool IsOccupied{get; set;}
    public PremiumSquareType PremiumType{get; set;}
    public bool IsPremiumUsed{get;}

    public Cell() {
        this.IsOccupied = false;
        this.PremiumType = PremiumSquareType.None;
        this.IsPremiumUsed = false;
    }

    public void PlaceTile(Tile tile){
        this.Tile = tile;
        this.IsOccupied = true;
    }
}