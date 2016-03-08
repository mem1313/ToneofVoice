unsigned int Average = 0;
int ADCreadings[50];

void setup(){
  // put your setup code here, to run once:
  //initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
for(int x=0; x<50; x++){
  ADCreadings[x]=analogRead(A0);
  delay(16);

}
}
int k = 0;
void loop(){
  // put your main code here, to run repeatedly:
//Read the input on analog pin 0:

int sensorValue = analogRead(A0);
//prints out analog values

delay(16);//

ADCreadings[k]=sensorValue;
findaverage();
k++;
if(k==50){
  k=0;
}
Serial.print("Sensor:\t");
Serial.print(sensorValue);
Serial.print("\tAverage:\t");
Serial.println(Average);


}

void findaverage(){
  Average=0;
  for(int x=0; x<50; x++){
  Average+=ADCreadings[x];
  
  }
  Average = (Average/50);
}


