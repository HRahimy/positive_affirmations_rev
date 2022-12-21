namespace WebStack.Application.Affirmations.Queries.GetAffirmationsFile
{
    public class AffirmationsFileVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
