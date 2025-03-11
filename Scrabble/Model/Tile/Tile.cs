class Tile {
    public char Letter;
    public int Value;
    public bool IsWildCard;

    public Tile(char letter, int value, bool IsWildCard) {
        this.Letter = letter;
        this.Value = value;
        this.IsWildCard = IsWildCard;
    }

}