# Custom Controls in WPF

## Overview

This is a training project, that explores the creation and utilization of both `CustomControl` and `UserControl` in WPF (Windows Presentation Foundation). The project contains two main components:

<hr>
<details>
<summary>Project File structure</summary>
1. **MainWindow.xaml and MainWindow.xaml.cs:** The main window of the application that demonstrates the implementation of custom controls. It includes instances of both `FanCustomControl` and `FanUserControl`.

2. **Themes/Generic.xaml:** This file defines the style and appearance of the `FanCustomControl` through a control template.

3. **FanCustomControl.cs:** The code file for the `FanCustomControl` class, which inherits directly from the WPF `Control` class. It includes a `FanOn` property, which represents the on/off state of the fan.

4. **FanUserControl.`xaml`** and **FanUserControl.xaml.`cs`:** These files represent a user control (`FanUserControl`) that incorporates the `FanCustomControl` within it. The user control includes a checkbox (`cbSwitch`) that allows toggling the state of the fan.

</details>
<hr>

#### General Overview about the `Control`, `CustomControl` and `UserControl` classes
<details>
<summary>Summary</summary>

   - The `Control Class` is the base class for all WPF controls.

   - A `Custom Control` is a specialized control created by deriving from existing controls and often involves defining a custom `Control Template`.

   - `Control Templates` define the visual structure and appearance of controls.
   
   - A `User Control` is a composition of existing controls and elements, providing a way to encapsulate and reuse specific UI functionality.
</details>

<details>
<summary>Descriptive explanation</summary>

1. **Control Class**:
   - The `Control` class is a fundamental class in WPF that serves as the base class for all WPF controls.
   - It provides basic functionality for controls, such as layout, focus, and user input handling.

2. **Custom Control**:
   - A `Custom Control` is a control that you create by deriving from existing WPF controls like `Control` or other control classes.
   - You extend the functionality of the base control or combine multiple controls to create a new, specialized control tailored to your application's needs.

3. **Control Templates**:
   - A `Control Template` defines the visual structure and appearance of a control.
   - For a `Custom Control`, you often define a custom `Control Template` to change the default look and behavior of the control.
   - The template includes XAML markup that specifies how the control should be rendered and styled.

4. **User Control Class**:
   - A `User Control Class` is different from a custom control. Instead of deriving from a base control class, a `User Control` is a composition of existing controls and other elements.
   - It is essentially a reusable, composite control that you design visually in XAML and code-behind using other controls.
   - You can think of a `User Control` as a way to encapsulate a specific piece of functionality or UI that you want to reuse in different parts of your application.
</details>

## Preview

![Controls Demo](Controls%20Demo.gif)
 

## Key Concepts Learned

1. **Custom Controls in WPF:**
   - Understanding the difference between `CustomControl` and `UserControl`.
   - Inheriting from the `Control` class when creating a custom control.

2. **Control Templates:**
   - Defining the visual appearance of a custom control using control templates.
   - Using XAML to create a flexible and customizable UI for the `FanCustomControl`.

3. **Dependency Properties:**
   - Implementing the `FanOn` property as a dependency property.
   - Utilizing dependency properties for data binding and property changes.

4. **User Controls:**
   - Creating a `UserControl` that encapsulates the functionality of the `FanCustomControl`.
   - Understanding the hierarchy: `UserControl` -> `ContentControl` -> `Control`.

5. **Data Binding:**
   - Establishing a two-way data binding between the `IsChecked` property of a checkbox (`cbSwitch`) and the `FanOn` property of `FanCustomControl`.

6. **Event Handling:**
   - Handling events such as `Click` and `MouseEnter` to modify the behavior of controls dynamically.

7. **Animation in WPF:**
   - Implementing a simple rotation animation for the `FanCustomControl` when its `FanOn` property is set to `true`.

8. **XAML Structure:**
   - Organizing the XAML structure of the application, including layout panels like `StackPanel` and controls like `Label` and `CheckBox`.



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
    cd Custom-Controls-in-WPF
    ```

### Open in Visual Studio

1. Open Visual Studio.

2. Select **File > Open > Project/Solution** and navigate to the cloned project directory.

3. Choose the `Custom Controls in WPF.sln` solution file and click **Open**.

### Build and Run

1. Build the solution by pressing `Ctrl + Shift + B` or selecting **Build > Build Solution** from the menu.

2. Run the project by pressing `F5` or selecting **Debug > Start Debugging** from the menu.

3. The application window will appear, showcasing the custom controls in action.


Feel free to explore the code in each file, make modifications, and experiment with different properties and behaviors of the custom controls. The project is designed to be a hands-on learning experience for working with custom controls in WPF.


## Author

Vladimir Balabanov aka. **Grrr1337**

## Contributors
 
 This project is based on this tutorial: [How To Create Custom Controls in WPF](https://www.youtube.com/watch?v=t8zB_SYGOF0)

