using System.Windows;
using System.Collections.ObjectModel;



namespace mic_switcher_gui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<string> AudioDevices { get; set; }
    
    public ObservableCollection<BindingDataModel> BindingData { get; set; }

    
    public MainWindow()
    {
        InitializeComponent();
        
        BindingData = new ObservableCollection<BindingDataModel>();

        AudioDevices = new AudioDeviceManager().GetAudioDevices();
        DataContext = this;
    }


    private void AddButtonClick(object sender, RoutedEventArgs e)
    {
        AddWindow addWindow = new AddWindow();
        addWindow.Owner = this;
        addWindow.ShowDialog();
        
        Console.WriteLine(addWindow.TextBoxValue);
        Console.WriteLine(addWindow.ComboBoxValue);

       
        BindingData.Add(new BindingDataModel {Device = addWindow.TextBoxValue, Hotkey = addWindow.ComboBoxValue});
        
    }
    
    private void RemoveButtonClick(object sender, RoutedEventArgs e)
    {
        BindingDataModel selectedItem = (BindingDataModel)DataGrid.SelectedItem;

        if (selectedItem != null)
        {
            BindingData.Remove(selectedItem);
        }
    }
}

/*
 * При нажатии на + открывать новое окно с хоткеем и девайсом и крестиком/галочкой
 * после ввода девайс помещать в окно с колонками
 * сделать увод в трей
 * и где то хранить сохраненное
 * также сделать старт при запуске винды
 * 
 *
 *
 * 
 */