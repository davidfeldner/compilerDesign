open ParseAndRun

let a = fromString "let sum n = if n = 0 then n else (sum (n-1) +n) in sum 1000 end"

let b =
    fromString
        @"
    let pow expo = if expo = 1 then 3 else 3*(pow (expo-1)) in 
        pow 8
    end
    "

let c =
    fromString
        @"
    let pow expo = if expo = 1 then 3 else 3*(pow (expo-1)) in
        let sum n = if n = 0 then 1 else (sum (n-1) + pow n) in 
            sum 11 
        end
    end
    "

//like this hack? xD
let d =
    fromString
        @"
let pow8 b = b*b*b*b*b*b*b*b in 
    let sum n = if n = 0 then 0 else (sum (n-1) + pow8 n) in 
        sum 10
    end
end
"

let e = fromString @"  let x a b = a && b in x true true end"

printfn "%A" (run e)
