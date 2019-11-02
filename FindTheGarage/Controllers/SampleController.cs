using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindTheGarage.Controllers
{
    public class SampleController : Controller
    {
        #region Properties

        private readonly ISampleService _sampleService;

        #endregion
        #region Constructors

        public SampleController(
            ISampleService sampleService)
        {
            this._sampleService = sampleService;
        }

        #endregion
        #region Public Methods

        public IActionResult Index()
        {
            var data = _sampleService.GetAllSampleData();
            return View();
        }

        #endregion
        #region Helpers

        // ADD HERE

        #endregion
    }
}