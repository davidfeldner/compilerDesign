type expr =
    | CstI of int
    | Var of string
    | Let of string * expr * expr
    | Let2 of (string * expr) list * expr
    | Prim of string * expr * expr

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Let(x, erhs, ebody) ->
        let xval = eval erhs env
        let env1 = (x, xval) :: env
        eval ebody env1
    | Let2(exps, ebody) ->
        let env1 = List.fold (fun acc (x, ehrs) -> (x, eval ehrs env) :: acc) env exps
        eval ebody env1
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _ -> failwith "unknown primitive"
