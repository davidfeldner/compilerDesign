open ParseAndType

let res1 = inferType(fromString "let f x = 1
in f f end");;

// "f g = g g" Here g takes itself as a parameter in the function declaration which makes it impossible to determine its type
(* let res2 =
    inferType(fromString "let f g = g g
in f end");; *)

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
