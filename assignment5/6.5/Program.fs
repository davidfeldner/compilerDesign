open ParseAndType
// int
let res1 = inferType(fromString "let f x = 1
in f f end");;

// "f g = g g" Here g takes itself as a parameter in the function declaration which makes it impossible to determine its type
(* let res2 =
    inferType(fromString "let f g = g g
in f end");; *)

// bool
let res3 =
    inferType(fromString "let f x =
let g y = y
in g false end
in f 42 end");;

// The if statment returns 2 different types, y is an int, since f is called with 42, and x is a boolean, since g is called with false.
(* let res4 =
    inferType(fromString "let f x =
    let g y = if true then y else x
    in g false end
in f 42 end");; *)

// bool
let res5 =
    inferType(fromString "let f x =
    let g y = if true then y else x
    in g false end
in f true end");;


printfn "%A" res1
//printfn "%A" res2
printfn "%A" res3
//printfn "%A" res4
printfn "%A" res5


//(bool -> bool)
printfn "%A" (inferType(fromString "let f x = if x then true else x in f end"))
//(int -> int)
printfn "%A" (inferType(fromString "let f x = x + 1 in f end"))
//(int -> (int -> int))
printfn "%A" (inferType(fromString "let f x =
        let g y = if true then y + 1 else x + 1
        in g end
    in f end"))
//"('h -> ('g -> 'h))"
printfn "%A" (inferType(fromString "let f x =
    let g y = x
    in g end
in f end"))
//"('g -> ('h -> 'h))"
printfn "%A" (inferType(fromString "let f x =
    let g y = y
    in g end
in f end"))

//(’a -> ’b) -> (’b -> ’c) -> (’a -> ’c)
printfn "%A" (inferType(fromString "
let f a = a
in let g b = b
        let h c = c
        in h end
    in g end 
end
"))

