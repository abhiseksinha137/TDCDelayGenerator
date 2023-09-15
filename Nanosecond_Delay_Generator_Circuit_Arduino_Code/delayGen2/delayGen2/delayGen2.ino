
#include <EEPROM.h>
#include <Servo.h>


// Input is of the form [r,s,d][0-9]
// r = rotation stage
// s = servo
// d = delay

// Define the output pins
const int outputPins[] = {3, 4, 5, 6, 7, 8, 9, 10};
const int numPins = sizeof(outputPins) / sizeof(outputPins[0]);

// Motor Params
#define dirPin 13
#define stepPin 12
int dly=1000; // delay in microseconds
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
}

void loop() {
  digitalWrite (2 ,HIGH); // Enable pin of stepper
  // Prompt the user for input
  //Serial.println("Enter an 8-bit number (0-255):");
  
  while (!Serial.available()) {
    // Wait for user input
  }
  String inputStr = Serial.readString();
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
    int delayVal=delayStr.toInt();
//    Serial.println(delayStr);
    donateDelay(delayVal);
  }
  if (firstChar=='s')
  { // Servo Code
    // Serial.println("Servo");
    String servoStr=inputStr.substring(1);
    int servoVal=servoStr.toInt();
    servo(servoVal);
  }

   if (firstChar=='t')//tare
   {
     writeStagePos(0, 0);
   }
   if (firstChar=='p')//reply with current pos of rotation stage;
   {
     long currentPos=readStagePos(0);
     Serial.println(currentPos);
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
  currentPos=readStagePos(0);
  Serial.println(currentPos);
}

void donateDelay(int inputValue)
{
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
}


void servo(int val)
{
    myservo.write(val);
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
//s0/1
//r0-359
//d0-255
