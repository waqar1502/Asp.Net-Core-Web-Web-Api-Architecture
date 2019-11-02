using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace App.Services.HelperServices
{
    public class FileUploadService : IFileUploadService
    {
        #region Properties
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructors
        public FileUploadService(
            IHostingEnvironment hostingEnvironment,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Public Methods

        public string UploadFile(IFormFile files)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string Pathstring = webRootPath + "/Images";
            var fileName = "";
            if (files.Length > 0)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(files.FileName);
                using (var stream = new FileStream(Path.Combine(Pathstring, fileName), FileMode.Create))
                {
                    files.CopyTo(stream);
                }
            }

            return fileName;
        }

        #endregion

        #region Helpers

        #endregion
    }
}
