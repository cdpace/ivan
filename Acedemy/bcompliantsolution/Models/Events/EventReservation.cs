using System;
namespace Models.Events
{
    public class EventReservation : BaseEntity
    {
        public EventReservation()
        {
        }

        public long EventId { get; set; }
        public long UserId { get; set; }

    }
}
