using DoamDomainin.ValueObject;

namespace Domain.Agregates
{
    public class Product
    {
       public string Name { get; private set; }
       public string serie { get; private set; }
       public Stock Stock { get; private set; } 
       public long desposito { get; private set; }
       public long? provedorId { get; private set; }
       public bool garantia { get; private set; }
       //public IReadOnlyCollection<IDomainEvent> _evts { get; private set; }

       public Product(string name, string serie, int stock, long desposito, bool garantia_, long? provedorId_ = null)
       {
            Name = name;
            Stock = new Stock(stock);
            this.desposito = desposito;
            garantia = garantia_;
            if (garantia && (provedorId == null || provedorId_ > 0))
                throw new ArgumentException("Proveedor must be provided if garantia is true.");
            provedorId = provedorId_;
            //_evts = new List<IDomainEvent>();

            //_evts = _evts.Append(new ProductCreatedDomainEvent(Id)).ToList();
        }
    }
}