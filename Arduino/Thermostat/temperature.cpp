#include <OneWire.h>

#include <DallasTemperature.h>

#include "Arduino.h"
#include "temperature.h"

OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensors(&oneWire);

DeviceAddress insideThermometer;

void initThermometer() {
        sensors.begin();
	if (!sensors.getAddress(insideThermometer, 0)) Serial.println("Unable to find thermometer, check your connections.");
	sensors.setResolution(insideThermometer, 10);
}  

void requestTempertures() {
  sensors.requestTemperatures();
}

float getTempC() {
	return sensors.getTempC(insideThermometer);
}

float getTempF() {
	return DallasTemperature::toFahrenheit(getTempC());
}
