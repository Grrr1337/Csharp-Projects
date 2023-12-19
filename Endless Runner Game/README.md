# Endless Runner Game

Endless Runner Game is a simple C# WPF application that implements an endless runner game. In this game, the player controls a character that automatically runs forward, and the goal is to jump over obstacles to avoid collisions and survive as long as possible.

![Endless Runner Game](Runner%20Game%20Demo.gif)

## Key Techniques Learned

1. **WPF (Windows Presentation Foundation):**
   - Leveraged WPF for creating a desktop application with a rich and interactive user interface.

2. **XAML (eXtensible Application Markup Language):**
   - Used XAML to declaratively define the structure and appearance of the UI.

3. **Animation using DispatcherTimer:**
   - Implemented game loop using `DispatcherTimer` for smooth and consistent updates.

4. **Sprite Animation:**
   - Created sprite animation for the player character using a series of images to simulate movement.

5. **Background Scrolling:**
   - Implemented scrolling background to create a sense of continuous movement.

6. **Collision Detection:**
   - Implemented collision detection between the player, obstacles, and the ground.

7. **User Input Handling:**
   - Captured keyboard input using `KeyDown` and `KeyUp` events to enable player interaction.

8. **Randomized Obstacle Generation:**
   - Generated obstacles at random positions to add variety and challenge to the game.

9. **Dynamic Label Update:**
   - Dynamically updated a Label (`lblScore`) to display the player's score in real-time.

10. **Game Over State and Visual Feedback:**
    - Implemented a game over state with visual feedback, including color changes for player and obstacle rectangles, and a label with a fade-in and fade-out animation.


## Features

1. Infinite Runner Gameplay
2. Obstacle Avoidance
3. Dynamic Background
4. Scoring System

## Controls

- Press the **Space key** to make the player character jump over obstacles.
- Press **Enter key** to start a new game if the player loses.

## Notes

- Adjust the obstacle positions and background size based on your game assets.
- Ensure the necessary permissions for keyboard input in your development environment.

## Author

Vladimir Balabanov ( **Grrr1337** )

## License

This project is licensed under the MIT License.
