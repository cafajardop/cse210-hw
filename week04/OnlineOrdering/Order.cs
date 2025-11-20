public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private decimal GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5m : 35m;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        total += GetShippingCost();

        return total;
    }

    public string GetPackingLabel()
    {
        var builder = new System.Text.StringBuilder();

        foreach (var product in _products)
        {
            builder.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }

        return builder.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} {_customer.GetAddress().GetFullAddress()}";
    }
}
