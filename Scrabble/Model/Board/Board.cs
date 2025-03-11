class Board : IBoard {
    Cell[][] Grid = new Cell[15][];
    private bool FirstWorldPlaces;

    public Board() {
        for (int i = 0; i < 15; i++) {
            Grid[i] = new Cell[15];
            for (int j = 0; j < 15; j++) {
                Grid[i][j] = new Cell();
            }
        }
    }

    public void Render() {
        Console.WriteLine("  A B C D E F G H I J K L M N O");
        for (int i = 0; i < 15; i++) {
            for (int j = 0; j < 15; j++) {
                if (j == 0) {
                    Console.Write(i + 1);
                } else if (Grid[i][j].IsOccupied) {
                    Console.Write(Grid[i][j].Tile.Letter);
                } else {
                    Console.Write(" ");
                }
            }
        }
    }

    public int PlaceWorld(IPlayer player, Word word) {
        if (FirstWorldPlaces) {
            FirstWorldPlaces = false;
            if (!Grid[7][7].IsOccupied) {
                return 0;
            }
        }

        return 1;
    }

    public Cell GetCell(int x, int y) {
        return Grid[x][y];
    }
}