# Builder King

### A puzzle game which adapt the difficulty with regard to your stress
The goal of Builder King is simple: stack stones to reach the highest point possible. Your score will dermine if you are the Builder King ! This game will send you in a beautiful island where you will can move freely in an impressive 3D environment.
Builder King is unique by the way the game evolves regarding to your level of stress, the game will become easier or harder if your stress increases or not.

## Requirements
Builder King was tested and is stable on the following OS:
* Windows 10
* Ubuntu 18.04

The game is not currently available on MacOS

To use the heart rate measurement tool, you will need to have a webcam.

## Let's Play!
The easiest way to play Builder King is to execute the following steps
* Go to the [release page](https://github.com/fourastiemarvin/Builder_King/releases) and download the zip adapted to your OS.
* Uncompress the directory 
* Run the heart rate measurement tool (heart_rate_server) and wait until it launched 
* Run the Builder King game and enjoy!!!

If you have any trouble using the heart rate measurment tool, you can play without but the adaptation will be less precise. See [Troubleshooting section](https://github.com/fourastiemarvin/Builder_King#troubleshooting) for more details

### Run directly with the source code
You can use the BuilderKing_vX.X.X directory as a unity project and/or run the heart rate measurement tool with Python 3. To do so, you will need [Python 3](https://www.python.org/downloads/), [CMake](https://cmake.org/download/) and [pip](https://pip.pypa.io/en/stable/installing/). To install all the required libraries, run the following commands after cloning the repository:

```
pip3 install pyzmq
pip3 install -r requirements.txt
```
To run the heart rate measurement tool, write in the terminal:
```
cd Builder_King/Heart-rate-measurement
python3 heart_rate_server.py
```
**NOTE:** depending of your installation you may need to use pip and python instead pip3 and python3
## Troubleshooting
* If you have errors while installing dlib, here a [link](https://stackoverflow.com/a/49538054) to help you
* If you have "adress already in use" error in your terminal while using the heart rate measurement tool, try to restart your computer (must work after that, this problem is not fixed yet)
* Running the game before the heart rate measurement tool can make this last crash. To prevent this, make sure you have launched the heart rate measurement executable before lauching the game.

## Authors
* [Patrick SARDINHA](https://github.com/sardinhapatrick)
* [Marvin FOURASTIE](https://github.com/fourastiemarvin)

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/fourastiemarvin/Builder_King/blob/master/LICENSE.md) file for details



