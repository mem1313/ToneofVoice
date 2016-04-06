
unsigned int Average = 0;
unsigned int first = 0;
unsigned int last = 0;
int ADCreadings[50];
int timer
void setup(){

  Serial.begin(9600);
  //Serial.println("ArduinoSensor");
  //for(int x=0; x<50; x++)
  //{
    //if(x = 0)
    //{
     // first = analogRead(A0);
    //}
    //else if(x = 50)
    //{
     // last = analogRead(A0);  
    //}
    
    //ADCreadings[x]=analogRead(A0);
    //delay(16);
  //}
}
int k = 0;
void loop(){
  
  int sensorValue = analogRead(A0);
  
  delay(16);
  
  ADCreadings[k]=sensorValue;
  
  if(k == 0)
    {
      first = analogRead(A0);
    }
    else if(k == 50)
    {
      last = analogRead(A0);  
    }
  k++;
  
  if(k==50)
  {
    k=0;
    findaverage();
    //Serial.print("Sensor:\t");
  // Serial.print(sensorValue);
    //Serial.print("\tAverage:\t");
    //Serial.print(Average:\t);

    //int differance = last - first;
    //if(differance > 0)
    //{
    //  Serial.println("Swipe big");
    //}
    //else if(differance < 0)
    //{
    //  Serial.println("Swipe small");
    //}
    //else 
    if(Average >=0 && Average<190)
    {
      Serial.println("ArduinoSensor\tNORMAL");  
    }
    else if (Average >= 200 && Average < 450)
    {
      Serial.println("ArduinoSensor\tHAPPY");
    }
    else if (Average >= 450 && Average < 600)
    {
      Serial.println("ArduinoSensor\tSAD");//test for time (when last was it pressed)
    }
    else 
    {
      Serial.println("ArduinoSensor\tMAD");
    }
  }

}

void findaverage(){
  Average=0;
  for(int x=0; x<50; x++)
  {
    Average += ADCreadings[x];
  }
  Average = (Average/50);
}


