using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FindTheGarageWebApi.CustomResults
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Hiri.WebApi.CustomResults.InternalServerErrorObjectResult" /> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public InternalServerErrorObjectResult(object value)
            : base(value)
        {
            base.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
