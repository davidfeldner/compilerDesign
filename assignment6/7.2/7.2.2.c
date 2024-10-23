
void arrsum(int n, int arr[], int *sump) {
  *sump = 0;
  while (n > 0) {
    n = n - 1;
    *sump = *sump + arr[n];
  }
}


void squares(int n, int arr[]) {
  while (n > 0) {
    n = n - 1;
    arr[n] = n * n;
  }
}

void main(int n) {
  int arr[20];
  squares(n, arr);

  int res;
  arrsum(n, arr, &res);
  print res;
  println;
}


