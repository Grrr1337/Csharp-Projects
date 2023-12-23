# WPF MVVM Architecture Pattern3

## Overview

This project is a third exploration into the MVVM (Model-View-ViewModel) architecture, serving as a training ground for understanding the intricacies of MVVM. The project focuses on creating MVVM sets for the `Animal`, `Car`, and `Person` classes and embedding their respective views into a `mainFrame` control within the main window. Additionally, predefined menu buttons and a toggle button facilitate the seamless transition between active views, and a button (`btnShowAsInstance`) aims to instantiate the active view in a separate window.

## Preview
![WPF MVVM Demo3](WPF%20MVVM%20Demo3.gif)


## Project Structure

The project follows a modular structure with separate folders for views (Views), view models (ViewModels), models (Models), and an optional base folder (Base). Each class has its corresponding view, view model, and model classes.

```plaintext
- MyProject
  - Views
    - AnimalView.xaml
    - CarView.xaml
    - PersonView.xaml
  - ViewModels
    - AnimalViewModel.cs
    - CarViewModel.cs
    - PersonViewModel.cs
  - Models
    - Animal.cs
    - Car.cs
    - Person.cs
  - Base (optional)
    - ViewModelBase.cs
```
 
## Key Features
- **MVVM Sets**: Separate MVVM sets are created for the Animal, Car, and Person classes, promoting modular and maintainable code.

- **View Embedding**: Views for the Animal, Car, and Person classes are embedded into a mainFrame control within the main window, offering a centralized and organized user interface.

- **Dynamic View Switching**: Menu buttons and a toggle button (btnSwitch) enable dynamic switching between active views, providing a flexible user experience.

- **Instantiation of Views**: The btnShowAsInstance button attempts to instantiate the active view in a separate window, though it is currently a work in progress.

- **Efficient Data Transfer**: The project explores efficient data transfer between the main window and embedded views, with a focus on passing data between the main window and separate view instances.

## Key Concepts Learned
- **MVVM Architecture**: Gain a deeper understanding of the Model-View-ViewModel architectural pattern and its application in WPF (Windows Presentation Foundation) projects.

- **View Instantiation**: Explore methods to instantiate views in separate windows while maintaining data coherence between the main window and the new window.

- **Dynamic UI Interaction**: Learn techniques for dynamically switching between views and handling user interactions within the MVVM framework.

- **Data Transfer Efficiency**: Understand strategies for efficiently transferring data between the main window and embedded views, ensuring a responsive and seamless user experience.

## Notes
The `btnShowAsInstance` button is currently **under development and may not function as intended**. Further refinement is needed to achieve the desired instantiation behavior.

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
    cd WPF-MVVM-Architecture-Pattern3
    ```

### Open in Visual Studio

1. Open Visual Studio.

2. Select **File > Open > Project/Solution** and navigate to the cloned project directory.

3. Choose the `WPF MVVM Architecture Pattern3.sln` solution file and click **Open**.

### Build and Run

1. Build the solution by pressing `Ctrl + Shift + B` or selecting **Build > Build Solution** from the menu.

2. Run the project by pressing `F5` or selecting **Debug > Start Debugging** from the menu.

3. The application window will appear, showcasing the custom controls in action.

## Author
Vladimir Balabanov ( **Grrr1337** )

## License
This project is licensed under the MIT License.



