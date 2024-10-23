
void arrsum(int n, int arr[], int *sump) {
  int i;
  *sump = 0;
  for (i = 0; i < n; i = i + 1) {
    *sump = *sump + arr[i];
  }
}

void squares(int n, int arr[]) {
  int i;
  for (i = 0; i < n; i = i + 1) {
    arr[i] = i * i;
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
