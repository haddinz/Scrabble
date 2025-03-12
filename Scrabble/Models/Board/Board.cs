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
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 15; j++) {
                Console.Write(Grid[i, j].IsOccupied ? Grid[i, j].Tile?.Letter : ".");
            }
            Console.WriteLine();
        }
    }

    public int PlaceWorld(IPlayer player, Word word) {
        int score = 0;

        foreach (var position in word.GetCoveredPositions()) {
            Grid[position.X, position.Y].PlaceTile(word.Tiles.First(t => t == word.Tiles[0]));
            score += word.Tiles.Sum(t => t.Value);
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
        return true;
    }

    public bool IsCentered(Word word)
    {
        return word.Start.X == 7 && word.Start.Y == 7;
    }
}