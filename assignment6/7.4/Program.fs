open ParseAndRun
open Absyn

printf "%A\n" (
    run (Prog [Fundec
     (None, "main", [],
      Block [Dec (TypI, "i"); 
             Stmt (Expr (Assign (AccVar "i", CstI 1))); 
             Stmt (Expr (PreDec (AccVar "i")))
        ])]) []
)


printf "%A\n" (
    run (Prog [Fundec
     (None, "main", [],
      Block [Dec (TypI, "i"); 
             Stmt (Expr (Assign (AccVar "i", CstI 1))); 
            Stmt (Expr (PreInc (AccVar "i")))])
        ]) []
)

