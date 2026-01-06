let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x * prod xr

let rec prodc xs cont =
    match xs with
    | [] -> cont 1
    | x::xr -> prodc xr (fun v -> cont (x * v))

let id = fun v -> v

printfn "prodc [2; 3; 4] id = %d" (prodc [2; 3; 4] id)

printfn "prodc [2; 3; 4] (fun v -> v + 10) = %d" (prodc [2; 3; 4] (fun v -> v + 10))

printfn "\nprodc [2; 3; 4] (fun v -> v * 2) = %d" (prodc [2; 3; 4] (fun v -> v * 2))

prodc [2; 3; 4] (printf "The product is %d\n")

