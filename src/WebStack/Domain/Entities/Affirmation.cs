namespace WebStack.Domain.Entities
{
    public class Affirmation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Subtitle { get; set; }

        // Reference to why `Active` property's type is a nullable bool:
        // https://stackoverflow.com/a/70436242
        // https://github.com/dotnet/efcore/issues/12198
        public bool? Active { get; set; }
    }
}
