/*
  AnalogReadSerial
  Reads an analog input on pin 0, prints the result to the serial monitor.
  Graphical representation is available using serial plotter (Tools > Serial Plotter menu)
  Attach the center pin of a potentiometer to pin A0, and the outside pins to +5V and ground.

  This example code is in the public domain.
*/

// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
}

// the loop routine runs over and over again forever:
void loop() {
  // read the input on analog pin 0:
  int sensorValue = analogRead(A0);
  // print out the value you read:
  //Serial.println(sensorValue);

  int sum = 0;
  for(int count = 0; count <= 100; count++)
  {
      sum = sum + sensorValue;
  }

  int avg = sum / 100;

  if(avg >= 0 && avg <= 200)
  {
  Serial.println("HAPPY");
  //Serial.println(avg);
  }
  else if(avg > 201 && avg <= 400)
  {
  Serial.println("MAD");
  //Serial.println(avg);
  }
  else if (avg > 401)
  {
  Serial.println("SAD");
  //Serial.println(avg);
  }
  //else Serial.println(avg);
  
  delay(200);        // delay in between reads for stability
}
