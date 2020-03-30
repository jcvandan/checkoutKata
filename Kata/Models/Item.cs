namespace Kata.Models
{
    public class Item
    {
        public Item(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
        
        public string Sku { get; }
        public decimal UnitPrice { get; }
    }
}