type expr = 
  | CstI of int
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr;;

type sinstr =
| SCstI of int                        (* push integer           *)
| SVar of int                         (* push variable from env *)
| SAdd                                (* pop args, push sum     *)
| SSub                                (* pop args, push diff.   *)
| SMul                                (* pop args, push product *)
| SPop                                (* pop value/unbind var   *)
| SSwap;;                             (* exchange top and next  *)

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;


type stackvalue =
  | Value                               (* A computed value *)
  | Bound of string;;                   (* A bound variable *)
let rec scomp (e : expr) (cenv : stackvalue list) : sinstr list =
    match e with
    | CstI i -> [SCstI i]
    | Var x  -> [SVar (getindex cenv (Bound x))]
    | Let(x, erhs, ebody) -> 
          scomp erhs cenv @ scomp ebody (Bound x :: cenv) @ [SSwap; SPop]
    | Prim("+", e1, e2) -> 
          scomp e1 cenv @ scomp e2 (Value :: cenv) @ [SAdd] 
    | Prim("-", e1, e2) -> 
          scomp e1 cenv @ scomp e2 (Value :: cenv) @ [SSub] 
    | Prim("*", e1, e2) -> 
          scomp e1 cenv @ scomp e2 (Value :: cenv) @ [SMul] 
    | Prim _ -> failwith "scomp: unknown operator";;


(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)
let sinstrToInt = function
  | SCstI i -> [0;i]
  | SVar i  -> [1;i]
  | SAdd    -> [2]
  | SSub    -> [3]
  | SMul    -> [4]
  | SPop    -> [5]
  | SSwap   -> [6]

let assemble instrs =  List.foldBack (fun x acc-> sinstrToInt x@acc) instrs []

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;

(scomp (Let("x", CstI 4, Prim("+", CstI 1, Var "x"))) [] |> assemble |> intsToFile) "filename2.S"

intsToFile (assemble [SCstI 1; SCstI 1; SAdd]) "filename.S"

