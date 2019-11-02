using App.DataAccess.Models;

namespace App.Services.Repositories
{
    public interface IDbFactory
    {
        FindTheGarageContext Init();
    }
}
