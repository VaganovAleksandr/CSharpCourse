class Program
{
    static void Main()
    {
        var productRepo = new Repository<Product>();
        productRepo.Add(new Product { Id = 1, Name = "Laptop", Price = 200_000 });
        productRepo.Add(new Product { Id = 2, Name = "Mice", Price = 2500 });
        productRepo.Add(new Product { Id = 3, Name = "Monitor", Price = 12_000 });

        Console.WriteLine($"Total products: {productRepo.Count}");

        var p = productRepo.GetById(1);
        Console.WriteLine($"Found by Id=1: {p?.Name}");

        Console.WriteLine("\nProducts with price > 1000:");
        var expensiveProducts = productRepo.Find(x => x.Price > 1000);
        foreach (var prod in expensiveProducts) Console.WriteLine(prod);

        try
        {
            Console.WriteLine("\nAttempt to add dublicate with Id=1...");
            productRepo.Add(new Product { Id = 1, Name = "Error", Price = 0 });
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        var userRepo = new Repository<User>();
        userRepo.Add(new User { Id = 101, Username = "admin" });
        userRepo.Add(new User { Id = 102, Username = "guest" });

        foreach (var user in userRepo.GetAll())
        {
            Console.WriteLine(user);
        }
        
        Console.WriteLine("\nDeleting user with id = 102: " + userRepo.Remove(102));
        Console.WriteLine($"Users left: {userRepo.Count}");
    }
}
