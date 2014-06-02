
/*
   For use with a 20x4 LCD
*/

#include <LiquidCrystal.h>
#include "DallasTemperature.h"
#include "temperature.h"


LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

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

  // put your main code here, to run repeatedly:

}
