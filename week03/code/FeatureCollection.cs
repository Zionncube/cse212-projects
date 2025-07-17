public class FeatureCollection
{
    // List of earthquake features from the JSON
    public List<Feature> Features { get; set; }
}

// Represents each feature in the list
public class Feature
{
    public Properties Properties { get; set; }
}

// Holds the location and magnitude of the earthquake
public class Properties
{
    public string Place { get; set; }      // Location description
    public double? Mag { get; set; }       // Magnitude
}
