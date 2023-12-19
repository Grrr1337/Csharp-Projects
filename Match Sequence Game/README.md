# Match Sequence Game

Match Sequence Game is a training (WPF) application that challenges players to memorize and match sequences of colored blocks.

## Game Preview
![Match Sequence Game](Match%20Sequence%20Game%20Demo.gif)


## Key Techniques Learned

1. WPF UI Design
    - **XAML Layout:**
        - Utilizes XAML to define the user interface layout and structure.
        - Implements a dynamic grid for displaying colored blocks.

    - **Styling and Theming:**
        - Applies styling to enhance the visual appeal of the game.
        - Utilizes LinearGradientBrush for gradient backgrounds.

2. Data Binding and MVVM
    - **Data Binding:**
        - Implements data binding between XAML elements and C# code.
        - Uses the INotifyPropertyChanged interface for updating UI elements.

    - **MVVM Pattern:**
        - Separates concerns by adopting the Model-View-ViewModel (MVVM) pattern.
        - Leverages data binding to synchronize UI with underlying data.

3. Animation and Timer
    - **WPF Animation:**
        - Implements animation for presenting and hiding sequences of colored blocks.
        - Utilizes DispatcherTimer for managing time-based events.

4. User Interaction
    - **Event Handling:**
        - Handles mouse events for block selection and game interaction.
        - Provides visual feedback with stroke color changes.

    - **TextBox Input Validation:**
        - Validates and restricts input to numeric values using the PreviewTextInput event.

5. Custom Attached Properties
    - **Dependency Properties:**
        - Defines custom attached properties (IsSelected) for tracking block selection.
        - Enhances the UI with dynamic visual feedback for selected blocks.

6. Game Logic and Levels
    - **Game Parameters:**
        - Allows customization of game parameters, including rows, columns, and level.
        - Adjusts difficulty by increasing the number of blocks in the sequence.

    - **Scoring System:**
        - Implements a scoring system based on the player's ability to match the generated sequence.

7. UI Interactivity
    - **Dynamic UI Updates:**
        - Updates UI elements dynamically based on game state and user interaction.
        - Provides informative messages to guide players during the game.



## Key Features

1. Dynamic Grid Generation

2. Sequence Memorization

3. User Interaction

4. Scoring System

5. Game Levels

6. Colorful UI

 
## How to Play

1. **Start Button:**
   - Click the "Start" button to begin a new game with the specified parameters.

2. **Memorize the Sequence:**
   - Observe the animated sequence of colored blocks presented to you.

3. **Match the Sequence:**
   - Click on the blocks in the same order as the generated sequence.

4. **Scoring:**
   - Earn points for correctly matching the sequence.
   - Level up as you successfully complete each round.

5. **Game Over:**
   - The game ends if you fail to match the sequence or after completing a set number of levels.

6. **Restart the Game:**
   - Press the "Start" button again to restart the game and challenge yourself.

## Customization

- Adjust the game parameters by specifying the number of rows, columns, and the initial level.
- One can experiment with different grid layouts and difficulty levels to tailor the game to your preferences.

## Author

Vladimir Balabanov ( **Grrr1337** )

## License

This project is licensed under the MIT License.
