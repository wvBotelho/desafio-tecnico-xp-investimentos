namespace Core.Interfaces
{
    public class MongoDocument
    {
        public Guid Id { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public int Version { get; set; } = 1;
    }
}