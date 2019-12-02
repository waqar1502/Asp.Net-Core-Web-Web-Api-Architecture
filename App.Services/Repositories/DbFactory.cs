using App.DataAccess.DbModels;

namespace App.Services.Repositories
{
    public class DbFactory : IDbFactory
    {
        FindTheGarageContext _dbContext;

        public FindTheGarageContext Init()
        {
            return _dbContext ?? (_dbContext = new FindTheGarageContext());
        }
    }
}
