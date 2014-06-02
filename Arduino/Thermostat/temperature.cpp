#include "Arduino.h"
#include "temperature.h"

#include "OneWire.h"
#include "DallasTemperature.h"

OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensors(&oneWire);

DeviceAddress insideThermometer;

void initThermometer() {
	if (!sensors.getAddress(insideThermometer, 0)) Serial.println("Unable to find thermometer, check your connections.");
	 sensors.setResolution(insideThermometer, 10);
}

float getTempC() {
	return sensors.getTempC(insideThermometer);
}

float getTempF() {
	return DallasTemperature::toFahrenheit(getTempC());
}
