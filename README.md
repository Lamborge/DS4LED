![Logo](https://github.com/Lamborge/DS4LED/blob/main/Assets/icon_hd.ico)

# DS4LED

DS4LED is a program that changes the color of the LED backlight on Dualshock 4

## Requirements
.NET 6.0 Runtime x64 or higher\
PolicyKit(pkexec utility)

## Usage

Select Dualshock HiDraw id in program and click Apply

## Building and running
### Building
```bash
git clone https://github.com/Lamborge/DS4LED.git
cd DS4LED
dotnet publish --configuration Release
```
### Running
```bash
cd bin/Release/net6.0/linux-x64/publish/
./DS4LED
```
