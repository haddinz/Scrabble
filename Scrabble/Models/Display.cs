class Display : IDisplay{

    private string InputValue;

    public Display() {
        this.InputValue = string.Empty;
    }

    public void RenderBoard(GameController gameController) {
        gameController.RenderBoard();
    }

    public void SetMessage(string message) {
        Console.WriteLine(message);
        Console.WriteLine("");
    }

    public void SetInputValue(string value) {
        Console.Write(value);
        this.InputValue = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("");
    }

    public string GetInputValue() {
        return this.InputValue;
    }

    public void DisplayBanner() {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
 ________  ________  ________  ________  ________  ________  ___       _______      
|\   ____\|\   ____\|\   __  \|\   __  \|\   __  \|\   __  \|\  \     |\  ___ \     
\ \  \___|\ \  \___|\ \  \|\  \ \  \|\  \ \  \|\ /\ \  \|\ /\ \  \    \ \   __/|    
 \ \_____  \ \  \    \ \   _  _\ \   __  \ \   __  \ \   __  \ \  \    \ \  \_|/__  
  \|____|\  \ \  \____\ \  \\  \\ \  \ \  \ \  \|\  \ \  \|\  \ \  \____\ \  \_|\ \ 
    ____\_\  \ \_______\ \__\\ _\\ \__\ \__\ \_______\ \_______\ \_______\ \_______\
   |\_________\|_______|\|__|\|__|\|__|\|__|\|_______|\|_______|\|_______|\|_______|
   \|_________|                                                                     
                                                                                    
                                                                                    
        ");
        Console.ResetColor();
        this.SetMessage("Version 1.0 Scrabble Game");
        this.SetMessage("-----------------------------------");
        this.SetMessage("Instructions:");
        this.SetMessage("1. Enter your word to calculate its score.");
        this.SetMessage("2. Type '5' to quit the game.");
    }
}