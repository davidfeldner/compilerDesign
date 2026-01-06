let rec len xs =
    match xs with
    | [] -> 0
    | x::xr -> 1 + len xr

let rec lenc xs cont =
    match xs with
    | [] -> cont 0
    | x::xr -> lenc xr (fun v -> cont (1 + v))

let id = fun v -> v

lenc [2; 5; 7] (printf "The answer is '%d'\n")

printfn "lenc [2; 5; 7] (fun v -> 2*v) = %d" (lenc [2; 5; 7] (fun v -> 2*v))

let rec leni xs acc =
    match xs with
    | [] -> acc
    | x::xr -> leni xr (acc + 1)

printfn "leni [2; 5; 7] 0 = %d" (leni [2; 5; 7] 0)

