namespace Aplication.Models
{
    public class ProductDto
    {
        public long productId { get; private set; }
        public string Name { get; private set; }
        public string serie { get; private set; }
        public int stock { get; private set; }
        public long desposito { get; private set; }
        public long? provedorId { get; private set; }
        public bool garantia { get; private set; }
    }
}
