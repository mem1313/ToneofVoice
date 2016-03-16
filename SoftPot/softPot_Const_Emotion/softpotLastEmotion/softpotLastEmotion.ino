// Setting the user emotion to 'NORMAL 1' based on emotions in the printEmotion_Sensor() method
int currentValue = 500;
// This is the pin that will be used as the input
const int softPotPin = A0;
// This is the led pin that I will use when the user is still waiting for communcation 
// from the applicaitons (optikey in this scenario)
const int ledPin = 3;

void setup()
{
  digitalWrite(softPotPin, LOW); 
 
  Serial.begin(9600);
}
 
void loop()
{  
    int sensorValue = analogRead(softPotPin);

    // Going to determine if the sensor is being touched
    // That value will be used as the current value = current emotions
    if(isSoftPotBeingTouched(sensorValue))
    {
      currentValue = sensorValue;
    }

    // Printing the current emotion
    printEmotion_Sensor(currentValue);
    //Serial.print(sensorValue); 
  
    // Just delaying the program so that the values are more readable 
    delay(400);
  
}

bool areWeConnected()
{
  if(Serial.readString() == "connected")
    return true;
  else
  {
    Serial.print("ping\n");
    return false;
  }
}

// This will print the emption based on the senor value
void printEmotion_Sensor(int sensorValue)
{
  if (sensorValue >= 100 && sensorValue < 300)
    Serial.println("HAPPY");
  else if (sensorValue >= 300 && sensorValue < 400)
    Serial.println("SAD");
  else if (sensorValue >= 400 && sensorValue < 500)
    Serial.println("ANGRY");
  else if (sensorValue >= 500 && sensorValue < 600)
    Serial.println("NORMAL1");
  else if (sensorValue >= 600 && sensorValue < 700)
    Serial.println("NORMAL2");
  else if (sensorValue >= 700 && sensorValue < 800)
    Serial.println("NORMAL3");
  else if (sensorValue >= 800 && sensorValue < 900)
    Serial.println("NORMAL4");
  else if (sensorValue >= 900 && sensorValue < 1000)
    Serial.println("NORMAL5");
  else
    Serial.println("NORMAL1"); // Made 'NORMAL 1' the fall back emotion 
}

// This will return a bool value based on whether the value is more then the resting 
// value... With digitalWirte it's +-1011 
bool isSoftPotBeingTouched(int sensorValue)
{
  if(sensorValue > 0)
    return true;
  else
    return false;
}

// This will make an LED blink while we waiting for confirmation that the 
// Arduino has made successfull communication
// Will implement this after I get the COM port detection working
bool waitingForConnectionLED(bool weConnected, int LEDpin, int delayInterval)
{
  if(!weConnected)
  {
    digitalWrite(LEDpin, HIGH);
    delay(delayInterval);
    digitalWrite(LEDpin, LOW);
    delay(delayInterval);
    digitalWrite(LEDpin, HIGH);
    delay(delayInterval);
    return false;
  }
  else
  {
    digitalWrite(LEDpin, HIGH);
    return true;
  }
}

