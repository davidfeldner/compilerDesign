open ParseAndRunHigher

let res1 = run (fromString "let add x = let f y = x+y in f end 
    in add 2 5 end")

let res2 = run (fromString "let add x = let f y = x+y in f end
in let addtwo = add 2
in addtwo 5 end
end")

let res3 = run (fromString "let add x = let f y = x+y in f end
in let addtwo = add 2
in let x = 77 in addtwo 5 end
end
end")

let res4 = run (fromString "let add x = let f y = x+y in f end
in add 2 end")




printfn "%A" res1
printfn "%A" res2
printfn "%A" res3
//Is the result of the third one as expected?
// Yes this is expected because, when creating addTwo we define a new function with a closure where x has been defined as 2
printfn "%A" res4
//Explain the result of the last one
// This returns a function which adds two to whatever parameter is given. The function is saved as a closure which has the environment of x=2.


