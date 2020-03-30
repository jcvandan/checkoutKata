namespace Kata
{
    public class Checkout
    {
        private decimal _runningTotal = 0m;
        
        public decimal Total()
        {
            return _runningTotal;
        }
 
        public void Scan(Item item)
        {
            _runningTotal += item.UnitPrice;
        }
    }
}