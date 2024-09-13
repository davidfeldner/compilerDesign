open Parse
open Expr



let compString (inp: string) : sinstr list = 
    scomp (fromString inp) [] 

printfn "%A" (compString "1 + 2 * 3")
printfn "%A" (compString "let z = (17) in z + 2 * 3 end")
