using DoamDomainin.ValueObject;
using Domain.Events;

namespace Domain.Agregates
{
    public class Product
    {
       public long Id { get; private set; }                
       public string Name { get; private set; }
       public Stock Stock { get; private set; } 
       public long desposito { get; private set; }
       public IReadOnlyCollection<IDomainEvent> _evts { get; private set; }

        public Product(string name, int stock, long desposito)
        {
            Id = Id;
            Name = name;
            Stock = new Stock(stock);
            this.desposito = desposito;
            _evts = new List<IDomainEvent>();

            _evts = _evts.Append(new ProductCreatedDomainEvent(Name, Stock.Quantity, desposito, Id)).ToList();
        }
    }
}