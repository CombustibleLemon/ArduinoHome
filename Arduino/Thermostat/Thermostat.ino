
/*
   For use with a 20x4 LCD
*/

#include <LiquidCrystal.h>
#include <DallasTemperature.h>
#include <OneWire.h>
#include "temperature.h"

#define RELAY_HEATER 8
#define RELAY_COMPRESSOR 9
#define RELAY_BLOWER 10

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
int temperatureGoal = 72;
boolean blowerState;

void setup() {
  pinMode(RELAY_HEATER, OUTPUT);
  pinMode(RELAY_COMPRESSOR, OUTPUT);
  pinMode(RELAY_BLOWER, OUTPUT);
  
  Serial.begin(9600);
  Serial.println("Setup...");
  initThermometer();
  lcd.begin(20, 4);/*
  lcd.setCursor(1, 0);
  lcd.print(" === == == == === ");
  lcd.setCursor(1, 1);
  lcd.print(": I'M A REAL BOY :");
  lcd.setCursor(1, 2);
  lcd.print(": YOUNG COCONUTS :");
  lcd.setCursor(1, 3);
  lcd.print(" === == == == === ");
  */
  delay(2000);
  
  Serial.println("");
}

void loop() {
  checkTemperature();
  receiveFromSerial();
  
}

void checkTemperature() {
  requestTempertures();
  // Display current temperature on LCD
  lcd.setCursor(1,1);
  lcd.print("Inside Temp: ");
  //lcd.setCursor(1,2);
  float temp = getTempF();
  lcd.print(temp);
  lcd.setCursor(1,2);
  lcd.print("Target Temp: ");
  lcd.print(temperatureGoal);
  //lcd.print("F");
  
  // If is too cold, activate the heater
  if (int(temp) < (temperatureGoal - 2)) {
    activateHeaterCompressor(RELAY_HEATER);
  }
  
  // If is too hot, activate the compressor
  if (int(temp) > (temperatureGoal + 2)) {
    activateHeaterCompressor(RELAY_COMPRESSOR);
  }
  
  // If it is normal, turn off the  blower
  if (int(temp) < (temperatureGoal + 2)
   && int(temp) > (temperatureGoal - 2)) {
     toggleBlower(false);
   }     
}

// Gets any messages from serial
void receiveFromSerial() {
  while (Serial.available() > 0) {
    // Read one byte from serial buffer
    byte receivedData = Serial.read();
    //int receivedData = Serial.parseInt();
    // Process anything received
    processSerialInput(receivedData);
  }
}

// Does basic activity based on the input from serial
void processSerialInput(int serialInput) {
  String message;
  
  if (serialInput < 0 || serialInput > 4) {
    return;
  } else if (serialInput == 0) {      // TEMPERATURE_INCREASE
    temperatureGoal++;
  } else if (serialInput == 1) {      // TEMPERATURE_DECREASE
    temperatureGoal--;
  } else if (serialInput == 2) {      // TEMPERATURE_GOAL
    message = String(temperatureGoal);
    Serial.println(message);
  } else if (serialInput == 3) {      // TEMPERATURE_CURRENT
    float bigger = getTempF() * 100;
    int integerified = int(bigger);
    message = String(integerified);
    Serial.println(message);
  } else if (serialInput == 4) {      // TEMPERATURE_BLOWER
    if (blowerState) {
      Serial.println("on");
    } else {
      Serial.println("off");
    }
  }
}

// Turns the blower either off or on
void toggleBlower(boolean state) {
  if (!state) {
    digitalWrite(RELAY_BLOWER, HIGH);
  } else {
    digitalWrite(RELAY_BLOWER, LOW);
  }
  
  blowerState = state;
}

// Turns (heater | compressor) (on | off)
void activateHeaterCompressor(int relayPin) {
  if (relayPin != RELAY_HEATER         // If pin is not for this
  && relayPin != RELAY_COMPRESSOR) {
    return;
  }
  
  deactivateHeaterCompressor();
  digitalWrite(relayPin, HIGH);
}

// Turns off heater & compressor
void deactivateHeaterCompressor () {
  digitalWrite(RELAY_HEATER, LOW);
  digitalWrite(RELAY_COMPRESSOR, LOW);
}
