using System;
using Flunt.Notifications;

namespace Trade.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);
        }

        public string Id { get; private set; }
    }
}