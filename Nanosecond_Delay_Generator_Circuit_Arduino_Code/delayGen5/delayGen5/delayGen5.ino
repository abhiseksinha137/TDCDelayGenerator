
#include <EEPROM.h>
#include <Servo.h>


// Input is of the form [r,s,d][0-9]
// r = rotation stage
// s = servo
// d = delay

// Define the output pins
const int outputPins[] = {3, 4, 5, 6, 7, 8, 9, 10};
const int numPins = sizeof(outputPins) / sizeof(outputPins[0]);

int commandReceived=0;

// Motor Params
#define dirPin 13
#define stepPin 12
int dly=1000; // delay in microseconds
int delayVal=0;
int servoPos=0;
//#define endPin 11

// Servo Params
Servo myservo; 
int servoPin=A5;

void donateDelay(int);

void setup() {
  Serial.begin(9600); // Initialize Serial communication
  // Initialize stepper pins
   pinMode(stepPin, OUTPUT);
   pinMode(dirPin, OUTPUT);

  // Initialize the output pins of delay chip
  for (int i = 0; i < numPins; i++) {
    pinMode(outputPins[i], OUTPUT);
  }

  // Initialize servo
  myservo.attach(servoPin);

  // Initiate Delay
  donateDelay();
}

void loop() {
  digitalWrite (2 ,HIGH); // Enable pin of stepper
  // Prompt the user for input
  //Serial.println("Enter an 8-bit number (0-255):");
  commandReceived=0;
  while (!Serial.available()) {
    // Wait for user input
    commandReceived=1;
  }
  

  String inputStr = Serial.readString();
  if (commandReceived==1)
  {
    delay(300);
    Serial.println("com"+inputStr);
  }  
  char firstChar=inputStr.charAt(0);
  //Serial.println(firstChar);

  if (firstChar=='r')
  { // Rotation Code
    //Serial.println("Rotation");
    String rotStr=inputStr.substring(1);
    long rotVal=rotStr.toInt();
    rotateStage(rotVal);
  }
  if (firstChar=='d')
  { // Delay Code
    //Serial.println("Delay");
    String delayStr=inputStr.substring(1);
    delayVal=delayStr.toInt();
//    Serial.println(delayStr);
    donateDelay();
  }
  if (firstChar=='s')
  { // Servo Code
    // Serial.println("Servo");
    String servoStr=inputStr.substring(1);
    servoPos=servoStr.toInt();
    servo();
  }

   if (firstChar=='t')//tare
   {
     writeStagePos(0, 0);
     updateStatus();
   }
   if (firstChar=='p')//reply with current pos of rotation stage;
   {
    //  long currentPos=readStagePos(0);
    //  Serial.println(currentPos);
      updateStatus();
   }
//  int inputValue = Serial.parseInt(); // Read the user input as an integer


  
//  if (inputValue >= 0 && inputValue <= 255) {
//    // Update the output pins based on the binary representation of the input value
//    for (int i = 0; i < numPins; i++) {
//      digitalWrite(outputPins[i], (inputValue >> i) & 1);
//    }
//    
//    // Display the binary equivalent
//    Serial.print("Binary Equivalent: ");
//    for (int i = 7; i >= 0; i--) {
//      Serial.print((inputValue >> i) & 1);
//    }
//    Serial.println();
//    
//    Serial.print("Output set to: ");
//    Serial.println(inputValue);
//  } else {
//    Serial.println("Invalid input. Enter a number between 0 and 255.");
//  }
//  
//  // Clear the Serial buffer
//  while (Serial.available()) {
//    Serial.read();
//  }
}






void rotateStage(long target)
{
  long currentPos=readStagePos(0);
  long mov=target-currentPos;
  if (mov  > 0){
         
         for(int i=0; i<mov;i++){
           digitalWrite(dirPin, HIGH);
           digitalWrite(stepPin, HIGH);
           delayMicroseconds(dly);
           digitalWrite(stepPin, LOW);
           delayMicroseconds(dly);
         }
         currentPos=readStagePos(0)+mov;
         writeStagePos(0, currentPos);
      }
      if (mov  < 0){
         mov=-mov;
         for(int i=0; i<mov; i++){
           digitalWrite(dirPin, LOW);
           digitalWrite(stepPin, HIGH);
           delayMicroseconds(dly);
           digitalWrite(stepPin, LOW);
           delayMicroseconds(dly);
         }
         currentPos=readStagePos(0)-mov;
         writeStagePos(0, currentPos);
      }
  // currentPos=readStagePos(0);
  // Serial.println(currentPos);
  updateStatus();
}

void donateDelay()
{
  int inputValue=delayVal;
  if (inputValue >= 0 && inputValue <= 255) {
      // Update the output pins based on the binary representation of the input value
      for (int i = 0; i < numPins; i++) {
        digitalWrite(outputPins[i], (inputValue >> i) & 1);
      }
      
      // Display the binary equivalent
//      Serial.print("Binary Equivalent: ");
//      for (int i = 7; i >= 0; i--) {
//        Serial.print((inputValue >> i) & 1);
//      }

      }
  updateStatus();
}


void servo()
{
    myservo.write(servoPos);
    updateStatus();
}


void writeStagePos(int addrOffset, long pos )
{
  String strToWrite=String(pos) ;
  
  byte len = strToWrite.length();
  EEPROM.write(addrOffset, len);
  for (int i = 0; i < len; i++)
  {
    EEPROM.write(addrOffset + 1 + i, strToWrite[i]);
  }
}

long readStagePos(int addrOffset)
{
  int newStrLen = EEPROM.read(addrOffset);
  char data[newStrLen + 1];
  for (int i = 0; i < newStrLen; i++)
  {
    data[i] = EEPROM.read(addrOffset + 1 + i);
  }
  data[newStrLen] = '\ 0'; // !!! NOTE !!! Remove the space between the slash "/" and "0" (I've added a space because otherwise there is a display bug)
  String retStr=String(data);
  long ret=retStr.toInt();
  return ret/10;
}

void updateStatus(){
  Serial.println(String(readStagePos(0))+","+String(delayVal)+","+String(servoPos));
}
//s0/1
//r0-359
//d0-255
