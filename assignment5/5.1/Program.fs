let rec merge (lists: int list * int list): int list =
    match lists with
    | x::xs, y::xy -> if x <= y then x::y::(merge ) else y::x::acc
    | x::xs, [] -> x::acc
    | [], y::ys -> y::acc
    | [], [] -> acc


let l1 = [3;5;12]
let l2 = [2;3;4;7]

printfn "%A" (merge (l1, l2))