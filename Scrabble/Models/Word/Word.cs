class Word {
    public List<Tile> Tiles{get; private set;}
    public Position Start{get; private set;}
    public bool IsHorizontal{get; private set;}

    public Word(List<Tile> tiles, Position start, bool isHorizontal){
        if (tiles == null || tiles.Count == 0) {
            throw new ArgumentException("Word must have at least one tile");
        }

        this.Tiles = tiles;
        this.Start = start;
        this.IsHorizontal = isHorizontal;
    }

    public List<Position> GetCoveredPositions(){
        List<Position> positions = new List<Position>();
        if(this.IsHorizontal){
            for(int i = 0; i < this.Tiles.Count; i++){
                positions.Add(new Position(this.Start.X + i, this.Start.Y));
            }
        } else {
            for (int i = 0; i < this.Tiles.Count; i++) {
                positions.Add(new Position(this.Start.X, this.Start.Y + 1));
            }
        }

        return positions;
    }
}