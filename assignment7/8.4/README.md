Why is the handwritten prog1 faster than the compiled ex8

Firstly there is no main function in the handwritten, so we avoid all the loading of args, and returning.
We can also avoid fx adding 0 to the base pointer, and loading a value which can just be duplicated.
Sometimes the compiled version also subtracts, then adds to the stack pointer which does nothing.