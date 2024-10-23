include the abstract syntax tree and indicate its parts:
declarations, statements, types and expressions.

ex1.c
```fs
Prog
  [Fundec  // declaration
                    // type Integer
     (None, "main", [(TypI , "n")], 
      Block
        [Stmt  // statement
           (While
                    // expression 
              (Prim2 (">", Access (AccVar "n"), CstI 0),
               Block
                // statement
                 [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                 // statement
                  Stmt
                    // expression
                    (Expr
                       (Assign
                                            // expression
                          (AccVar "n", Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
        // statement   expression
         Stmt (Expr (Prim1 ("printc", CstI 10)))])]
```

ex3.c
```fs
Prog
  [Fundec // declaration
                    // type Integer
     (None, "main", [(TypI, "n")],
      Block
    //declaration | type Integer
        [Dec (TypI, "i"); Stmt (Expr (Assign (AccVar "i", CstI 0)));
         Stmt  // statement
           (While
                    // expression
              (Prim2 ("<", Access (AccVar "i"), Access (AccVar "n")),
               Block
                // statement  expression
                 [Stmt (Expr (Prim1 ("printi", Access (AccVar "i"))));
                // statement  
                  Stmt
                    // expression
                    (Expr
                       (Assign
                                // expression
                          (AccVar "i", Prim2 ("+", Access (AccVar "i"), CstI 1))))]))])]
```