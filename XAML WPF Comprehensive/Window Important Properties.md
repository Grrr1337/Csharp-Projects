
# Important properties of **Window**


**Window** refers to a fundamental class that represents a top-level window in a graphical user interface (GUI) application. It's part of the WPF framework provided by Microsoft for building desktop applications on the Windows operating system.

<details>
  <summary>Overview of the Window Class in WPF</summary>

  1. **Top-Level Container:**
      - The `Window` class serves as a container for hosting the visual elements (UI controls) of your application. It represents the main window that users interact with.

  2. **UI Composition:**
      - Inside a `Window`, you can compose your user interface using various XAML elements like buttons, textboxes, grids, and more. The arrangement and behavior of these elements define the user experience.

  3. **Title and Frame:**
      - A `Window` typically includes a title bar at the top, which displays the window's title. It also has standard frame components, including minimize, maximize, and close buttons.

  4. **Properties and Events:**
      - The `Window` class has properties that allow you to control various aspects of the window's appearance and behavior. This includes properties like `Title`, `Width`, `Height`, `WindowState`, and more. Events such as `Loaded`, `Closed`, and `SizeChanged` enable you to respond to user actions and changes in the window's state.

  5. **Window States:**
      - The `WindowState` property of a `Window` allows you to set the initial state of the window, such as normal, minimized, or maximized.

  6. **Styles and Templates:**
      - You can customize the appearance of a `Window` by applying styles and templates. This allows you to create windows with unique designs that align with the visual identity of your application.

  7. **Interaction with Code-Behind:**
      - While the structure and layout of the UI are defined in XAML, the behavior and interactions are often implemented in the code-behind file, typically written in C# or another .NET language.
</details>


## Key properties of **Window**

In WPF, the Window class in XAML has several important properties that allow you to control the appearance and behavior of the application window.
Here are some of the key properties:

### Title:

```xml
<Window Title="My Window" />
```
Specifies the text that appears in the title bar of the window.

### Width and Height:

```xml
<Window Width="400" Height="300" />
```

Defines the width and height of the window.

### MinWidth and MinHeight:

```xml
<Window MinWidth="200" MinHeight="150" />
```
Sets the minimum width and height that the window can be resized to.

### MaxWidth and MaxHeight:

```xml
<Window MaxWidth="800" MaxHeight="600" />
```
Specifies the maximum width and height that the window can be resized to.

### ResizeMode:

```xml
<Window ResizeMode="CanResize" />
```
Determines whether the window can be resized. Possible values include **NoResize**, **CanMinimize**, **CanResize**, and **CanResizeWithGrip**.

### WindowState

```xml
<Window WindowState="Maximized" />
```
- The **WindowState** property defines the initial state of the window. It can take values such as:
    - **Normal**: The window is in its default state.
    - **Minimized**: The window is minimized to the taskbar.
    - **Maximized**: The window is maximized to fill the entire screen.

### WindowStartupLocation

```xml
<Window WindowStartupLocation="CenterScreen" />
```

- The WindowStartupLocation property determines where the window appears when it is first launched. It can take values such as:
    - **CenterOwner**: The window is centered with respect to its owner.
    - **CenterScreen**: The window is centered on the primary screen.
    - **Manual**: You specify the initial position using the Left and Top properties.
    - **CenterWindowsDefault**: The window is centered according to the default behavior of the operating system.

### SizeToContent

```xml
<Window SizeToContent="WidthAndHeight" />
```

- The **SizeToContent** property automatically sizes the window based on its content. It can take values such as:
    - **Manual**: The window size is determined by explicit Width and Height values.
    - **Width**: The window adjusts its width to fit the content.
    - **Height**: The window adjusts its height to fit the content.
    - **WidthAndHeight**: The window adjusts both width and height to fit the content.

### ShowInTaskbar

```xml
<Window ShowInTaskbar="False" />
```

Specifies whether the window appears in the taskbar.

### WindowStyle:

```xml
<Window WindowStyle="SingleBorderWindow" />
```

Specifies the style of the window frame, including values like **SingleBorderWindow** and **None**.

- **SingleBorderWindow**:

    - When you set **WindowStyle** to "SingleBorderWindow," it means that the window will have a standard border around its edges. This includes the typical title bar at the top with the window title, minimize, maximize, and close buttons. Users can resize the window by dragging its borders or corners.
- **Other Possible Values**:

    - Apart from "SingleBorderWindow," the **WindowStyle** property can take other values that alter the appearance of the window frame. For example:
        - **None**: Setting **WindowStyle** to "None" removes the standard window frame altogether. This is useful for creating custom-styled windows that don't have the default title bar and borders. It's often used for creating borderless or custom-shaped windows.
        - **ThreeDBorderWindow**: This style provides a three-dimensional border around the window.
- **Custom Styling**:
    - If you need a custom window frame, you can create your own window style by defining a custom template for the window. This involves creating a set of controls and visual elements that replace or modify the default window frame components

- Example with Custom Style:
<details>

<summary>Click to expand: WindowStyle Example</summary>

```xml
<Window>
    <Window.Style>
        <Style TargetType="Window">
            <Setter Property="WindowStyle" Value="None" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Window">
                        <!-- Define your custom window template here -->
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Style>
</Window>
```
</details>

### Background:

```xml
<Window Background="LightGray" />
```

Sets the background color of the window.

### Topmost:

```xml
<Window Topmost="True" />
```
Determines whether the window is always on top of other windows.

### Icon:

```xml
<Window Icon="/MyApp;component/Resources/MyIcon.ico" />
```
Sets the icon for the window, usually a path to an icon file.

### AllowsTransparency:

```xml
<Window AllowsTransparency="True" />
```
Determines whether the window supports transparency.

## Author

This explanation was carefully gathered and written by **Grrr1337**.
