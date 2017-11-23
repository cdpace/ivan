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
        public DateTime DateRequested { get; set; }
        public bool Approved { get; set; }
        public DateTime DateApproved { get; set; }
    }
}
