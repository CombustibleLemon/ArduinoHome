
/*
   For use with a 20x4 LCD
*/

#include <LiquidCrystal.h>
#include "DallasTemperature.h"
#include "temperature.h"

#define RELAY_HEATER 8
#define RELAY_COMPRESSOR 9
#define RELAY_BLOWER 10

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
int temperatureGoal;
boolean

void setup() {
  pinMode(RELAY_HEATER, OUTPUT);
  pinMode(RELAY_COMPRESSOR, OUTPUT);
  pinMode(RELAY_BLOWER, OUTPUT);
  
  Serial.begin(9600);
  Serial.println("Setup...");
  initThermometer();
  lcd.begin(20, 4);
  lcd.setCursor(1, 0);
  lcd.print(" === == == == === ");
  lcd.setCursor(1, 1);
  lcd.print(": I'M A REAL BOY :");
  lcd.setCursor(1, 2);
  lcd.print(": YOUNG COCONUTS :");
  lcd.setCursor(1, 3);
  lcd.print(" === == == == === ");
  delay(2000);
  
  Serial.println("");
}

void loop() {
  lcd.setCursor(1,3);
  lcd.print("Inside Temp: ");
  lcd.print(getTempF());
  lcd.print("F");
  
  if (insideTemp > 75) {
    // Turn on A/C
  } else {
    // Turn off A/C
  }

  // Gets any messages from serial
  while (Serial.available() > 0) {
    int receivedData = Serial.parseInt);
    
    if (receivedData < -1 || receivedData > 1)
    {
      receivedData
    }
    
    // say what you got:
    Serial.print("I received: ");
    Serial.println(receivedData, DEC);
    
    temperatureGoal += receivedData;
  }
}

void processSerialInput(int serialInput) {
  if (serialInput < -1 || serialInput > 3) {
    return;
  } else if (serialInput == 0) {
    toggleBlower();
  } else {
    
  }
}

void checkTemperature(

void toggleBlower() {
  if (blowerState == false) {
    digitalWrite(RELAY_BLOWER, HIGH);
  } else {
    digitalWrite(RElAY_BLOWER, LOW);
  }
  
  blowerState = !blowerState;
}
void activateHeaterCompressor(int relayPin) {
  if (relayPin != RELAY_HEATER         // Pin is not for this
  && relayPin != RELAY_COMPRESSOR) {
    return;
  }
  
  digitalWrite(RELAY_HEATER, LOW);
  digitalWrite(RELAY_COMPRESSOR, LOW);
  digitalWrite(relayPin, HIGH);
}
  
