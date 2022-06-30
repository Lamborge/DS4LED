using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.IO;
using AvaloniaColorPicker;


namespace Avalonia.NETCoreApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            if (Environment.UserName != "root")
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("title", "Please run app as root!");
                messageBoxStandardWindow.Show();
                //Close();
            } else InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        { 
            ColorPicker color = this.FindControl<ColorPicker>("colorPicker");
            TextBox DeviceName = this.FindControl<TextBox>("DeviceName");

            string path = $"/sys/class/leds/{DeviceName.Text}";

            File.WriteAllText($"{path}:red/brightness", colorPicker.Color.R.ToString());
            File.WriteAllText($"{path}:green/brightness", colorPicker.Color.G.ToString());
            File.WriteAllText($"{path}:blue/brightness", colorPicker.Color.B.ToString());
        }
    }
}