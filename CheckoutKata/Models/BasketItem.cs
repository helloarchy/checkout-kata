namespace CheckoutKata.Models
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalAfterDiscount { get; set; }
    }
}