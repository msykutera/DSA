namespace DSA.String;

public static class KmpAlgorithm
{
    public static int[] FindOccurrences(string text, string pattern)
    {
        if (pattern == null || pattern.Length == 0) return [0];
        if (text == null || pattern.Length > text.Length) return [];

        var result = new List<int>();

        int[] next = new int[pattern.Length + 1];
        for (int i = 1; i < pattern.Length; i++)
        {
            int j = next[i];

            while (j > 0 && pattern[j] != pattern[i])
            {
                j = next[j];
            }

            if (j > 0 || pattern[j] == pattern[i])
            {
                next[i + 1] = j + 1;
            }
        }

        for (int i = 0, j = 0; i < text.Length; i++)
        {
            if (j < pattern.Length && text[i] == pattern[j])
            {
                if (++j == pattern.Length)
                {
                    result.Add(i - j + 1);
                }
            }
            else if (j > 0)
            {
                j = next[j];
                i--;
            }
        }

        return [.. result];
    }
}
