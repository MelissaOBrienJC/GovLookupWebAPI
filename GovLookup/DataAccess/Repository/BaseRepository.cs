namespace GovLookup.DataAccess.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public  GovLookupDBContext GovLookupDbContext { get; set; }
    }
}
