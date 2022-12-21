using CsvHelper.Configuration;
using System.Globalization;
using WebStack.Application.Affirmations.Queries.GetAffirmationsFile;

namespace WebStack.Infrastructure.Files
{
    public sealed class AffirmationFileRecordMap : ClassMap<AffirmationRecordDto>
    {
        public AffirmationFileRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Active).Name("Is Active?");
        }
    }
}
