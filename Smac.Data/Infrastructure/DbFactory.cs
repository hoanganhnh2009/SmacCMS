namespace Smac.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SmacDbContext dbContext;

        public SmacDbContext Init()
        {
            return dbContext ?? (dbContext = new SmacDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}