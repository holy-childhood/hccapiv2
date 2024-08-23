namespace hccapiv2.Data.Models
{
    public class Calendar(string title)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public List<CalendarEvent> Events { get; set; } = [];
    }

    public class CalendarEvent(string title, DateTime startDate)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public DateTime StartDate { get; set; } = startDate;
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public bool IsAllDay { get; set; } = false;
        public bool IsRecurring { get; set; } = false;
        public RecurrenceType RecurrenceType { get; set; }
        public Guid? RecurrenceGuid { get; set; }
        public int? EventTypeId { get; set; }
        public EventType? EventType { get; set; }

    }

    public class EventType(int id, string title, string color)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Color {  get; set; } = color;
    }

    public enum RecurrenceType
    {
        Weekly = 1,
        MonthlyDate = 2,
        MonthlyWeek = 3,
        Yearly = 4
    }
}
