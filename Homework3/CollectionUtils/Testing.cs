public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public override string ToString() => $"{Name} ({Price:C})";
}

class Testing
{
    static void Main()
    {
        var numbers = new List<int> { 1, 2, 2, 3, 1, 4 };
        var uniqueNumbers = CollectionUtils.Distinct(numbers);
        Console.WriteLine($"Distinct Ints: {string.Join(", ", uniqueNumbers)}");

        var strings = new List<string> { "A", "B", "A", "C" };
        var uniqueStrings = CollectionUtils.Distinct(strings);
        Console.WriteLine($"Distinct Strings: {string.Join(", ", uniqueStrings)}");

        var words = new List<string> { "apple", "banana", "pear", "kiwi", "grape" };
        var groupedByLength = CollectionUtils.GroupBy(words, w => w.Length);
        Console.WriteLine("\nGroups by length:");
        foreach (var group in groupedByLength)
        {
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Value)}");
        }

        var dict1 = new Dictionary<string, int> { { "apple", 2 }, { "banana", 5 } };
        var dict2 = new Dictionary<string, int> { { "apple", 3 }, { "cherry", 10 } };
        var merged = CollectionUtils.Merge(dict1, dict2, (v1, v2) => v1 + v2);
        Console.WriteLine("\nMerged Dictionaries (Sum on conflict):");
        foreach (var kvp in merged)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        var products = new List<Product>
        {
            new Product { Name = "Phone", Price = 800 },
            new Product { Name = "Laptop", Price = 1500 },
            new Product { Name = "Tablet", Price = 600 }
        };
        var expensive = CollectionUtils.MaxBy(products, p => p.Price);
        Console.WriteLine($"\nMost expensive product: {expensive}");
    }
}
