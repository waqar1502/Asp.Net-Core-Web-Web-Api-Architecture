using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Models.AppModels;
using App.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindTheGarageWebApi.Controllers
{
    [Route("api/v1/user/Chatbot")]
   //// [Authorize]
    public class SampleDataController : ApiBaseController
    {
        #region Properties

        private readonly ISampleService _sampleService;

        #endregion
        #region Constructors

        public SampleDataController(
            ISampleService sampleService)
        {
            this._sampleService = sampleService;
        }

        #endregion
        #region Public Methods

        [HttpGet("")]
        [ProducesResponseType(typeof(GetSampleDataAppModel), Constants.Http200)]
        public IActionResult Index()
        {
            var result = new GetSampleDataAppModel();

            var data = new SampleDataAppModel
            {
                AllData = _sampleService.GetAllSampleData()
            };

            result.Content = data;

            return Success(result);
        }

        #endregion
        #region Helpers

        // ADD HERE

        #endregion
    }
}