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


let rec diff a s =
    match a with
    | CstI _ -> CstI 0
    | Var x when x = s -> CstI 1
    | Var _ -> CstI 0
    | Add(x, y) -> Add(diff x s, diff y s)
    | Sub(x, y) -> Sub(diff x s, diff y s)
    | Mul(x, y) -> Add(Mul(y, diff x s), Mul(x, diff y s))

//printf "%A\n" (simplify ((diff (Mul(Var "x", Mul(CstI 2, Var "a"))) "x")))
