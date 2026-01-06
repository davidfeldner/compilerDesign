open ParseAndRun
open Absyn
open Fun

let a = fromString "let sum n = if n = 0 then n else (sum (n-1) +n) in sum 1000 end"

let b =
    fromString
        @"
    let pow expo = if expo = 1 then 3 else 3*(pow (expo-1)) in 
        pow 8
    end
    "

let c =
    fromString
        @"
    let pow expo = if expo = 1 then 3 else 3*(pow (expo-1)) in
        let sum n = if n = 0 then 1 else (sum (n-1) + pow n) in 
            sum 11 
        end
    end
    "

let d =
    fromString
        @"
let pow8 b = b*b*b*b*b*b*b*b in 
    let sum n = if n = 0 then 0 else (sum (n-1) + pow8 n) in 
        sum 10
    end
end
"

let b1 =
    fromString
        @"
let pow x n = if n=0 then 1 else x * pow x (n-1) in pow 3 8 end
"

let b2 =
    fromString
        @"
let max2 a b = if a<b then b else a
    in let max3 a b c = max2 a (max2 b c)
    in max3 25 6 62 end
end
"

let e = fromString @"  let x a b c = a+b+c in x 1 2 (x 1 2 3) end"
let t = fromString @"0 || 1 && 1"

printfn "6561: %A" (run b1)
printfn "62: %A" (run b2)
printfn "167731333: %A" (run d)
printfn "9: %A" (run e)
printfn "1: %A" (run t)

let q = Letfun("p8", ["n"],
                          Letfun("aux", ["k"],
                          If(Prim("=", Var "k", CstI 0),
                            CstI 1,
                            Prim("*", Var "n", Call(Var "aux", [Prim("-", Var "k", CstI 1)]))),
                          Call(Var "aux", [CstI 8])),
                          Call(Var "p8", [Var "n"]))

printfn "1: %A" (eval q [("n", (Int) 2)] )
