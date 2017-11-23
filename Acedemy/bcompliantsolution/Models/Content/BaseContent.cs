using System;
namespace Models.Content
{
    public abstract class BaseContent : BaseEntity
    {
        public string DateUploaded { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
