public interface IEntity
{
    int Id { get; }
}

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public override string ToString() => $"[Product] Id: {Id}, Name: {Name}, Price: {Price:C}";
}

public class User : IEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public override string ToString() => $"[User] Id: {Id}, Login: {Username},  Name: {Name}";
}
