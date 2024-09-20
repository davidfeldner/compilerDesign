open Parse
open ParseAndRun

let e1 = fromString "5+7"
let e2 = fromString "let y = 7 in y + 2 end"
let e3 = fromString "let f x = x + 7 in f 2 end"

let prog =
    fromString "let sum n = if n > 0 then (sum (n-1) +n) else n in sum 1000 end"

printfn "%A" (run prog)
