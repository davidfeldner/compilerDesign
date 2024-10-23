void histogram(int n, int ns[], int max, int freq[]) {
  int i;
  for (i = 0; i < n; i = i + 1) {
    freq[ns[i]] = freq[ns[i]] + 1;
  }
}

void main() {
  int arr[7];
  int freq[3];
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
  int i;
  for (i = 0; i < 3; i = i + 1) {
    print(freq[i]);
  }
  println;
}
