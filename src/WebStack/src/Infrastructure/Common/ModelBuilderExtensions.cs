using Microsoft.EntityFrameworkCore;

namespace WebStack.Infrastructure.Common;
public static class ModelBuilderExtensions
{
    public static void ConvertToSnakeCase(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToSnakeCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
            }

            foreach (var key in entity.GetIndexes())
            {
                key.SetDatabaseName(key.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}
