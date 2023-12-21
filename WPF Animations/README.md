# WPF Animations

This project is a training one that delves into the realm of animations in WPF. The project provides a basic exploration of animations, both from the XAML markup perspective and through code-behind implementation. Whether you're interested in declarative animations in XAML or dynamic animations in C#, this project covers it all.

<details>
  <summary><strong>How animations work in XAML</strong></summary>

  ## There are two Main Approaches

  There are two primary approaches to implementing animations in WPF:

  1. **XAML Animations:**
     - Animations in XAML are defined using **Storyboards**, which encapsulate animation controls.
     - **Triggers** play a crucial role in XAML animations, specifying conditions that trigger animations. Triggers can be categorized into property triggers, event triggers, and data triggers.
     - Triggers enable the definition of two types of actions:
       - **Enter Actions:** Executed when a specified condition is met.
       - **Exit Actions:** Executed when the specified condition is no longer met.

  2. **Code-Behind Animations:**
     - Code-behind animations involve using animation classes provided by WPF, such as `DoubleAnimation` and `ColorAnimation`.
     - Animations are instantiated and applied directly in the code-behind file, allowing for dynamic and programmatic control.

  ## XAML Animation Example

  Consider the following XAML snippet, which demonstrates a simple button animation:

  ```xaml
  <Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

      <Button Content="Click me">
          <Button.Triggers>
              <EventTrigger RoutedEvent="Button.MouseEnter">
                  <BeginStoryboard>
                      <Storyboard>
                          <!-- Define animations here -->
                          <DoubleAnimation To="130" Duration="0:0:0.3" Storyboard.TargetProperty="Width"/>
                          <DoubleAnimation To="150" Duration="0:0:0.3" Storyboard.TargetProperty="Height"/>
                          <ColorAnimation To="MediumSlateBlue" Duration="0:0:0.3" Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"/>
                      </Storyboard>
                  </BeginStoryboard>
              </EventTrigger>
              <EventTrigger RoutedEvent="Button.MouseLeave">
                  <BeginStoryboard>
                      <Storyboard>
                          <!-- Define animations for mouse leave -->
                          <!-- ... -->
                      </Storyboard>
                  </BeginStoryboard>
              </EventTrigger>
          </Button.Triggers>
      </Button>

  </Window>
```

The above example showcases the usage of XAML animations with triggers, defining animations for both mouse enter and mouse leave events.

</details>

## Preview
![WPF Animations](WPF%20Animations%20Demo.gif)


## Key Concepts Learned

### 1. Declarative XAML Animations
- **Button Hover Effects:**
  - Implements smooth and visually appealing hover effects using XAML triggers.
  - Utilizes `DoubleAnimation` to dynamically adjust button size.
  - Demonstrates `ColorAnimation` for seamless background color transitions.

### 2. Dynamic Code-Behind Animations
- **Interactive Button Animations:**
  - Responds to mouse enter and leave events to trigger dynamic animations in code-behind.
  - Utilizes `DoubleAnimation` and `ColorAnimation` to create engaging button interactions.

### 3. Window Dragging with Animation
- **Draggable Window Enhancement:**
  - Implements interactive window dragging with a smooth animation effect.
  - Enhances user experience by providing an animated window movement.

### 4. Stylish Button Customization
- **Button Styling Techniques:**
  - Showcases styling approaches for buttons in both XAML and code-behind.
  - Utilizes templates to customize button appearance while maintaining animation responsiveness.

### 5. Event-Driven Animation Handling
- **Mouse Events for Animation Control:**
  - Efficiently handles mouse events (e.g., `MouseEnter` and `MouseLeave`) to control animations.
  - Achieves a cohesive user experience through event-driven animation management.


## Getting Started

### Prerequisites

- **Visual Studio:** This project is developed using Visual Studio, and it is recommended to have Visual Studio installed for a seamless development experience.
  
- **.NET Framework 4.8:** Ensure that you have the .NET Framework 4.8 installed on your development machine. You can download it from the [official Microsoft site](https://dotnet.microsoft.com/download/dotnet-framework/net48).

### Clone the Repository

1. Clone this repository to your local machine using the following command:

    ```bash
    git clone https://github.com/Grrr1337/Csharp-Projects.git
    ```

2. Navigate to the project directory:

    ```bash
    cd WPF-Drawing
    ```

### Open in Visual Studio

1. Open Visual Studio.

2. Select **File > Open > Project/Solution** and navigate to the cloned project directory.

3. Choose the `WPF Animations.sln` solution file and click **Open**.

### Build and Run

1. Build the solution by pressing `Ctrl + Shift + B` or selecting **Build > Build Solution** from the menu.

2. Run the project by pressing `F5` or selecting **Debug > Start Debugging** from the menu.

3. The application window will appear, showcasing the custom controls in action.

## Author
Vladimir Balabanov ( **Grrr1337** )

## License
This project is licensed under the MIT License.


## Contributors
 
 This project is based on this tutorial: [How to Create Engaging Animations in WPF using Storyboards and Code-Behind](https://www.youtube.com/watch?v=qK90unxfrXw)

