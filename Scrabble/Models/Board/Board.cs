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

        // Double Letter (DL)
        Grid[3, 0].PremiumType = PremiumSquareType.DL;
        Grid[11, 0].PremiumType = PremiumSquareType.DL;
        Grid[6, 2].PremiumType = PremiumSquareType.DL;
        Grid[8, 2].PremiumType = PremiumSquareType.DL;
        Grid[0, 3].PremiumType = PremiumSquareType.DL;
        Grid[7, 3].PremiumType = PremiumSquareType.DL;
        Grid[14, 3].PremiumType = PremiumSquareType.DL;
        Grid[2, 6].PremiumType = PremiumSquareType.DL;
        Grid[6, 6].PremiumType = PremiumSquareType.DL;
        Grid[8, 6].PremiumType = PremiumSquareType.DL;
        Grid[12, 6].PremiumType = PremiumSquareType.DL;
        Grid[3, 7].PremiumType = PremiumSquareType.DL;
        Grid[11, 7].PremiumType = PremiumSquareType.DL;
        Grid[2, 8].PremiumType = PremiumSquareType.DL;
        Grid[6, 8].PremiumType = PremiumSquareType.DL;
        Grid[8, 8].PremiumType = PremiumSquareType.DL;
        Grid[12, 8].PremiumType = PremiumSquareType.DL;
        Grid[0, 11].PremiumType = PremiumSquareType.DL;
        Grid[7, 11].PremiumType = PremiumSquareType.DL;
        Grid[14, 11].PremiumType = PremiumSquareType.DL;
        Grid[6, 12].PremiumType = PremiumSquareType.DL;
        Grid[8, 12].PremiumType = PremiumSquareType.DL;
        Grid[3, 14].PremiumType = PremiumSquareType.DL;
        Grid[11, 14].PremiumType = PremiumSquareType.DL;

        // Triple Letter (TL)
        Grid[5, 1].PremiumType = PremiumSquareType.TL;
        Grid[9, 1].PremiumType = PremiumSquareType.TL;
        Grid[1, 5].PremiumType = PremiumSquareType.TL;
        Grid[5, 5].PremiumType = PremiumSquareType.TL;
        Grid[9, 5].PremiumType = PremiumSquareType.TL;
        Grid[13, 5].PremiumType = PremiumSquareType.TL;
        Grid[1, 9].PremiumType = PremiumSquareType.TL;
        Grid[5, 9].PremiumType = PremiumSquareType.TL;
        Grid[9, 9].PremiumType = PremiumSquareType.TL;
        Grid[13, 9].PremiumType = PremiumSquareType.TL;
        Grid[5, 13].PremiumType = PremiumSquareType.TL;
        Grid[9, 13].PremiumType = PremiumSquareType.TL;

        // Double Word (DW)
        Grid[1, 1].PremiumType = PremiumSquareType.DW;
        Grid[2, 2].PremiumType = PremiumSquareType.DW;
        Grid[3, 3].PremiumType = PremiumSquareType.DW;
        Grid[4, 4].PremiumType = PremiumSquareType.DW;
        Grid[10, 10].PremiumType = PremiumSquareType.DW;
        Grid[11, 11].PremiumType = PremiumSquareType.DW;
        Grid[12, 12].PremiumType = PremiumSquareType.DW;
        Grid[13, 13].PremiumType = PremiumSquareType.DW;
        Grid[14, 14].PremiumType = PremiumSquareType.DW;

        // Triple Word (TW)
        Grid[0, 0].PremiumType = PremiumSquareType.TW;
        Grid[7, 0].PremiumType = PremiumSquareType.TW;
        Grid[14, 0].PremiumType = PremiumSquareType.TW;
        Grid[0, 7].PremiumType = PremiumSquareType.TW;
        Grid[14, 7].PremiumType = PremiumSquareType.TW;
        Grid[0, 14].PremiumType = PremiumSquareType.TW;
        Grid[7, 14].PremiumType = PremiumSquareType.TW;
        Grid[14, 14].PremiumType = PremiumSquareType.TW;

        PlaceFisrtWord();
    }

    private void PlaceFisrtWord(){
        string firstWord = "LEARN";
        int startX = 7 - (firstWord.Length / 2);
        int startY = 7;

        for(int i = 0; i < firstWord.Length; i++) {
            // Grid[startX + i, startY].Tile = new Tile(firstWord[i], firstWord[i]);
            Grid[startX + i, startY].Tile = new Tile(firstWord[i]);
            Grid[startX + i, startY].IsOccupied = true;
        }

        this.FirstWorldPlaces = true;
    }

    public void Render() {
        Console.Write("  ");
        for (int j = 0; j < 15; j++) {
            Console.Write((j + 1).ToString().PadLeft(2) + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < 15; i++) {
            Console.Write($"{ i + 1, 2}");
            for (int j = 0; j < 15; j++) {
                if (Grid[i, j].IsOccupied) {
                    Console.Write($" {Grid[i, j].Tile?.Letter} ");
                } else {
                    switch(Grid[i, j].PremiumType) {
                        case PremiumSquareType.DL: 
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" DL");
                            Console.ResetColor();
                            break;
                        case PremiumSquareType.TL:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" TL");
                            Console.ResetColor();
                            break;
                        case PremiumSquareType.DW:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" DW");
                            Console.ResetColor();
                            break;
                        case PremiumSquareType.TW:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" TW");
                            Console.ResetColor();
                            break;

                        default:
                            Console.Write(" . ");
                            break;
                    }
                }
            }
            Console.WriteLine();
        }
    }

    public int PlaceWorld(IPlayer player, Word word) {
        int score = 0;
        int wordMultiplier = 1;

        List<Position> position = word.GetCoveredPositions();

        foreach (var pos in position){
            if (!IsValidPosition(pos.X, pos.Y)){
                Console.WriteLine("Invalid position. The word goes out of bounds.");
                return 0;
            }
        }

        if (!IsValidOverlap(word)){
            Console.WriteLine("Invalid placement. The word overlaps with existing tiles in an invalid way.");
            return 0;
        }

        if(!this.FirstWorldPlaces && !word.GetCoveredPositions().Any(p => p.X == 6 && p.Y == 6)) {
            Console.WriteLine("First word must cover the center position (7, 7).");
            return 0;
        }

        for(int i = 0; i < word.Tiles.Count; i++) {
            Position pos = position[i];
            Grid[pos.X, pos.Y].PlaceTile(word.Tiles[i]);
        }

        this.FirstWorldPlaces = true;

        for (int i = 0; i < word.Tiles.Count; i++) {
            Position pos = position[i];
            int tileScore = word.Tiles[i].Value;

            switch(Grid[pos.X, pos.Y].PremiumType) {
                case PremiumSquareType.DL:
                    tileScore += 2;
                    break;

                case PremiumSquareType.TL:
                tileScore *= 3;
                break;
            }

            switch (Grid[pos.X, pos.Y].PremiumType){
                case PremiumSquareType.DW:
                    wordMultiplier *= 2;
                    break;
                case PremiumSquareType.TW:
                    wordMultiplier *= 3;
                    break;
            }

            score += tileScore;
        }

        return score * wordMultiplier;
    }

    public Cell GetCell(int x, int y) => Grid[x, y];

    public bool IsValidPlacement(Word word){
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

    private bool IsValidOverlap(Word word) {
        List<Position> positions = word.GetCoveredPositions();
        foreach(var pos in positions) {
            if(Grid[pos.X, pos.Y].IsOccupied && Grid[pos.X, pos.Y].Tile?.Letter != word.Tiles[positions.IndexOf(pos)].Letter) {
                return false;
            }
        }

        return true;
    }

    private bool IsValidPosition(int x, int y){
        return x >= 0 && x < 15 && y >= 0 && y < 15;
    }

}