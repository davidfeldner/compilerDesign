using System.Reflection.Metadata.Ecma335;

namespace OnePointFour;



abstract class Expr {
    public abstract string toString();
    public abstract int eval(List<(string, int)> env);
    public abstract Expr simplify();
}


class CstI : Expr {
    public int i;
    public CstI (int newI) {
        i = newI;
    }

    public override string toString() {
        return $"{i}";
    }

    public override int eval(List<(string, int)> env) {
        return i;
    }

    public override Expr simplify() {
        return this;
    }
}

class Var : Expr {
    public string s;
    public Var (string newS) {
        s = newS;
    }

    public override string toString() {
        return $"{s}";
    }

    public override int eval(List<(string, int)> env) {
        return env.Find(t => t.Item1 == s).Item2;
    }

    public override Expr simplify() {
        return this;
    }
}

abstract class Binop : Expr {

}

class Add : Binop {
    Expr _e1;
    Expr _e2;
    public Add (Expr e1, Expr e2) {
        _e1 = e1;
        _e2 = e2;
    }
    public override string toString() {
        return $"{_e1.toString()}+{_e2.toString()}";
    }

    public override int eval(List<(string, int)> env) {
        return _e1.eval(env) + _e2.eval(env);
    }

    public override Expr simplify() {
        var s1 = _e1.simplify();
        var s2 = _e2.simplify();

        if (s1 is CstI i1 && s2 is CstI i2) { 
            return new CstI (i1.i + i2.i); 
        } else if (s1 is CstI i3 && i3.i == 0) {
            return s2;
        } else if (s2 is CstI i4 && i4.i == 0) {
            return s1;
        } else {
            return new Add(s1, s2);
        }
    }
}
class Mul : Binop {
    Expr _e1;
    Expr _e2;
    public Mul (Expr e1, Expr e2) {
        _e1 = e1;
        _e2 = e2;
    }
    public override string toString() {
        return $"{_e1.toString()}*{_e2.toString()}";
    }

    public override int eval(List<(string, int)> env) {
        return _e1.eval(env) * _e2.eval(env);
    }

    public override Expr simplify() {
        var s1 = _e1.simplify();
        var s2 = _e2.simplify();

        if (s1 is CstI i1 && s2 is CstI i2) { 
            return new CstI (i1.i * i2.i); 
        } else if (s1 is CstI i3 && (i3.i == 1 || i3.i == 0)) {
            return i3.i == 1 ? s2: new CstI (0);
        } else if (s2 is CstI i4 && (i4.i == 1 || i4.i == 0)) {
            return i4.i == 1 ? s1: new CstI (0);;
        } else {
            return new Mul(s1, s2);
        }
    }
}
class Sub : Binop {
    Expr _e1;
    Expr _e2;
    public Sub (Expr e1, Expr e2) {
        _e1 = e1;
        _e2 = e2;
    }
    public override string toString() {
        return $"{_e1.toString()}-{_e2.toString()}";
    }

    public override int eval(List<(string, int)> env) {
        return _e1.eval(env) - _e2.eval(env);
    }

    public override Expr simplify() {
        var s1 = _e1.simplify();
        var s2 = _e2.simplify();

        if (s1 is CstI i1 && s2 is CstI i2) { 
            return new CstI (i1.i - i2.i); 
        } else if (s2 is CstI i3 && i3.i == 0) {
            return s1;
        } else {
            return new Sub(s1, s2);
        }
    }
}

