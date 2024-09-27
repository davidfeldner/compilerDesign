let rec merge (lists: int list * int list): int list =
    match lists with
    | x::xs, y::xy -> if x <= y then x::(merge (xs, y::xy)) else y::(merge (x::xs, xy))
    | x::xs, [] -> x::(merge (xs, []))
    | [], y::ys -> y::(merge ([], ys))
    | [], [] -> []


let l1 = [3;5;12]
let l2 = [2;3;4;7;8;9]

printfn "%A" (merge (l1, l2))