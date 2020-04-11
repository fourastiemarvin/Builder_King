#!/usr/bin/env bash

if [[ -e heart_rate.dat ]]; then
  rm heart_rate.dat
fi

python3 GUI.py
