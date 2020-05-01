import cv2
import numpy as np
import sys
import time
import re
import threading
from process import Process
import GUI
from webcam import Webcam

from PyQt5 import QtCore
from PyQt5.QtCore import *
from PyQt5.QtGui import *
from PyQt5.QtWidgets import *

import zmq

ex = 0
rate = "Please wait for calibration"

class runGUI(threading.Thread):

    def __init__(self):
        threading.Thread.__init__(self)

    def run(self):
        global ex
        app = QApplication(sys.argv)
        ex = GUI.GUI()
        input = Webcam()
        ex.run(input)


class readBpm(threading.Thread):

    def __init__(self):
        threading.Thread.__init__(self)

    def run(self):
        global ex
        global rate
        rate = float(re.findall("\d+\.\d+", ex.lblHR2.text())[0])


thread_1 = runGUI()

thread_1.start()


context = zmq.Context()
socket = context.socket(zmq.REP)
# socket.bind("tcp://*:5555") = busy adress on my localhost...
socket.bind("tcp://*:4444")


while True:

    socket.recv()
    thread_2 = readBpm()
    thread_2.start()

    socket.send_string(str(rate))
