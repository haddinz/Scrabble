class Dictionary : IDictionary {
    public HashSet<string> ValidWords{get; set;}
    
    public Dictionary(){
        this.ValidWords = new HashSet<string>{"laptop", "computer", "keyboard", "mouse"};
    }
    public bool IsValidWord(string word) => this.ValidWords.Contains(word.ToUpper());
}