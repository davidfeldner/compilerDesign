static int[] merge(int[] xs, int[] ys)
{
    var longestListLength = Math.Max(xs.Count(), ys.Count());
    int[] result = new int[xs.Count() + ys.Count()];
    var x = 0;
    var y = 0;
    var i = 0;
    while (i < xs.Count() + ys.Count())
    {
        if (xs.Count() <= x)
        {
            result[i++] = ys[y++];
            continue;
        }
        if (ys.Count() <= y)
        {
            result[i++] = xs[x++];
            continue;
        }
        if (xs[x] <= ys[y])
        {
            result[i++] = xs[x++];
        }
        else
        {
            result[i++] = ys[y++];
        }
    }
    return result;
}

foreach (var i in merge([3, 5, 12], [2, 3, 4, 7]))
{
    Console.WriteLine(i);
}
