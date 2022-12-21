using Microsoft.EntityFrameworkCore;

namespace WebStack.Persistence
{
    public class WebStackDbContextFactory : DesignTimeDbContextFactoryBase<WebStackDbContext>
    {
        protected override WebStackDbContext CreateNewInstance(DbContextOptions<WebStackDbContext> options)
        {
            return new WebStackDbContext(options);
        }
    }
}
