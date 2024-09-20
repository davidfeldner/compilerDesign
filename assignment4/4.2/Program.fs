open ParseAndRun

let prog =
    fromString "let sum n = if n = 0 then n else (sum (n-1) +n) in sum 1000 end"

printfn "%A" (run prog)
