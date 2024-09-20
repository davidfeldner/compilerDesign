open Parse

let e1 = fromString "5+7"
let e2 = fromString "let y = 7 in y + 2 end"
let e3 = fromString "let f x = x + 7 in f 2 end"

printfn "%A" (e1, e2, e3)
