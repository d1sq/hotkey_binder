using System;
using System.Windows;
using System.Windows.Controls;
using Hardcodet.Wpf.TaskbarNotification;

namespace mic_switcher_gui
{
    public class TrayIconManager
    {
        private readonly Window _mainWindow;
        private readonly TaskbarIcon _taskbarIcon;

        public TrayIconManager(Window mainWindow)
        {
            _mainWindow = mainWindow;

            _taskbarIcon = new TaskbarIcon();
            _taskbarIcon.ToolTipText = "App";
            _taskbarIcon.Visibility = Visibility.Visible;

            // Добавляем контекстное меню
            var menu = new ContextMenu();
            var exitMenuItem = new MenuItem();
            exitMenuItem.Header = "Закрыть";
            exitMenuItem.Click += ExitMenuItem_Click;
            menu.Items.Add(exitMenuItem);

            _taskbarIcon.ContextMenu = menu;

            _taskbarIcon.TrayMouseDoubleClick += TaskbarIcon_DoubleClick;
        }

        private void TaskbarIcon_DoubleClick(object sender, EventArgs e)
        {
            _mainWindow.Show();
            _mainWindow.WindowState = WindowState.Normal;
        }

        // Обработчик клика на кнопке "Выйти из программы"
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}