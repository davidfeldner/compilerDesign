open TypedFun

printfn "%A" (types)
let ex3 = Let("b", ListExpr([CstI 1; CstI 1], TypI), Var "b");;

printfn "%A" (typeCheck ex3)