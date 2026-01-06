Program with types:
val p = (1:int, 43:int):(int * int)

fun f p = 
   if (fst(p:(int * int)):int < 0:int):bool 
      then g:((int * int) -> (int * int))_tail p:(int * int):(int * int) 
      else 
         f:((int * int) -> (int * int))_tail 
            ((fst(p:(int * int)):int - 1:int):int, 
              snd(p:(int * int)):int):(int * int):(int * int)
and g p = (fst(p:(int * int)):int, (
           snd(p:(int * int)):int - 1:int):int):(int * int)


begin
  print(f:((int * int) -> (int * int)) p:(int * int):(int * int)):(int * int)
end
Result type: (int * int)

Evaluating Program
(-1, 42) 