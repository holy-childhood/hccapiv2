namespace hccapiv2.Data.Models
{
    public class Page(string title)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public int Index { get; set; }
        public int? MenuId { get; set; }
        public Menu? Menu { get; set; }
        public List<Content> Contents { get; set; } = [];
    }
}
