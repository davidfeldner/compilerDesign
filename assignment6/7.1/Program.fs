open ParseAndRun;;
   printf "%A\n" (fromFile "ex1.c");;
   run (fromFile "ex1.c") [17];;
   printf "%A\n" (fromFile "ex3.c");;
   run (fromFile "ex3.c") [17];;