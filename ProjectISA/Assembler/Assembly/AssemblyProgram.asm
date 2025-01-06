; count to five:
SET R0 0
SET R1 1
SET r2 5
loop:
  ADD R0 R0 R1
  EQ r3 R0 R2
  JMPT r3 #end
  JMP #loop
end:
NOP