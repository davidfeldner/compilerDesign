open TypedFun

printfn "%A" (types)
let success = Let("b", ListExpr([CstI 1; CstI 1], TypI), Var "b");;
let fail = Let("b", ListExpr([CstI 1; CstB false], TypI), Var "b");;

printfn "%A" (typeCheck success)
printfn "%A" (typeCheck fail)

