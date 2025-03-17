class Dictionary : IDictionary {
    public HashSet<string> ValidWords;
    
    public Dictionary(){
        this.ValidWords = new HashSet<string>();
        string[] words = {
            "CAT", "DOG", "HOUSE", "PLAY", "GAME", "SCRABBLE", "WORD", "TILE", "LETTER",
            "BOARD", "SCORE", "TURN", "PASS", "CHALLENGE", "VALID", "INVALID", "QUIZ",
            "JAZZ", "PYTHON", "JAVA", "CODE", "PROGRAM", "COMPUTER", "KEYBOARD", "MOUSE",
            "MONITOR", "DESK", "CHAIR", "TABLE", "LAMP", "BOOK", "PEN", "PAPER", "NOTE",
            "MUSIC", "SONG", "ART", "PAINT", "DRAW", "WRITE", "READ", "LEARN", "TEACH",
            "STUDY", "WORK", "PLAY", "FUN", "HAPPY", "SAD", "ANGRY", "JOY", "LOVE", "HATE",
            "PEACE", "WAR", "FRIEND", "ENEMY", "HELP", "HOPE", "DREAM", "SLEEP", "WAKE",
            "EAT", "DRINK", "COOK", "BAKE", "SWIM", "RUN", "WALK", "JUMP", "DANCE", "SING"
        };

        foreach(string word in words) {
            this.ValidWords.Add(word);
        }
    }
    public bool IsValidWord(string word) => this.ValidWords.Contains(word.ToUpper());
}