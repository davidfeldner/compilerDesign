open ParseAndRunHigher

let res1 = run (fromString "let add x = fun y -> x+y
in add 2 5 end")

let res2 = run (fromString "let add = fun x -> fun y -> x+y
in add 2 5 end")



printfn "%A" res1
printfn "%A" res2
