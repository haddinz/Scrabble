class Tile {
    public char Letter{get;}
    public int Value{get;}
    public bool IsWildCard{get;}

    public Tile(char letter, int value, bool IsWildCard = false) {
        this.Letter = letter;
        this.Value = value;
        this.IsWildCard = IsWildCard;
    }

}