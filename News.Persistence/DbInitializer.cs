namespace News.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(NewsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
