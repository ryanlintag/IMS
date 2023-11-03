namespace Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected Entity(Guid id) 
        {
            this.Id = id;
        }
        protected Entity() { }
        public Guid Id { get; protected set; }

        public List<IDomainEvent> DomainEvents { get {  return _domainEvents; } }

        protected void Raise(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
