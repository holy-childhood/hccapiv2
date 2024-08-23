namespace hccapiv2.Data.Models
{
    public enum ContentType
    {
        Text = 0,
        Tab = 1,
        Calendar = 2,
        File = 3
    }

    public abstract class Content(int index, string? title = null, int width = 12, bool canResize = true)
    {
        public int Id { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Text;
        public string? Title { get; set; } = title;
        public int Index { get; set; } = index;
        public int Width { get; set; } = width;
        public bool CanResize { get; set; } = canResize;
        public int? PageId { get; set; }
        public Page? Page { get; set; }
    }

    public class TextContent(int index, string? title = null) : Content(index, title)
    {
        public string Text { get; set; } = string.Empty;
    }

    public class CalendarContent(int index, string? title = null, int calendarId = 0) : Content(index, title, 12, false)
    {
        public int CalendarId { get; set; } = calendarId;
        public Calendar? Calendar { get; set; }
    }

    public class FileContent(int index, string? title = null) : Content(index, title, 12, false)
    {
        public List<File> Files { get; set; } = [];
    }

    public class TabContent(int index, string? title = null) : Content(index, title)
    {
        public List<Tab> Tabs { get; set; } = [];
    }
}
