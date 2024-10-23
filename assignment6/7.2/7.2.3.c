


void histogram(int n, int ns[], int max, int freq[]) {
  while (n > 0) {
    n = n - 1;
    print ns[n];
    freq[ns[n]] = freq[ns[n]] + 1;
  }
}

void main() {
  int arr[7];
  int freq[2];
  freq[0] = 0;
  freq[1] = 0;
  freq[2] = 0;

  arr[0] = 1;
  arr[1] = 2;
  arr[2] = 1;
  arr[3] = 1;
  arr[4] = 1;
  arr[5] = 2;
  arr[6] = 0;
  histogram(7, arr, 2, freq);
  println;

  print freq[2];
  println;
}


