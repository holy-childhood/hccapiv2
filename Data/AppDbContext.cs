using hccapiv2.Data.Models;
using Microsoft.EntityFrameworkCore;
using File = hccapiv2.Data.Models.File;

namespace hccapiv2.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarEvent> CalendarEvents {  get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<CalendarContent> CalendarContent { get; set; }
        public DbSet<TextContent> TextContents { get; set; }
        public DbSet<TabContent> TabContents { get; set; }
        public DbSet<FileContent> FileContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>()
               .HasDiscriminator(c => c.ContentType)
               .HasValue<TextContent>(ContentType.Text)
               .HasValue<CalendarContent>(ContentType.Calendar)
               .HasValue<FileContent>(ContentType.File)
               .HasValue<TabContent>(ContentType.Tab);

            // Seed Data
            modelBuilder.Entity<Page>().HasData(new Page("Home") { Id = 1, Index = 0 });
            modelBuilder.Entity<Calendar>().HasData(new Calendar("Parish") { Id = 1 });
            modelBuilder.Entity<EventType>().HasData([
                new EventType(1, "Standard", "Blue"),
                new EventType(2, "Meeting", "Red"),
                new EventType(3, "Mass", "Green"),
                new EventType(4, "Holiday", "Gray")
            ]);

            base.OnModelCreating(modelBuilder);
        }
    }
}
