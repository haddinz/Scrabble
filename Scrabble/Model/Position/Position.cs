class Position {
    public int X;
    public int Y;

    public Position(int x, int y){
        this.X = x;
        this.Y = y;
    }

    public bool IsValid() {
        return this.X >= 0 && this.Y >= 0;
    }
}