using System;
using System.Collections.Generic;
using System.Linq;

class TileBag : ITileBag {
    public Queue<Tile> Tiles;

    public TileBag() {
        Tiles = new Queue<Tile>();
        Shuffle();
    }

    public List<Tile> DrawTiles(int count) {
        List<Tile> drawnTiles = new();

        while(drawnTiles.Count < count && Tiles.Count > 0) {
            Tile tile = Tiles.Dequeue();
            if(!tile.IsWildCard) {
                drawnTiles.Add(tile);
            }
        }
        
        return drawnTiles;
    }

    public int TilesRemaining() {
        return Tiles.Count;
    }

    public void ReturnTiles(Tile tile) {
        Tiles.Enqueue(tile);
    }

    public void Shuffle() {
        InitializeStandardTiles();

        var random = new Random();
        var tileList = Tiles.ToList();
        for (int i = tileList.Count - 1; i > 0; i--) {
            int j = random.Next(0, i + 1);
            var temp = tileList[i];
            tileList[i] = tileList[j];
            tileList[j] = temp;
        }

        Tiles = new Queue<Tile>(tileList);
    }

    private void InitializeStandardTiles() {
        Tiles = new Queue<Tile>();
        var tileDistribution = new Dictionary<char, int> {
            { 'A', 9 }, { 'B', 2 }, { 'C', 2 }, { 'D', 4 }, { 'E', 12 },
            { 'F', 2 }, { 'G', 3 }, { 'H', 2 }, { 'I', 9 }, { 'J', 1 },
            { 'K', 1 }, { 'L', 4 }, { 'M', 2 }, { 'N', 6 }, { 'O', 8 },
            { 'P', 2 }, { 'Q', 1 }, { 'R', 6 }, { 'S', 4 }, { 'T', 6 },
            { 'U', 4 }, { 'V', 2 }, { 'W', 2 }, { 'X', 1 }, { 'Y', 2 },
            { 'Z', 1 }
        };

        foreach(var entry in tileDistribution) {
            for(int i = 0; i < entry.Value; i++) {
                Tiles.Enqueue(new Tile(entry.Key));
            }
        }

        for(int i = 0; i < 2; i++) {
            Tiles.Enqueue(new Tile(' ', true));
        }
    }

}