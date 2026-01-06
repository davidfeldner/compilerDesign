let rec rev xs =
    match xs with
    | [] -> []
    | x::xr -> rev xr @ [x]

let rec revc xs cont =
    match xs with
    | [] -> cont []
    | x::xr -> revc xr (fun v -> cont (v @ [x]))

let id = fun v -> v

printfn "revc [2; 5; 7] id = %A" (revc [2; 5; 7] id)

printfn "revc [2; 5; 7] (fun v -> v @ v) = %A" (revc [2; 5; 7] (fun v -> v @ v))

let rec revi xs acc =
    match xs with
    | [] -> acc
    | x::xr -> revi xr (x::acc)

printfn "revi [2; 5; 7] [] = %A" (revi [2; 5; 7] [])
