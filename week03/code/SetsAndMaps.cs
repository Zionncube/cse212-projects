using System.Text.Json;
using System.Diagnostics;

public static class SetsAndMaps
{
    // PROBLEM 1: FIND PAIRS
    public static string[] FindPairs(string[] words)
    {
        // Use a HashSet to store all words for O(1) lookup
        var wordSet = new HashSet<string>(words);

        // List to store valid symmetric pairs
        var result = new List<string>();

        // HashSet to track already paired words
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            // Skip words with identical letters (e.g., "aa")
            if (word[0] == word[1]) continue;

            // Reverse the current word
            var reversed = new string(new[] { word[1], word[0] });

            // Check if reversed exists and hasn't been used already
            if (wordSet.Contains(reversed) && !seen.Contains(reversed) && !seen.Contains(word))
            {
                // Add to result and mark both words as seen
                result.Add($"{word} & {reversed}");
                seen.Add(word);
                seen.Add(reversed);
            }
        }

        return result.ToArray();
    }

    // PROBLEM 2: SUMMARIZE DEGREES
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        // Read the file line by line
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Ensure the line has at least 4 columns
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();

                // Count occurrences of each degree
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    // PROBLEM 3: IS ANAGRAM
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize both words: remove spaces and convert to lowercase
        string clean1 = new string(word1.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
        string clean2 = new string(word2.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());

        // If lengths differ, not an anagram
        if (clean1.Length != clean2.Length) return false;

        var dict = new Dictionary<char, int>();

        // Count characters in first word
        foreach (char c in clean1)
        {
            if (!dict.ContainsKey(c)) dict[c] = 0;
            dict[c]++;
        }

        // Decrease count for second word
        foreach (char c in clean2)
        {
            if (!dict.ContainsKey(c)) return false;
            dict[c]--;
            if (dict[c] < 0) return false;
        }

        return true;
    }

    // PROBLEM 5: EARTHQUAKE DAILY SUMMARY
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        // Allow case-insensitive deserialization
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Deserialize JSON to custom object model
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Extract summary strings with place and magnitude
        var summaries = featureCollection.Features
            .Where(f => f.Properties.Place != null && f.Properties.Mag.HasValue)
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag.Value}")
            .ToArray();

        return summaries;
    }
}
