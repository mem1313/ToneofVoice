
#include "SimpleTimer.h"
int sensorValue =0;
int Average = 0;
unsigned int first = 0;
unsigned int last = 0;
unsigned int twitch = 0;
int ADCreadings[30];
unsigned long time = 0;
SimpleTimer timer;
void findaverage();
void bigenough();
unsigned int adcReadPrev =0;

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
    //{v
     // last = analogRead(A0);  
    //}
    
    //ADCreadings[x]=analogRead(A0);
    //delay(16);
  //}
}
int k = 0;
int j = 10;

void loop(){
   // Serial.println("analogRead:");
    //Serial.println(analogRead(A0));
    // Serial.print("Time: ");
    //timer.run();
    time = millis()/1000;
    //Serial.println(millis() / 1000);

  while((time / j) < 1)
    {
//      Serial.print("analogRead:\t");
//      Serial.print(analogRead(A0));
//      Serial.print("\tAverage:\t");
//    Serial.println(Average);
   // Serial.println("time");
   // Serial.println(time ); 
   // Serial.println("j");
  //  Serial.println(j);
    //Serial.println(time);
    time = millis()/1000;
  

  
 // delay(16); Do I need this??
  sensorValue = analogRead(A0);
  ADCreadings[k]=sensorValue;
   for(int x=0; x<30; x++)
  {
      Average += ADCreadings[x];

  }
      Average = (Average/30);
    

    bigenough();

  

   Serial.print("twitch\t"); 
 Serial.print(twitch);
  Serial.print("\tabs\t");
  adcReadPrev = analogRead(A0); 
  Serial.print(abs(Average - (int)adcReadPrev));
  Serial.print("\t");
  Serial.print(Average);
  Serial.print("\t");
  Serial.println(adcReadPrev);
//    Serial.println(analogRead(A0)); 
//    if(Average >=0 && Average<190)
//    {
//      Serial.println("ArduinoSensor\tNORMAL");  
//    }
//    else if (Average >= 200 && Average < 450)
//    {
//      Serial.println("ArduinoSensor\tHAPPY");
//    }
//    else if (Average >= 450 && Average < 600)
//    {
//      Serial.println("ArduinoSensor\tSAD");//test for time (when last was it pressed)
//    }
//    else 
//    {
//      Serial.println("ArduinoSensor\tMAD");
//    }
  }
    
  j=j+10;
  k=k+1;
}




void findaverage(){
  Average=0;
  for(int x=0; x<30; x++)
  {
      Average += ADCreadings[x];
  }
      Average = (Average/30);
  }

   //Is the twitch big enough??

void bigenough(){            
  if((abs(Average - (int)adcReadPrev)) >35){
  
    twitch=1;
  }
  else{
    twitch=0;
      }
}
  

