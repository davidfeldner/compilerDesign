module Icon

(* Micro-Icon abstract syntax *)
type expr = 
  | CstI of int
  | CstS of string
  | FromTo of int * int
  | Write of expr
  | If of expr * expr * expr
  | Prim of string * expr * expr 
  | Prim1 of string * expr  // Exercise 11.8 (iii) - Unary primitives
  | And of expr * expr
  | Or  of expr * expr
  | Seq of expr * expr
  | Every of expr 
  | Fail

(* Runtime values and runtime continuations *)
type value = 
  | Int of int
  | Str of string

type econt = unit -> value
type cont = value -> econt -> value

(* Print to console *)
let write v =
    match v with 
    | Int i -> printf "%d " i
    | Str s -> printf "%s " s

(* Expression evaluation with backtracking *)
let rec eval (e : expr) (cont : cont) (econt : econt) = 
    match e with
    | CstI i -> cont (Int i) econt
    | CstS s  -> cont (Str s) econt
    | FromTo(i1, i2) -> 
      let rec loop i = 
          if i <= i2 then 
              cont (Int i) (fun () -> loop (i+1))
          else 
              econt ()
      loop i1
    | Write e -> 
      eval e (fun v -> fun econt1 -> (write v; cont v econt1)) econt
    | If(e1, e2, e3) -> 
      eval e1 (fun _ -> fun _ -> eval e2 cont econt)
              (fun () -> eval e3 cont econt)
    | Prim(ope, e1, e2) -> 
      eval e1 (fun v1 -> fun econt1 ->
          eval e2 (fun v2 -> fun econt2 -> 
              match (ope, v1, v2) with
              | ("+", Int i1, Int i2) -> 
                  cont (Int(i1+i2)) econt2 
              | ("*", Int i1, Int i2) -> 
                  cont (Int(i1*i2)) econt2
              | ("<", Int i1, Int i2) -> 
                  if i1<i2 then 
                      cont (Int i2) econt1
                  else
                      econt2 ()
              | _ -> Str "unknown prim2")
              econt1)
          econt
    // Exercise 11.8 (iii)
    | Prim1(ope, e1) ->
      eval e1 (fun v1 -> fun econt1 ->
          match (ope, v1) with
          | ("sqr", Int i) -> 
              cont (Int(i * i)) econt1
          | ("even", Int i) ->
              if i % 2 = 0 then
                  cont (Int i) econt1
              else
                  econt1 ()
          | ("multiples", Int i) ->
              // Exercise 11.8 (iv) - Infinite multiples
              let rec loop n =
                  cont (Int(i * n)) (fun () -> loop (n + 1))
              loop 1
          | _ -> Str "unknown prim1")
          econt
    | And(e1, e2) -> 
      eval e1 (fun _ -> fun econt1 -> eval e2 cont econt1) econt
    | Or(e1, e2) -> 
      eval e1 cont (fun () -> eval e2 cont econt)
    | Seq(e1, e2) -> 
      eval e1 (fun _ -> fun econt1 -> eval e2 cont econt)
              (fun () -> eval e2 cont econt)
    | Every e -> 
      eval e (fun _ -> fun econt1 -> econt1 ())
             (fun () -> cont (Int 0) econt)
    | Fail -> econt ()

let run e = eval e (fun v -> fun _ -> v) (fun () -> (printfn "Failure"; Int 0))

printfn "Exercise 11.8 (i)"
run (Every(Write(Prim("+", Prim("*", CstI 2, FromTo(1, 4)), CstI 1)))) |> ignore

printfn "\nExercise 11.8 (i)"
run (Every(Write(Prim("+", Prim("*", FromTo(2, 4), CstI 10), FromTo(1, 2))))) |> ignore

printfn "\nExercise 11.8 (ii)"
run (Write(Prim("<", CstI 50, Prim("*", CstI 7, FromTo(1, 100))))) |> ignore
printfn ""


printfn "\nExercise 11.8 (iii) (a)"
run (Every(Write(Prim1("sqr", FromTo(3, 6))))) |> ignore

printfn "\nExercise 11.8 (iii) (b)"
run (Every(Write(Prim1("even", FromTo(1, 7))))) |> ignore

printfn "\nExercise 11.8 (iv)"
// We use And to limit the output to 10 results
let rec limitOutput n expr =
    if n <= 0 then Fail
    else Seq(Write expr, limitOutput (n-1) expr)

run (limitOutput 10 (Prim1("multiples", CstI 3))) |> ignore
