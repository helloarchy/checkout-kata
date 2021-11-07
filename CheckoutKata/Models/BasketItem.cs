namespace CheckoutKata.Models
{
    public class BasketItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Subtotal = product.UnitPrice * quantity;
        }
    }
}