namespace DSA.String;

public static class ZAlgorithm
{
    public static int[] ComputePrefixArray(string text)
    {
        int n = text.Length;
        var z = new int[text.Length];
        int l = 0, r = 0;

        for (int i = 1; i < n; i++)
        {
            if (i < r)
                z[i] = Math.Min(r - i, z[i - l]);

            while (i + z[i] < n && text[z[i]] == text[i + z[i]])
                z[i]++;

            if (i + z[i] > r)
            {
                l = i;
                r = i + z[i];
            }
        }

        return z;
    }
}
