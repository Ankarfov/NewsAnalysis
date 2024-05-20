namespace News.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id) : base($"Entity ({id})id not found.") { }
    }
}
