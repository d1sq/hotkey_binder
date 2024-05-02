using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace mic_switcher_gui;

public partial class AddWindow : Window
{
    public string? TextBoxValue { get; private set; }
    
    public string? ComboBoxValue { get; private set; }
    
    public ObservableCollection<string> AudioDevices { get; set; }

    public AddWindow()
    {
        InitializeComponent();
        AudioDevices = new AudioDeviceManager().GetAudioDevices();
        DataContext = this;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (InputTextBox.IsFocused)
        {
            InputTextBox.Text = e.Key.ToString();
        }
    }

    private void OkButtonClick(object sender, RoutedEventArgs e)
    {
        TextBoxValue = InputTextBox.Text;
        ComboBoxValue = ComboBoxInput.SelectedItem?.ToString();
        
        Close();
    }

    private void CancelButtonClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}