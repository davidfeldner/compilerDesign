open TypedFun

printfn "%A" (types)
let success = typeCheck (ListExpr([CstI 1; CstI 1], TypI))
let fail = typeCheck (ListExpr([CstI 1; CstB false], TypI))

//printfn "%A" (typeCheck success)
//printfn "%A" (typeCheck fail)

