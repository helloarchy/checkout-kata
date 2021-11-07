namespace CheckoutKata.Models
{
    public class BasketItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalAfterDiscount { get; }

        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            TotalAfterDiscount = product.UnitPrice * quantity;
        }
        
        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            SubTotal = Product.UnitPrice * quantity;
        }
    }
}