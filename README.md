# DS4LED

DS4LED is a program that changes the color of the LED backlight on Dualshock 4

## Requirements
.NET Runtime 6.0 x64 or higher\
Policykit(pkexec)

## Usage

Find the Dualshock 4 hidraw id in ```/sys/class/leds``` (like ```0005:054C:05C4.0009```)\
Put it in the program and click Apply

## Building and running
```bash
git clone https://github.com/Lamborge/DS4LED.git
cd DS4LED
dotnet build
```
