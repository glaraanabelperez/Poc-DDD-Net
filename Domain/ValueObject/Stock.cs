namespace DoamDomainin.ValueObject
{
    public record Stock
    {
        public int Quantity { get; set; }

        public Stock(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Stock cannot be negative");

            Quantity = quantity;
        }

    }
}