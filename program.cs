class Product
{
    public string Name { get; }
    public decimal BasePrice { get; }
    public int Count { get; }

    protected Product(string name, decimal basePrice, int count = 1)
    {
        Name = name;
        BasePrice = basePrice;
        Count = count;
    }

    public virtual decimal Price => BasePrice;

    public virtual decimal TotalPrice => Price * Count;

    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price}, Count: {Count}, Total price: {TotalPrice}";
    }
}

class Carrot : Product
{
    public Carrot(decimal basePrice) : base("Carrot", basePrice) { }
}

class Potato : Product
{
    public Potato(decimal basePrice, int count) : base("Potato", basePrice, count) { }

    public override decimal Price => BasePrice * Count;
}

class Cucumber : Product
{
    public Cucumber(decimal basePrice, int count) : base("Cucumber", basePrice, count) { }

    public override decimal Price => BasePrice * Count;
}

class VegetableShop
{
    private readonly List<Product> _products = new();

    public void AddProducts(IEnumerable<Product> products)
    {
        _products.AddRange(products);
    }

    public void PrintProductsInfo()
    {
        decimal totalProductsPrice = 0;

        foreach (var product in _products)
        {
            Console.WriteLine(product);
            totalProductsPrice += product.TotalPrice;
        }

        Console.WriteLine($"Total products price: {totalProductsPrice}");
    }
}
class Program
{
    static void Main()
    {
        var products = new List<Product>
        {
            new Carrot(15),
            new Potato(20, 4),
            new Cucumber(14, 2)
        };

        var shop = new VegetableShop();
        shop.AddProducts(products);

        shop.PrintProductsInfo();
    }
}
