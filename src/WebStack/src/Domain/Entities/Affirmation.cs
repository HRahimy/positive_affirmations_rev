namespace WebStack.Domain.Entities;
public class Affirmation : BaseAuditableEntity
{
    public string Title { get; set; }
    public string? Subtitle { get; set; }
    public bool? Active { get; set; }
}
