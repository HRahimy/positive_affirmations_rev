using WebStack.Application.Affirmations.Queries.GetAffirmationsFile;

namespace WebStack.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildAffirmationsFile(IEnumerable<AffirmationRecordDto> records);
    }
}
