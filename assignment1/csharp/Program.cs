using intro1;

Expr e = new Add(new CstI(17), new Var("z"));
Console.WriteLine(e.toString());


Expr e1 = new Add(new Mul(new CstI(2), new CstI(5)), new Var("z"));
Console.WriteLine(e1.toString());

Expr e2 = new Sub(new Add(new Var("x"), new CstI(5)), new Sub(new Var("x"), new CstI(2)));
Console.WriteLine(e2.toString());

Expr e3 = new Mul(new Mul(new Var("x"), new Mul(new Var("x"), new CstI(9))), new Sub(new Var("y"), new Mul(new Var("x"), new CstI(9))));
Console.WriteLine(e3.toString());


Expr e4 = new Add(new Add(new CstI(2), new CstI(0)), new Var("z"));
Console.WriteLine(e4.simplify().toString());


Expr e5 = new Add(new Add(new CstI(2), new CstI(0)), new Sub(new Var("z"), new CstI(0)));
Console.WriteLine(e5.simplify().toString());

Expr e6 = new Mul(new Add(new Add(new CstI(2), new CstI(0)), new Sub(new Var("z"), new CstI(0))), new CstI(0));
Console.WriteLine(e6.simplify().toString());