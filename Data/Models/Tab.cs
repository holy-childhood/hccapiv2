namespace hccapiv2.Data.Models
{
    public class Tab(string title, int index)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public int Index { get; set; } = index;
        public int? TabContentId { get; set; }
        public Content? Content { get; set; }
    }
}
