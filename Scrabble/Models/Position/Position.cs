class Position {
    public int X {get;}
    public int Y {get;}

    public Position(int x, int y){
        this.X = x;
        this.Y = y;
    }

    public bool IsValid() {
        return this.X >= 0 && this.X <= 15 && this.Y >= 0 && this.Y <= 15;
    }
}