open ParseAndRunHigher
open Absyn
//let res1 = run (fromString "fun x -> 2*x")

//let res2 = run (fromString "let y = 22 in fun z -> z+y end")



let a = Fun("x", Prim("*", CstI 2, Var "x"))
let b = Let("y", CstI 22, Fun("z", Prim("+", Var "z", Var "y")))


printfn "%A" (run a)
printfn "%A" (run b)
//printfn "%A" res1
//printfn "%A" res2

