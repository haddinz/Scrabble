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
        foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ") {
            int value = 1;
            if ("AEIOULNRST".Contains(letter)){value = 1;}
            if ("DG".Contains(letter)){value = 2;}
            if ("BCMP".Contains(letter)){value = 3;}
            if ("FHVWY".Contains(letter)){value = 4;}
            if ("K".Contains(letter)){value = 5;}
            if ("JX".Contains(letter)){value = 8;}
            if ("QZ".Contains(letter)){value = 10;}
            for (int i = 0; i < 2; i++) {
                Tiles.Enqueue(new Tile(letter, value, false));
            }
        }
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
        List<Tile> shuffledTiles = Tiles.ToList();
        // shuffledTiles.Shuffle();
        Tiles = new Queue<Tile>(shuffledTiles);
    }

}