
/*
   For use with a 20x4 LCD
*/

#include <LiquidCrystal.h>
#include "DallasTemperature.h"
#include "temperature.h"


LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
int temperatureGoal;

void setup() {
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
  float insideTemp = getTempF();
  lcd.print(insideTemp);
  lcd.print("F");
  
  if (insideTemp > 75) {
    // Turn on A/C
  } else {
    // Turn off A/C
  }

  // Gets any messages from serial
  while (Serial.available() > 0) {
    for (int i = 0; i < 2; i++)
    {
      int received = Serial.parseInt();
      if (Serial.available() > 0)
      {
        received = (received * 10) + Serial.parseInt();
      }
    }
    
    // say what you got:
    Serial.print("I received: ");
    Serial.println(receivedData, DEC);
    
    temperatureGoal = received;
  }
  
}
