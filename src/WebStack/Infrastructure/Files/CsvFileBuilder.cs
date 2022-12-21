using CsvHelper;
using System.Globalization;
using WebStack.Application.Affirmations.Queries.GetAffirmationsFile;
using WebStack.Application.Common.Interfaces;

namespace WebStack.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildAffirmationsFile(IEnumerable<AffirmationRecordDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.Context.RegisterClassMap<AffirmationFileRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
