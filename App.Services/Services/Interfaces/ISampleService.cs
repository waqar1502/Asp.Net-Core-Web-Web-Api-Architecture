using System.Collections.Generic;
using App.Models.ViewModels;

namespace App.Services.Services.Interfaces
{
    public interface ISampleService
    {
        #region Properties

        List<SampleViewModel> GetAllSampleData();


        #endregion

    }
}
