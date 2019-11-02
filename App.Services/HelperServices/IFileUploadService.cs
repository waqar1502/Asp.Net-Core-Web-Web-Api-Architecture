using Microsoft.AspNetCore.Http;

namespace App.Services.HelperServices
{
    public interface IFileUploadService
    {
        string UploadFile(IFormFile files);
    }
}
