namespace Core.Models
{
    public abstract record MongoDocument
    {
        public Guid Id { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;

        public int Version { get; set; } = 1;
    }
}