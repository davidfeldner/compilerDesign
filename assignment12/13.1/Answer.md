running `dotnet run -- -opt -verbose -eval ex09.sml `

1. result is 4
2. Result type: int
3. Program with tailcalls:
        fun f x = if (x < 0) then g_tail 4 else f_tail (x - 1)
        and g x = x
        begin
            print(f 2)
        end

4.
Program with types:
fun f x = if (x:int < 0:int):bool then g:(int -> int)_tail 4:int:int else f:(int -> int)_tail (x:int - 1:int):int :int
and g x = x:int
begin
  print(f:(int -> int) 2:int:int):int
end
Result type: int

5. interp Used: Elapsed 14ms, CPU 10ms
   ./msmlmachine ../../ex09.out Used 0 cpu milli-seconds

6. spaces with ops 83 (84 instructions)
   spaces with ops 90 (91 instructions)
   Saved 7 instructions