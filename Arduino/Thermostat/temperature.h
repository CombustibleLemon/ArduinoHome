
#ifndef TEMPERTURE_H_
#define TEMPERTURE_H_

#define ONE_WIRE_BUS 6

void initThermometer();
void requestTempertures();
float getTempC();
float getTempF();

#endif
