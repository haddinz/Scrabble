interface IBoard {
    void Render();
    int PlaceWorld(IPlayer player, Word word);
    Cell GetCell(int x, int y);
    bool IsValidPlacement(Word word);
    bool ValidateWordPlacement(Word word);
}