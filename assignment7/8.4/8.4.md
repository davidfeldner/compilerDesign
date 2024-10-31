# Exercise 8.4

## Why is the handwritten prog1 faster than the compiled ex8

Firstly there is no main function in the handwritten, so we avoid all the loading of args, and returning.
We can also avoid fx adding 0 to the base pointer, and loading a value which can just be duplicated.
Sometimes the compiled version also subtracts, then adds to the stack pointer which does nothing.

# Compile ex13.c and study the symbolic bytecode to see how loops and conditionals interact; describe what you see.

There are a lot of jumps and consts added just for the conditionals in the if statment.

PC - 00:  LDARGS
PC - 01:  CALL 1 5      // Call main
PC - 04:  STOP
PC - 05:  INCSP 1       // Main
PC - 07:  GETBP
PC - 08:  CSTI 1        // int i at BP + 1
PC - 10:  ADD
PC - 11:  CSTI 1889     
PC - 13:  STI           // Set y = 1889;
PC - 14:  INCSP -1

PC - 16:  GOTO 95       // Goto check if while is true
PC - 18:  GETBP
PC - 19:  CSTI 1
PC - 21:  ADD
PC - 22:  GETBP
PC - 23:  CSTI 1
PC - 25:  ADD
PC - 26:  LDI
PC - 27:  CSTI 1
PC - 29:  ADD
PC - 30:  STI           //  y = y + 1;
PC - 31:  INCSP -1

PC - 33:  GETBP
PC - 34:  CSTI 1
PC - 36:  ADD
PC - 37:  LDI
PC - 38:  CSTI 4
PC - 40:  MOD
PC - 41:  CSTI 0
PC - 43:  EQ
PC - 44:  IFZERO 77     // y % 4 == 0

PC - 46:  GETBP
PC - 47:  CSTI 1
PC - 49:  ADD
PC - 50:  LDI
PC - 51:  CSTI 100
PC - 53:  MOD
PC - 54:  CSTI 0
PC - 56:  EQ
PC - 57:  NOT
PC - 58:  IFNZRO 73     //y % 100 != 0

PC - 60:  GETBP
PC - 61:  CSTI 1
PC - 63:  ADD
PC - 64:  LDI
PC - 65:  CSTI 400
PC - 67:  MOD
PC - 68:  CSTI 0
PC - 70:  EQ            // y % 400 == 0
PC - 71:  GOTO 75
PC - 73:  CSTI 1
PC - 75:  GOTO 79
PC - 77:  CSTI 0
PC - 79:  IFZERO 91

PC - 81:  GETBP
PC - 82:  CSTI 1
PC - 84:  ADD
PC - 85:  LDI
PC - 86:  PRINTI        // print y;
PC - 87:  INCSP -1
PC - 89:  GOTO 93
PC - 91:  INCSP 0
PC - 93:  INCSP 0

PC - 95:  GETBP
PC - 96:  CSTI 1
PC - 98:  ADD
PC - 99:  LDI
PC - 100: GETBP
PC - 101: CSTI 0
PC - 103: ADD
PC - 104: LDI
PC - 105: LT
PC - 106: IFNZRO 18     // while (y < n)  jump back to start if true

PC - 108: INCSP -1
PC - 110: RET 0