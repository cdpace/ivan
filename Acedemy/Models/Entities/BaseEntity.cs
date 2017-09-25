using System;
namespace Models.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
        }

        public long Id { get; set; }
    }
}
