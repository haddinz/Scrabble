interface IDisplay {
    void RenderBoard(GameController gameController);
    void SetMessage(string message);
    void SetInputValue(string value);
    string GetInputValue();
    void DisplayBanner();
}