type expr =
    | CstI of int
    | Var of string
    | Let of string * expr * expr
    | Let2 of (string * expr) list * expr
    | Prim of string * expr * expr

type texpr = (* target expressions *)
    | TCstI of int
    | TVar of int (* index into runtime environment *)
    | TLet of texpr * texpr (* erhs and ebody                 *)
    | TPrim of string * texpr * texpr


(* Map variable name to variable index at compile-time *)

let rec getindex vs x =
    match vs with
    | [] -> failwith "Variable not found"
    | y :: yr -> if x = y then 0 else 1 + getindex yr x

(* Compiling from expr to texpr *)

let rec tcomp (e: expr) (cenv: string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x -> TVar(getindex cenv x)
    | Let(x, erhs, ebody) ->
        let cenv1 = x :: cenv
        TLet(tcomp erhs cenv, tcomp ebody cenv1)
    | Let2(xs, ebody) ->
        match xs with
        | (x, erhs) :: xs ->
            let cenv1 = x :: cenv
            TLet(tcomp erhs cenv, tcomp (Let2(xs, ebody)) cenv1)
        | [] -> tcomp ebody cenv
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)

//printfn "%A" (tcomp (Let2(([ ("x", CstI 1); ("y", CstI 1) ], Var "y"))) [])
//printfn "%A" (tcomp (Let("x", CstI 1, CstI 1)) [])
