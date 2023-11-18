using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    internal abstract class EventTrackableBase<TId> : Entity<TId> where TId : EntityId
    {
        protected EventTrackableBase(TId id, Guid eventId, Int64 version, string eventType, string jsonData) : base(id)
        {
            this.EventId = eventId;
            this.Version = version;
            this.EventType = eventType;
            this.JsonData = jsonData;
        }
        public Guid EventId { get; private set; }
        public Int64 Version { get; private set; }
        public string EventType { get; private set; }
        public string JsonData{ get; private set; }
    }
}
