# WPF INotifyPropertyChanged Project

This project demonstrates the use of the `INotifyPropertyChanged` interface in a WPF application. It includes a simple WPF window with a TextBox and labels, showcasing different scenarios of data binding and property change notifications.

## Preview
![WPF INotifyPropertyChanged](WPF%20INotifyPropertyChanged%20Demo.gif)

## INotifyPropertyChanged Overview

### Purpose

`INotifyPropertyChanged` is an interface in .NET that is crucial for enabling two-way data binding between a data model and a user interface. It allows objects to notify subscribers (like UI elements) when their properties change. This is particularly important in scenarios where changes in the underlying data should be reflected in the UI in real-time.

### Use-Cases

- **WPF and MVVM**: INotifyPropertyChanged is extensively used in WPF (Windows Presentation Foundation) applications, especially when following the MVVM design pattern. It ensures that changes in the model are automatically reflected in the associated views.

- **UI Synchronization**: Any scenario where you need to keep the UI synchronized with changes in the data model benefits from INotifyPropertyChanged. This includes forms, dashboards, and other user interfaces.

- **Validation Scenarios**: When performing data validation, INotifyPropertyChanged can be used to trigger validation checks and update UI elements accordingly.

<details>
<summary><strong>Project Structure and Best Practices</strong></summary>

When working with WPF and utilizing the `INotifyPropertyChanged` interface, it's beneficial to follow certain best practices for project organization and code structure. Here's a recommended approach:

### 1. **Base Class for Property Change Notification:**
   - Create a common base class implementing `INotifyPropertyChanged`. This class will be used to provide property change notifications for all your models.

```csharp
// ObservableObject.cs
class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

### 2. Model Classes:
- Define your model classes, representing entities or data structures in your application.
- Inherit from the ObservableObject base class to inherit property change notification capabilities.
```csharp
// PersonModel.cs
class PersonModel : ObservableObject
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }
}
```
### 3. ViewModels:
- Create ViewModel classes that act as intermediaries between your models and views.
- These classes may contain additional logic, transformation, or aggregation of data for presentation.
```csharp
// PersonViewModel.cs
class PersonViewModel : ObservableObject
{
    private PersonModel _person;

    public string DisplayedName => $"Hello, {_person.Name}!";

    public PersonViewModel(PersonModel person)
    {
        _person = person;
    }
}
```
### 4. Views:
- Create XAML views that define the structure and layout of your user interface.
- Set the DataContext of your views to instances of ViewModel classes or directly to Model instances if needed.
```xml
<!-- MainWindow.xaml -->
<Window.DataContext>
    <local:PersonViewModel/>
</Window.DataContext>

<TextBlock Text="{Binding DisplayedName}"/>
```

### 5. Data Binding in XAML:
- Utilize two-way data binding in XAML to bind UI elements to properties of your ViewModel or Model instances.
- This ensures that changes in the underlying data are automatically reflected in the UI.
```xml
<!-- Example data binding -->
<TextBox Text="{Binding Name}"/>
```

### 6. Separation of Concerns:
- Follow the principles of separation of concerns. Models should focus on representing data, ViewModels on presentation logic, and Views on the user interface.

### 7. Testing and Maintenance:
- This structure facilitates unit testing and makes maintenance more manageable as it isolates concerns in distinct classes.
</details>

## Project Overview

The project consists of the following components:

- **MainWindow.xaml**: The main window of the WPF application, containing a TextBox and labels for demonstrating various UpdateSourceTrigger scenarios.

- **MainWindow.xaml.cs**: The code-behind file for the main window. It initializes the window and handles the MouseDoubleClick event to trigger explicit updates.

- **ObservableObject.cs**: A base class implementing the INotifyPropertyChanged interface. This class provides a common implementation for property change notifications.

- **PersonModel.cs**: A sample model class representing a person with a Name property. It inherits from ObservableObject to leverage property change notifications.
 


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
    cd WPF-INotifyPropertyChanged
    ```

### Open in Visual Studio

1. Open Visual Studio.

2. Select **File > Open > Project/Solution** and navigate to the cloned project directory.

3. Choose the `WPF INotifyPropertyChanged.sln` solution file and click **Open**.

### Build and Run

1. Build the solution by pressing `Ctrl + Shift + B` or selecting **Build > Build Solution** from the menu.

2. Run the project by pressing `F5` or selecting **Debug > Start Debugging** from the menu.

3. Explore the different UpdateSourceTrigger scenarios by interacting with the TextBox and observing the behavior of property updates.



## Author
Vladimir Balabanov ( **Grrr1337** )

## License
This project is licensed under the MIT License.


## Contributors
 
 This project is based on this tutorial: [WPF INotifyPropertyChanged and Databinding](https://www.youtube.com/watch?v=gOf2FZ6dkbU)



 