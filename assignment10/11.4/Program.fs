let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x * prod xr

let rec prodc xs cont =
    match xs with
    | [] -> cont 1
    | x::xr -> prodc xr (fun v -> cont (x * v))

let rec prodcOpt xs cont =
    match xs with
    | [] -> cont 1
    | 0::xr -> 0  // new
    | x::xr -> prodcOpt xr (fun v -> cont (x * v))

let id = fun v -> v

printfn "prodc [2; 0; 3; 4] id = %d" (prodc [2; 0; 3; 4] id)
printfn "prodcOpt [2; 0; 3; 4] id = %d" (prodcOpt [2; 0; 3; 4] id)
prodcOpt [2; 5; 7] (fun v -> printfn "Result is %d\n" v; v) |> ignore
printfn "prodcOpt [2; 5; 7] (fun v -> 2*v) = %d" (prodcOpt [2; 5; 7] (fun v -> 2*v))

let rec prodiOpt xs acc =
    match xs with
    | [] -> acc
    | 0::xr -> 0  // Early termination
    | x::xr -> prodiOpt xr (acc * x)

printfn "prodiOpt [2; 3; 4] 1 = %d" (prodiOpt [2; 3; 4] 1)


