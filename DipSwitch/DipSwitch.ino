// Arduino pins used for the switches
#define S7 7

// State of each switch (0 or 1)
int s7State;

void setup() {
  // pins for switches are inputs
  pinMode(S7, INPUT);
  // setup serial port
  Serial.begin(9600);
  Serial.println("Serial port open");
}

void loop() {
  s7State = digitalRead(S7);
  Serial.println(s7State);
  //delay(1000);
}
