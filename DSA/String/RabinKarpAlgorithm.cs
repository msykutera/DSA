namespace DSA.String;

public static class RabinKarpAlgorithm
{
    public readonly static int d = 256;

    public static int[] FindOccurrences(string text, string pattern, int q = 101)
    {
        var result = new List<int>();
        var m = pattern.Length;
        var n = text.Length;
        int i, j;
        var patternHash = 0;
        var textHash = 0;
        var h = 1;

        // The value of h would be "pow(d, M-1)%q"
        for (i = 0; i < m - 1; i++)
            h = (h * d) % q;

        // Calculate the hash value of pattern and first
        // window of text
        for (i = 0; i < m; i++)
        {
            patternHash = (d * patternHash + pattern[i]) % q;
            textHash = (d * textHash + text[i]) % q;
        }

        // Slide the pattern over text one by one
        for (i = 0; i <= n - m; i++)
        {

            // Check the hash values of current window of
            // text and pattern. If the hash values match
            // then only check for characters one by one
            if (patternHash == textHash)
            {
                /* Check for characters one by one */
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }

                // if p == t and pat[0...M-1] = txt[i, i+1,
                // ...i+M-1]
                if (j == m)
                    result.Add(i);
            }

            // Calculate hash value for next window of text:
            // Remove leading digit, add trailing digit
            if (i < n - m)
            {
                textHash = (d * (textHash - text[i] * h) + text[i + m]) % q;

                // We might get negative value of t,
                // converting it to positive
                if (textHash < 0)
                    textHash = (textHash + q);
            }
        }

        return [.. result];
    }
}