public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    
    public Product(string name, string productId { _productId = productId;}, decimal price, int quantity)
    public string GetProductId() => _productId;
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity; 
    }

    public string GetName() => _name;
    public string GeProductId() => _productId;
    public decimal GetTotalCost() => _price * _quantity;  
}