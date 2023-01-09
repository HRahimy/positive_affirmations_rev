namespace WebStack.Domain.Events;
public class AffirmationCreated : BaseEvent
{
    public AffirmationCreated(Affirmation affirmation)
    {
        Affirmation = affirmation;
    }
    public Affirmation Affirmation { get; }
}
