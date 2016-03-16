// Setting the counter to 0
int counter = 0;
// Setting the user emotion to 'NORMAL 1' based on emotions in the printEmotion_Sensor() method
int currentValue = 500;
// This is the size of the loop and the arrays used to calculate the average
const int loopSize = 50;
// This is where the average value is going to be stored
unsigned int Average = 0;
// This is where the readings from the sensor are stored so that we can get the average later
int ADCreadings[loopSize];
// This is the pin that will be used as the input
const int softPotPin = A0;
/* 
 *  This will be the led pin that will be used to show status of the Arduino
 *  It will flicker or stay on (flicker = attempting communication. stay on = succesfful communication)
 *  Maybe we can look at an RGB led that will show the current emotion 
      - with colour after sucessfull communication 
    */
const int ledPin = 3;

void setup()
{
  // This makes the default base line value LOW (0)... Anything higher than 0 is consider a press or swipe
  digitalWrite(softPotPin, LOW); //This will make the base value 0
 
  Serial.begin(9600);
  
  for(int x=0; x<50; x++)
  {
    ADCreadings[x]=analogRead(softPotPin);
    delay(16);
  }
}

 
void loop()
{  
  //Serial.print (Serial.readString());
  //if(areWeConnected())
  //{
    int sensorValue = analogRead(softPotPin);
    ADCreadings[counter]=sensorValue;
    findaverage();
    
    counter++;
    
    if(counter == loopSize)
      counter=0;
  
    // Going to determine if the sensor is being touched
    // That value will be used as the current value = current emotions
    if(isSoftPotBeingTouched(sensorValue))
    {
      currentValue = sensorValue;
    }
  
    // This prints information. Sensor value and the average
    // printSensorInfo(sensorValue);  
    // This prints the emotion based on the average value
    // printEmotion_Average();
  
    // Emotion will be chosen based on the current value
    printEmotion_Sensor(currentValue); 
  
    // Just delaying the program so that the values are more readable 
    delay(400);
  //}
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

void findaverage()
{
  Average=0;
  
  for(int x=0; x < loopSize; x++)
  {
    Average += ADCreadings[x];
  }
  Average = (Average / loopSize);
}

// This will just print the sensor value and the average 
void printSensorInfo(int sensorValue)
{
  Serial.print("Sensor:\t");
  Serial.print(sensorValue);
  Serial.print("\tAverage:\t");
  Serial.print(Average);
}

// This will print the emotion based on the average (Think this needs to change)
void printEmotion_Average()
{
  if (Average >= 0 && Average < 300)
    Serial.println("\tHAPPY\t");
  else if (Average >= 300 && Average < 600)
    Serial.println("\tSAD\t");
  else 
    Serial.println("\tMAD\t");
}

// This will print the emption based on the senor value
void printEmotion_Sensor(int sensorValue)
{
 //  Serial.println("---------- EMOTION WITH SENSOR VALUE ----------");
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
    //Serial.println("(NO EMOTION)"); 
    Serial.println("NORMAL1"); // Made 'NORMAL 1' the fall back emotion 

   // Serial.println("-----------------------------------------------");
}

// Going to try to select and emotion based on a swipe action [left or right]
// I will use the value that comes from the sensor
// I will also print the emotion based on the senor value
void swipe(int sensorValue)
{
  
}

// This will return a bool value based on whether the value is more then the resting 
// value... With digitalWirte it's 1011 
bool isSoftPotBeingTouched(int sensorValue)
{
  if(sensorValue > 0)
    return true;
  else
    return false;
}

// This will be used when the arduino is waiting for a connection from the applications
bool didReceiveConnectionFromApplication()
{
   
  
  return false;
}

// This will make an LED blink while we waiting for confirmation that the 
// Arduino has made successfull communication
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

