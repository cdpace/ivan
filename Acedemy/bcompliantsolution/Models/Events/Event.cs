using System;
namespace Models.Events
{
    public class Event : BaseEntity
    {
        public Event()
        {
        }

        public string Title { get; set; }
        public DateTime DateTakingPlace { get; set; }
        public int NumberOfSpots { get; set; }
        public int NumberOfSpotsRemaing { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
