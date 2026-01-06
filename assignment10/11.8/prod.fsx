let rec prod xs = 
    match xs with 
    | []    -> 1
    | x::xr -> x * prod xr

let rec proda xs a =
    match xs with
    | []    -> a
    | x::xr -> proda xr (x*a)

let rec prodc xs k =
  match xs with
    [] -> k 1
  | x::xr -> prodc xr (fun v -> k(v*x))

let xs = [3;4;5;23;3;453;4]
let x = prod xs = prodc xs id
let y = prod xs = proda xs 1


