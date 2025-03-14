class Word {
    public List<Tile> Tiles{get;}
    public Position Start{get;}
    public bool IsHorizontal{get;}

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
        for (int i = 0; i < this.Tiles.Count; i++) {
            int x = Start.X + (IsHorizontal ? i : 0);
            int y = Start.Y + (IsHorizontal ? 0 : i);
            positions.Add(new Position(x, y));
        }

        return positions;
    }

    public override string ToString(){
        return new string(Tiles.Select(t => t.Letter).ToArray());
    }
}