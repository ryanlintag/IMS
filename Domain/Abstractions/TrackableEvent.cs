using Newtonsoft.Json;

namespace Domain.Abstractions
{
    public class TrackableEvent<T> where T : IDomainEvent
    {
        private TrackableEvent() { }
        protected TrackableEvent(Int64 version, T jsonData)
        {
            this.Version = version;
            this.EventType = typeof(T).ToString();
            this.JsonData = JsonConvert.SerializeObject(jsonData);
        }
        public Int64 Version { get; private set; }
        public string EventType { get; private set; }
        public string JsonData { get; private set; }
    }
}
