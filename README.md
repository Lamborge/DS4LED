# ds4led-gui

ds4led-gui is a program that changes the color of the LED backlight on Dualshock 4

## Requirements
.NET Runtime 6.0 x64 or higher

## Usage

Find the Dualshock 4 hidraw id in ```/sys/class/leds``` \
Put it in the program and click Apply

## Building and running
```bash
git clone https://github.com/Lamborge/ds4led-gui.git
cd ds4led-gui
dotnet run
```
