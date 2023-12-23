# WPF MVVM Architecture Pattern2

## Overview

This project is a training exploration of the MVVM (Model-View-ViewModel) architecture pattern in WPF. The primary focus is on understanding how the MVVM pattern works by creating three sets of MVVM implementations for the `Animal`, `Car`, and `Person` classes. These classes represent different entities, each with its own view and view model.

## Preview
![WPF MVVM Demo2](WPF%20MVVM%20Demo2.gif)


## Project Structure

The project follows a typical MVVM structure with separate folders for `Views`, `ViewModels`, and `Models`. Additionally, there is a `Base` folder containing a `ViewModelBase` class, which serves as a base class for view models.

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

## Main Structure

### Main Window Structure
The MainWindow layout consists of a grid with three columns and three rows. Each row is dedicated to hosting the views for `Animal`, `Car`, and `Person`. The Frame elements (`animalDataFrame`, `carDataFrame`, `personDataFrame`) hold the respective views.

### **View Instantiation** and Data Transfer
Three buttons (`btnAnimal`, `btnCar`, `btnPerson`) in the second column trigger the **instantiation of separate windows with corresponding views** and view models. Data transfer between the main window and these views is explored during instantiation.

### **Embedding Views**
The views are seamlessly embedded into the main window's grid structure. **Each view is assigned to a `Frame` element**, creating a modular and organized user interface.

### **User Input Handling**
Notably, the handling of user input differs between the `CarView` and `PersonView` instances. In the `CarView`, user input is confirmed **only upon pressing the "OK" button**, providing a mechanism to review and confirm changes before they take effect. Conversely, in the `PersonView`, user input is immediately reflected, **offering real-time updates without the need for a confirmation step**.

For detailed code examples and implementation details, refer to the provided source code in the project files.

## Efficient Data Passing
Efficient data passing is explored in the project, demonstrating how to pass data between views and view models. This is achieved through proper instantiation of view models and setting the data context of views. The `ViewModelBase` class provides a base implementation of the `INotifyPropertyChanged` interface, facilitating smooth communication between the view models and the views.

## Key Concepts Learned

The main emphasis is on the animation aspect within the MVVM architecture. Views are dynamically embedded into the main window, and separate windows are instantiated to explore data transfer efficiently. Additionally, the user-input handling variations demonstrate flexibility in accommodating different interaction patterns within the MVVM pattern. This approach enables a modular and organized user interface within the MVVM pattern. 

1. **MVVM Implementation**:
    - Explored the MVVM pattern for organizing code in WPF applications.
    - Implemented separate views, view models, and models for `Animal`, `Car`, and `Person` entities.

2. **Data Binding and Notifications**:
    - Demonstrated efficient data binding between views and view models.
    - Implemented the `ViewModelBase` class for streamlined property change notifications.

3. **Separation of Concerns**:
    - Maintained a clear separation of concerns between the user interface (views), presentation logic (view models), and underlying data (models).

4. **Dynamic UI Composition**:
    - Explored assembling the UI by dynamically embedding views into the main window.
    - Utilized frames to host the views and buttons to trigger view instantiation.


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
    cd WPF-MVVM-Architecture-Pattern2
    ```

### Open in Visual Studio

1. Open Visual Studio.

2. Select **File > Open > Project/Solution** and navigate to the cloned project directory.

3. Choose the `WPF MVVM Architecture Pattern2.sln` solution file and click **Open**.

### Build and Run

1. Build the solution by pressing `Ctrl + Shift + B` or selecting **Build > Build Solution** from the menu.

2. Run the project by pressing `F5` or selecting **Debug > Start Debugging** from the menu.

3. The application window will appear, showcasing the custom controls in action.

## Author
Vladimir Balabanov ( **Grrr1337** )

## License
This project is licensed under the MIT License.



