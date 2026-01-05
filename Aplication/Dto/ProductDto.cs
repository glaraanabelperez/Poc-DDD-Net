namespace Aplication.Dto
{
    public class ProductDto
    {
        public long productId { get;  set; }
        public string Name { get;  set; }
        public string serie { get;  set; }
        public int stock { get;  set; }
        public long desposito { get;  set; }
        public long? provedorId { get;  set; }
        public bool garantia { get;  set; }
    }
}
