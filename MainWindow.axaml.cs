using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using AvaloniaColorPicker;


namespace DS4LED
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            List<string> LedsID = LocateDevices();
            
            ColorPicker color = this.FindControl<ColorPicker>("colorPicker");
            //TextBox DeviceName = this.FindControl<TextBox>("DeviceName");
            
            var DeviceComboBox = this.FindControl<ComboBox>("DeviceComboBox");
            DeviceComboBox.Items = LedsID;
            DeviceComboBox.SelectedIndex = 0;
        }

        

        /*private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
            
        }*/

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            //string path = $"/sys/class/leds/{DeviceName.Text.ToString()}";
            string path = $"/sys/class/leds/{DeviceComboBox.SelectedItem.ToString()}";

            File.WriteAllText($"{path}:red/brightness", colorPicker.Color.R.ToString());
            File.WriteAllText($"{path}:green/brightness", colorPicker.Color.G.ToString());
            File.WriteAllText($"{path}:blue/brightness", colorPicker.Color.B.ToString());
        }

        List<string> LocateDevices()
        {
            List<string> leds = new List<string>();
            string[] leds_path = Directory.GetDirectories("/sys/class/leds/");
            foreach (string item in leds_path)
            {
                string[] temp = item.Split('/');
                try
                {
                    temp = temp[4].Split(':');
                    leds.Add(temp[0]+":"+temp[1]+":"+temp[2]);
                }
                catch (Exception exception)
                {
                    continue;
                }
            }

            if (leds.Count == 0)
            {
                leds.Add("No Dualshock connected");
            }
            else leds = leds.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            
            return leds;
        }
    }
}