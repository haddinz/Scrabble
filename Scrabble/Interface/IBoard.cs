interface IBoard {
    void Render();
    int PlaceWorld(IPlayer player, Word word);
    Cell GetCell(int x, int y);
    bool IsValidPlacement(Word word);
    bool IsFirstWordPlaced();
    bool IsAdjacentToExisting(Word word);
    // bool IsCentered(Word word);
}