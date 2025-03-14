class Board : IBoard {

    private Cell[,] Grid;
    private bool FirstWorldPlaces;

    public Board() {
        Grid = new Cell[15, 15];
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 15; j++) {
                Grid[i, j] = new Cell();
            }
        }

        this.FirstWorldPlaces = false;
    }

    public void Render() {
        Console.Clear();

        Console.Write("  ");
        for (int j = 0; j < 15; j++) {
            Console.Write((j + 1).ToString().PadLeft(2) + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < 15; i++) {
            Console.Write($"{ i + 1, 2}");
            for (int j = 0; j < 15; j++) {
                if (Grid[i, j].IsOccupied) {
                    Console.Write($"[{Grid[i, j].Tile?.Letter}]");
                } else {
                    Console.Write("[ ]");
                }
            }
            Console.WriteLine();
        }
    }

    public int PlaceWorld(IPlayer player, Word word) {
        int score = 0;

        if(!this.FirstWorldPlaces && !word.GetCoveredPositions().Any(p => p.X == 7 && p.Y == 7)) {
            Console.WriteLine("First word must cover the center position (7, 7).");
            return 0;
        }

        if(FirstWorldPlaces && !IsAdjacentToExisting(word)) {
            Console.WriteLine("New word must be adjacent to an existing word.");
            return 0;
        }

        List<Position> position = word.GetCoveredPositions();
        for(int i = 0; i < word.Tiles.Count; i++) {
            Position pos = position[i];
            Grid[pos.X, pos.Y].PlaceTile(word.Tiles[i]);
        }

        this.FirstWorldPlaces = true;

        foreach(var tile in word.Tiles) {
            score += tile.Value;
        }

        return score;
    }

    public Cell GetCell(int x, int y) => Grid[x, y];

    public bool IsValidPlacement(Word word)
    {
        return true;
    }

    public bool IsAdjacentToExisting(Word word)
    {   
        List<Position> positions = word.GetCoveredPositions();
        foreach(var pos in positions) {
            if (pos.X > 0 && Grid[pos.X - 1, pos.Y].IsOccupied) return true; 
            if (pos.X < 14 && Grid[pos.X + 1, pos.Y].IsOccupied) return true;
            if (pos.Y > 0 && Grid[pos.X, pos.Y - 1].IsOccupied) return true; 
            if (pos.Y < 14 && Grid[pos.X, pos.Y + 1].IsOccupied) return true;
        }
        return false;
    }

    public bool IsFirstWordPlaced(){
        return this.FirstWorldPlaces;
    }

    public bool ValidateWordPlacement(Word word){
        return true;
    }

    public bool IsCentered(Word word)
    {
        return word.Start.X == 7 && word.Start.Y == 7;
    }
}