using System;
using System.Collections.Generic;
using System.Linq;

class TileBag : ITileBag {
    public Queue<Tile> Tiles;

    public TileBag() {
        Tiles = new Queue<Tile>();
        InitializeStandardTiles();
    }

    public void InitializeStandardTiles() {
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
                Tiles.Enqueue(new Tile(entry.Key, GetTileValue(entry.Key)));
            }
        }

        // foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ") {
        //     int value = 1;
        //     if ("AEIOULNRST".Contains(letter)){value = 1;}
        //     if ("DG".Contains(letter)){value = 2;}
        //     if ("BCMP".Contains(letter)){value = 3;}
        //     if ("FHVWY".Contains(letter)){value = 4;}
        //     if ("K".Contains(letter)){value = 5;}
        //     if ("JX".Contains(letter)){value = 8;}
        //     if ("QZ".Contains(letter)){value = 10;}
        //     for (int i = 0; i < 2; i++) {
        //         Tiles.Enqueue(new Tile(letter, value, false));
        //     }
        // }

        for(int i = 0; i < 2; i++) {
            Tiles.Enqueue(new Tile(' ', 0, true));
        }
    }

    private int GetTileValue(char letter) {
        var tileValues = new Dictionary<char, int> {
            { 'A', 1 }, { 'B', 3 }, { 'C', 3 }, { 'D', 2 }, { 'E', 1 },
            { 'F', 4 }, { 'G', 2 }, { 'H', 4 }, { 'I', 1 }, { 'J', 8 },
            { 'K', 5 }, { 'L', 1 }, { 'M', 3 }, { 'N', 1 }, { 'O', 1 },
            { 'P', 3 }, { 'Q', 10 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
            { 'U', 1 }, { 'V', 4 }, { 'W', 4 }, { 'X', 8 }, { 'Y', 4 },
            { 'Z', 10 }
        };

        return tileValues.ContainsKey(letter) ? tileValues[letter] : 0;
    }

    public List<Tile> DrawTiles(int count) {
        List<Tile> drawnTiles = new();
        for (int i = 0; i < count; i++) {
            if(Tiles.Count > 0) {
                drawnTiles.Add(Tiles.Dequeue());
            }
        }
        return drawnTiles;
    }

    public int TilesRemaining() {
        return Tiles.Count;
    }

    public void Shuffle() {
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

}