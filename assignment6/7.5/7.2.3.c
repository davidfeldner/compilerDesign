void main() {
  int x[10];
  int y;
  y = 0;
  x[y]     = 5;
  x[y + 1] = 42;
  ++x[++y]; // <-- careful!
  ++x[y];
  print x[y];
  print y;
}
