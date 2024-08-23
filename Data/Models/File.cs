namespace hccapiv2.Data.Models
{
    public class File(string name, string extension, string blobId, DateTime createdAt)
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = name;
        public string Extension { get; set; } = extension;
        public string BlobId { get; set; } = blobId;
        public DateTime CreatedAt { get; set; } = createdAt;
    }
}
