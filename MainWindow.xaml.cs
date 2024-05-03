using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace mic_switcher_gui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<string> AudioDevices { get; set; }
    
    public ObservableCollection<BindingDataModel> BindingData { get; set; }
    private TrayIconManager _trayIconManager;
    
    
    protected override void OnClosing(CancelEventArgs e)
    {
        // Перехватываем закрытие окна и скрываем его в трей
        e.Cancel = true;
        Hide();
    }
    public MainWindow()
    {
        InitializeComponent();
        
        BindingData = new ObservableCollection<BindingDataModel>();
        
        _trayIconManager = new TrayIconManager(this);
        
        AudioDevices = new AudioDeviceManager().GetAudioDevices();
        DataContext = this;
        var audioDeviceManager = new AudioDeviceManager();

        audioDeviceManager.SetDefaultCommunicationDevice("Микрофон (3- USB Audio Device)");
    }
    
    

    private void AddButtonClick(object sender, RoutedEventArgs e)
    {
        AddWindow addWindow = new AddWindow();
        addWindow.Owner = this;
        addWindow.ShowDialog();
        
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