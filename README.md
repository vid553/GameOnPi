# GameOnPi
Play games on Raspberry Pi with Moonlight \
\
GameOnPi offers users to play their PC games on Raspberry Pi without typing Moonlight commands. \
Made for Windows using .NET framework with [SSH.NET](https://github.com/sshnet/SSH.NET) and [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) libraries.  \
Language of the app is Slovenian, will be translated to English soon. \
It uses Moonlight embedded library: https://github.com/irtimmer/moonlight-embedded

### Features
* Home - display list of all available games with their covers
* Connect - connecting, disconnecting, pairing and unpairing PC with Rpi
* Settings - all moonlight settings can be configured here, users can also turn off display of game covers (because they are downloaded from internet)

### Requirements
* Nvidia Graphic card (at least GTX 650 or GTX 700M)
* Raspberry Pi (3 B+ recommended)

### Install Instructions
* Install .NET framework 4.6.1
* Install Nvidia Geforce Experience
* Open GeForce Experience and go to Settings/Shield and turn on GameStream
* Install Moonlight on Rpi with my app InstallOnPi: https://github.com/vid553/InstallOnPi
* Download release and run it

## License
Project is licensed under [GNU GENERAL PUBLIC LICENSE v3](http://www.gnu.org/licenses/gpl-3.0.en.html). \
Uses icon made by Freepik from www.flaticon.com and background images from www.pexels.com
