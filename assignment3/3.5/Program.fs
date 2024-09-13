open Parse;;

printfn "%A" (fromString "1 + 2 * 3")
printfn "%A" (fromString "1 - 2 - 3")
printfn "%A" (fromString "1 + -2")
//printfn "%A" (fromString "x++")
//printfn "%A" (fromString "1 + 1.2")
//printfn "%A" (fromString "1 + ")
printfn "%A" (fromString "let z = (17) in z + 2 * 3 end")
//printfn "%A" (fromString "let z = 17) in z + 2 * 3 end")
//printfn "%A" (fromString "let in = (17) in z + 2 * 3 end")
printfn "%A" (fromString "1 + let x=5 in let y=7+x in y+y end + x end")




printfn "%A" (fromString "let a=20 in let b=10 in a+b end end")
printfn "%A" (fromString "let a=20 in let b=10 in (a+b)*a+b*(a*b) end end")
printfn "%A" (fromString "let a=1 in let b=2 in let c=3 in a+b+c end end end")