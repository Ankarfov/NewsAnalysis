namespace News.Domain
{
    public class New
    {
        public int Id { get; set; }
        public string? Keyword { get; set; }
        public string? Language { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? Chapter { get; set; }
        public int? VowelsCount { get; set; }
    }
}
