using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FindTheGarageWebApi.ActionFilters
{
    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return  null;
        }
    }
}
