(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

(* Association lists map object language variables to their values *)

let env = [ ("a", 3); ("c", 78); ("baf", 666); ("b", 111) ]

let emptyenv = [] (* the empty environment *)

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let cvalue = lookup env "c"


(* Object language expressions with variables *)

type expr =
    | CstI of int
    | Var of string
    | Prim of string * expr * expr
    | If of expr * expr * expr

let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

(* Evaluation within an environment *)

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim(ope, e1, e2) ->
        let i1 = eval e1 env
        let i2 = eval e2 env

        match ope with
        | "+" -> i1 + i2
        | "-" -> i1 - i2
        | "*" -> i1 * i2
        | "max" -> max i1 i2
        | "min" -> min i1 i2
        | "==" ->
            match i1 = i2 with
            | true -> 1
            | false -> 0
        | _ -> failwith "unknown primitive"
    | If(e1, e2, e3) -> if eval e1 env = 1 then eval e2 env else eval e3 env


let e1v = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [ ("a", 314) ]
let e3v = eval e3 env

type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr

//v − (w + z)
let ex1 = Sub(Var "v", Add(Var "w", Var "z"))
// 2 ∗ (v − (w + z))
let ex2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
// x + y + z + v.
let ex3 = Add(Var "x", Add(Var "y", Add(Var "w", Var "z")))

let rec fmt expr : string =
    match expr with
    | CstI i -> string i
    | Var x -> x
    | Add(x, y) -> $"{fmt x}-{fmt y}"
    | Sub(x, y) ->
        match x, y with
        | _, Add _
        | _, Sub _ -> $"{fmt x}-({fmt y})"
        | _ -> $"{fmt x}-{fmt y}"
    | Mul(x, y) ->
        match x, y with
        | Add _, _
        | Sub _, _ -> $"({fmt x})*{fmt y}"
        | _ -> $"{fmt x}*{fmt y}"

let rec simplify expr : aexpr =
    match expr with
    | CstI x -> CstI x
    | Var x -> Var x
    | Add(x, y) ->
        match simplify x, simplify y with
        | CstI 0, z -> z
        | z, CstI 0 -> z
        | CstI a, CstI b -> CstI(a + b)
        | a, b -> Add(a, b)
    | Sub(x, y) ->
        match simplify x, simplify y with
        | z, CstI 0 -> z
        | CstI a, CstI b -> CstI(a - b)
        | a, b -> Sub(a, b)
    | Mul(x, y) ->
        match simplify x, simplify y with
        | CstI 1, x -> x
        | x, CstI 1 -> x
        | CstI 0, _ -> CstI 0
        | _, CstI 0 -> CstI 0
        | a, b -> Mul(a, b)

type dexpr =
    | CstI of int
    | Var of string
    | Let of string * dexpr * dexpr
    | Let2 of (string * dexpr) list * dexpr
    | Prim of string * dexpr * dexpr

let rec deval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Let(x, erhs, ebody) ->
        let xval = deval erhs env
        let env1 = (x, xval) :: env
        deval ebody env1
    | Let2(exps, ebody) ->
        let env1 = List.fold (fun acc (x, ehrs) -> (x, deval ehrs env) :: acc) env exps
        deval ebody env1
    | Prim("+", e1, e2) -> deval e1 env + deval e2 env
    | Prim("*", e1, e2) -> deval e1 env * deval e2 env
    | Prim("-", e1, e2) -> deval e1 env - deval e2 env
    | Prim _ -> failwith "unknown primitive"

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
        let freeInExprs = List.fold (fun acc expr -> union (acc, freevars expr)) [] exprs
        let freeInBody = minus (freevars ebody, vars)
        union (freeInExprs, freeInBody)
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)
