class Board : IBoard {
    private readonly Cell[,] Grid = new Cell[15, 15];
    private bool FirstWorldPlaces;

    public Board() {
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 15; j++) {
                Grid[i, j] = new Cell();
            }
        }
    }

    public void Render() {
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 15; j++) {
                Console.Write(Grid[i, j].IsOccupied ? "[X]" : "[ ]");
            }
            Console.WriteLine();
        }
    }

    public int PlaceWorld(IPlayer player, Word word) {
        var positions = word.GetCoveredPositions();
        foreach(var pos in word.GetCoveredPositions()) {
            if(pos.IsValid()){
                Grid[pos.X, pos.Y].PlaceTile(new Tile('A', 1));
            }
        }

        return 0;
    }

    public Cell GetCell(int x, int y) => Grid[x, y];
}