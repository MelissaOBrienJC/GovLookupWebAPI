namespace GovLookup.DataAccess.Repository
{
    public interface IBaseRepository
    {
        GovLookupDBContext GovLookupDbContext { get; set; }
    }
}
