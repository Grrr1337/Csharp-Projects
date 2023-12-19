# Catch Me Game

Catch Me Game is a simple training C# WPF application that challenges the player to catch the falling items. In this project I have implemented some key game development concepts using WPF.

## Preview
![Catch Me Game](Catch%20Game%20Demo.gif)


## Key Techniques Learned

1. **Player-Controlled Net:**
   - Implemented mouse tracking to control a net within the game window.
   - Utilized the `MouseMove` event to update the net's position based on the mouse cursor.

2. **Dynamic Item Generation:**
   - Generated various falling items at runtime.
   - Utilized randomization to determine the type and initial position of each falling item.

3. **Scoring System:**
   - Implemented a scoring mechanism to keep track of the number of items caught.
   - Updated the UI to display the current score in real-time.

4. **Missed Items Counter:**
   - Implemented a counter for missed items to track the player's performance.
   - Displayed the number of missed items on the UI.

5. **Dynamic Difficulty Adjustment:**
   - Increased the game difficulty dynamically as the player's score progressed.
   - Adjusted the falling speed or introduced additional challenges based on the player's performance.

6. **Game Over State:**
   - Implemented a game over state when the player missed a certain number of items.
   - Provided visual feedback and information about the player's performance.

7. **Visual Feedback:**
   - Incorporated background images and visual elements to enhance the gaming experience.
   - Utilized image resources for the net, falling items, and background.

## How to Play

1. **Catch the Items:**
   - Move the net using the mouse to catch falling items.

2. **Score:**
   - The score is displayed as the number of items caught.

3. **Missed Items:**
   - Keep an eye on the number of items that pass through without being caught.

4. **Game Over:**
   - The game ends if the number of missed items exceeds a certain limit.

5. **Restart the Game:**
   - Press Enter or Space to exit and restart the game.

## Author

Vladimir Balabanov ( **Grrr1337** )

## License

This project is licensed under the MIT License.
