// Global variables declarations:
#define S7 7                    // Arduino pins used for the switches
int s7State;                    // State of each switch (0 or 1)
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

// Variables for the softpot
unsigned int Average = 0;
unsigned int first = 0;
unsigned int last = 0;
int ADCreadings[50];
int k = 0;

// Function prototypes declarations:
void findaverage();
void bigenough();

// Program starts:
void setup()
{
  // pins for switches are inputs
  pinMode(S7, INPUT);
  // setup serial port
  Serial.begin(9600);

  // initialize all the readings to 0:
  for (int thisReading = 0; thisReading < numReadings; thisReading++)
  {
    readings[thisReading] = 0;
  }
}

// Main loop starts:
void loop()
{
  // Reading the output from dip switch
  s7State = digitalRead(S7);

  // If the output is 1, EMG sensor is on
  if (s7State == 1)
  {
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

    /*   Uncomment the following if you want to see the actual analog value
        Serial.print("twitch\t");
        Serial.print(twitch);
        Serial.print("\tabs\t");
        Serial.print abs(average - (int)adcReadPrev);
        //Serial.print("\t");
        //Serial.print(average);
        //Serial.print("\t");
        //Serial.println(adcReadPrev);
    */

    if (twitch == 0)
    {
      Serial.println("ArduinoSensor\tNORMAL");
      delay(250);
    }

    else if (twitch == 1)
    {
      Serial.println("ArduinoSensor\tHAPPY");
      delay(250);
    }

    else if (twitch == 2)
    {
      Serial.println("ArduinoSensor\tSAD");
      delay(250);
    }

  }

  // If the output is 0, Softpot sensor is on
  else
  {
    int sensorValue = analogRead(A0);

    delay(16);

    ADCreadings[k] = sensorValue;

    if (k == 0)
    {
      first = analogRead(A0);
    }
    else if (k == 50)
    {
      last = analogRead(A0);
    }
    k++;

    if (k == 50)
    {
      k = 0;
      findaverage();
      if (Average == 0)
      {
        Serial.println("ArduinoSensor\tNORMAL");
      }
      else if (Average >= 1 && Average < 190)
      {
        Serial.println("ArduinoSensor\tHAPPY");
      }
      else if (Average >= 200 && Average < 450)
      {
        Serial.println("ArduinoSensor\tSAD");//test for time (when last was it pressed)
      }
      else if (Average >= 450 && Average < 600)
      {
        Serial.println("ArduinoSensor\tIRRETATED");//test for time (when last was it pressed)
      }
      else
      {
        Serial.println("ArduinoSensor\tMAD");
      }
    }
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
      // Delay to make it more smooth, this number can be adjust as well
      delay(2000);

      // Increase the number of twitch
      twitch ++;

    }
  }
}

void findaverage()
{
  Average = 0;
  for (int x = 0; x < 50; x++)
  {
    Average += ADCreadings[x];
  }
  Average = (Average / 50);
}

