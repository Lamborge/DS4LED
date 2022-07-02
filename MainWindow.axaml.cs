using Avalonia.Controls;
using Avalonia.Interactivity;

namespace DS4LED
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DeviceComboBox.Items = LocateDevices();
            DeviceComboBox.SelectedIndex = 0;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            //string path = $"/sys/class/leds/{DeviceName.Text.ToString()}";
            string path = $"/sys/class/leds/{DeviceComboBox.SelectedItem}";


            try
            {
                File.WriteAllText($"{path}:red/brightness", ColorPicker.Color.R.ToString());
                File.WriteAllText($"{path}:green/brightness", ColorPicker.Color.G.ToString());
                File.WriteAllText($"{path}:blue/brightness", ColorPicker.Color.B.ToString());
            }
            catch
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("title", "Incorrect HiDraw Dualshock ID! \n (maybe he not connected)");
                messageBoxStandardWindow.Show();
            }
            
        }

        private void Refresh_OnLick(object? sender, RoutedEventArgs routedEventArgs)
        {
            DeviceComboBox.Items = LocateDevices();
            DeviceComboBox.SelectedIndex = 0;
        }

        private static List<string> LocateDevices()
        {
            List<string> led = new List<string>();
            string[] ledPath = Directory.GetDirectories("/sys/class/leds/");
            foreach (var item in ledPath)
            {
                string[] temp = item.Split('/');
                temp = temp[4].Split(':');
                led.Add(temp[0] + ":" + temp[1] + ":" + temp[2]);
            }


            led = led.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            if (led.Count == 0) led.Add("No Dualshock connected");
            
            return led;
        }
    }
}