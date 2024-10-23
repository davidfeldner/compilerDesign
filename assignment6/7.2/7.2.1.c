

void arrsum(int n, int arr[], int *sump) {
  *sump = 0;
  while (n > 0) {
    n = n - 1;
    *sump = *sump + arr[n];
  }
}

void main() {
  int n;
  n=4;
  int arr[4];
  arr[0] = 7;
  arr[1] = 13;
  arr[2] = 9;
  arr[3] = 8;
  int res;
  arrsum(n, arr, &res);
  print res;
  println;
}


