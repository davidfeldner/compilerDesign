type expr =
    | CstI of int
    | Var of string
    | Let of string * expr * expr
    | Let2 of (string * expr) list * expr
    | Prim of string * expr * expr

let rec mem x vs =
    match vs with
    | [] -> false
    | v :: vr -> x = v || mem x vr

let rec union (xs, ys) =
    match xs with
    | [] -> ys
    | x :: xr -> if mem x ys then union (xr, ys) else x :: union (xr, ys)

let rec minus (xs, ys) =
    match xs with
    | [] -> []
    | x :: xr -> if mem x ys then minus (xr, ys) else x :: minus (xr, ys)

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x -> [ x ]
    | Let(x, erhs, ebody) -> union (freevars erhs, minus (freevars ebody, [ x ]))
    | Let2(xs, ebody) ->
        let vars, exprs = List.unzip xs
        let freeInExprs = List.fold (fun acc erhs -> union (acc, freevars erhs)) [] exprs
        let freeInBody = minus (freevars ebody, vars)
        union (freeInExprs, freeInBody)
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)


printfn "%A" (freevars (Let2(([ ("x", CstI 1); ("y", CstI 1) ], Var "u"))))
printfn "%A" (freevars (Let("x", CstI 1, CstI 1)))
