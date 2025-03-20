# Scrabble Game

This is a console-based Scrabble game implemented in C#. The game allows players to place words on a board, swap tiles, shuffle their racks, and calculate scores based on the standard Scrabble rules.

## Features

- Add players to the game
- Draw tiles from a tile bag
- Place words on the board
- Swap tiles with the tile bag
- Shuffle the player's rack
- Calculate and display scores
- Determine the game winner
- Display a banner with ASCII art

## Getting Started

### Prerequisites

- .NET SDK installed on your machine

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/haddinz/Scrabble.git
    ```

2. Navigate to the project directory:
    ```sh
    cd Scrabble
    ```

3. Build the project:
    ```sh
    dotnet build
    ```

4. Run the project:
    ```sh
    dotnet run
    ```

## Usage

### Main Menu

- The game starts by displaying a banner and the main menu.
- Players can choose to place a word, pass their turn, shuffle their rack, swap tiles, or end the game.

### Placing a Word

- Enter the word you want to place.
- Enter the starting position (X, Y) on the board.
- Indicate whether the word is horizontal or vertical.
- The game will validate the word and its placement, calculate the score, and update the board.

### Swapping Tiles

- Enter the letters of the tiles you want to swap.
- The game will validate the tiles and swap them with new tiles from the tile bag.

### Shuffling the Rack

- The player can shuffle their rack to rearrange the tiles randomly.

### Ending the Game

- The game can be ended at any time, and the final scores will be calculated.
- The game winner will be determined based on the highest score.

## Classes

### Program

- The entry point of the application.
- Manages the game loop and user interactions.

### GameController

- Manages the game state, players, and board.
- Handles actions such as starting the game, advancing turns, placing words, swapping tiles, and ending the game.

### Player

- Represents a player in the game.
- Manages the player's name, score, and tiles.
- Provides methods to display the rack, shuffle the rack, and add score.

### TileBag

- Manages the tiles in the game.
- Provides methods to draw tiles, return tiles, and shuffle the tiles.

### Tile

- Represents a single tile in the game.
- Contains properties for the letter and value of the tile.
- Provides a method to get the value of a tile based on its letter.

### Word

- Represents a word placed on the board.
- Contains a list of tiles and the starting position of the word.
- Provides methods to get the covered positions and check if the word is horizontal or vertical.


### Board

- Represents the game board.
- Manages the placement of tiles and words on the board.
- Provides methods to render the board and validate word placement.

### Display

- Handles the display of messages and input in the console.
- Provides methods to render the board, set messages, and display the banner.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue to discuss any changes or improvements.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
