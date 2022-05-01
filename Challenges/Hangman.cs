//In Hangman, the computer picks a random word for the player to guess.
//The player guesses the word by choosing letters from the alphabet, which get filled in progressively, filling in the word.
//The player can only get so many letters wrong (a letter not found in the game) before losing the game.
//EXAMPLE:
//WORD: _ E _ _ E _ | REMAINING: 5 | INCORRECT: OSR | GUESS: m 

//GAME FLOW:
//The game picks a random word from a list
//The game's state is displayed to the player, as above
//The player can pick a letter. If they pick one they already chose, pick again
//The game should update its state based on the letter that the player picked
//The game needs to detect a win for the player (all letters correctly guessed)
//The game needs to detect a loss for the player (out of incorrect guesses)