# TDCDelayGenerator

This set of programs are used to control a VMI (Velocity Map Imaging) experiment.
## The Experiment

 Two optical elements are used in the experiment.
 1. An SPP (Spiral Phase Plate)
 2. A QWP (QWP)
 **Data Acquisition:**
 3. The TOF and position data from MCP are collected from a TDC in the form of a list mode file (lmf).

## Problem Statement
At each position of the SPP and QWP, the TDC data is acquired for an extended period of time (2-3 hours). Small changes in the laser beam due to changes in power or minute alignment changes can effect the individual runs leading to artifacts in the acquired data.

## Solution

 - The data will be acquired at each position for small duration (~ 3-5 min) for several runs. 
 - The same TDC acquisition file (lmf) will continue throughout the runs. 
 - A delay channel in the TDC is dedicated to distinguish the different parameters of the runs.
 
##  The Circuit
Delay Generator Chip **DS1023-25**
Stepper Motor Chip  **A4988**
A servo motor.
Piezo Rotation Stage :[ **CONEX-AG-PR100P**](https://www.newport.com/f/agilis-piezo-rotation-stages-with-conex-controller)
The circuit is detailed in the directory *./Circuit Details/*

## Circuit Control 
The various components of the circuit are controlled using a microcontroller (Arduino Nano) except for the piezo stage. 
The Arduino Nano code is in the directory *./Nanosecond_Delay_Generator_Circuit_Arduino_Code/delayGen5/delayGen5/*

## Overlord Code
A C# windows forms script is used to control all the elements (circuit elements via arduino) and conducting the Experiment.

