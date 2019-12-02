using App.DataAccess.DbModels;

namespace App.Services.Repositories
{
    public interface IDbFactory
    {
        FindTheGarageContext Init();
    }
}
