; count to infinity:
JMP #start

NOP
NOP
NOP

start:
  SET R0 0
  SET R1 1
  loop:
    ADD R0 R0 R1
    JMP #loop