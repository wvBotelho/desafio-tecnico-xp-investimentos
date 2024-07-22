namespace Core.Interfaces
{
    public class MongoDocument
    {
        public int Version { get; set; }

        public Guid Id { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime Created_At 
        { 
            get => DateTime.UtcNow;
        } 

        public DateTime? Updated_At { get; set; }
    }
}