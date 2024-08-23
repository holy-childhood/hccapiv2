namespace hccapiv2.Data.Models
{
    public class Menu(string title, int index)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public int Index { get; set; } = index;
        public List<Page> Pages { get; set; } = [];
    }
}
