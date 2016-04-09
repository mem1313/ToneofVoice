// Global variables declarations:
const int numReadings = 30;
int readings[numReadings];      // the readings from the analog input
int readIndex = 0;              // the index of the current reading
int total = 0;                  // the running total
int average = 0;                // the average
int inputPin = A0;
int sensorValue = 0;
int twitch = 0;
unsigned int adcReadPrev = 0;
unsigned int adcReadNow = 0;

// Function prototypes declarations:
void findaverage();
void bigenough();

// Program starts:
void setup()
{
  Serial.begin(9600);

  // initialize all the readings to 0:
  for (int thisReading = 0; thisReading < numReadings; thisReading++)
  {
    readings[thisReading] = 0;
  }
}

// Main loop starts:
void loop() {

  // subtract the last reading:
  total = total - readings[readIndex];

  // read from the sensor:
  readings[readIndex] = analogRead(inputPin);

  // add the reading to the total:
  total = total + readings[readIndex];

  // advance to the next position in the array:
  readIndex = readIndex + 1;

  // if we're at the end of the array...
  if (readIndex >= numReadings) {
    // ...wrap around to the beginning:
    readIndex = 0;
  }

  // calculate the average:
  average = total / numReadings;

  delay(1);        // delay in between reads for stability

  // read the current value and one more value right before it
  adcReadPrev = adcReadNow;
  adcReadNow = analogRead(inputPin);

  // call the function to adjust twitch
  bigenough();

  // reset the twitch
  if (twitch > 2)
  {
    twitch = 0;
  }

  /* Uncomment the following if you want to see the actual analog value
    Serial.print("twitch\t");
    Serial.print(twitch);
    Serial.print("\tabs\t");
    Serial.print abs(average - (int)adcReadPrev);
    Serial.print("\t");
    Serial.print(average);
    Serial.print("\t");
    Serial.println(adcReadPrev);
  */

  if (twitch == 0)
  {
    Serial.println("ArduinoSensor\tNORMAL");
  }

  else if (twitch == 1)
  {
    Serial.println("ArduinoSensor\tHAPPY");
  }

  else if (twitch == 2)
  {
    Serial.println("ArduinoSensor\tSAD");
  }

}

// Check if the twitch big enough
void bigenough()
{
  // Check if the changing slope is positive
  if (adcReadNow > adcReadPrev)
  {
    // Calculate the difference to if the pulse is big enough, we can change the sensetivity by changing the number after ">"
    if (abs(average - (int)adcReadPrev) > 100)
    {
      twitch ++;

      // Delay to make it more smooth, this number can be adjust as well
      delay(100);
    }
  }
}


