using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerServices;

        public AnswerController(IAnswerService answerServices)
        {
            this._answerServices = answerServices;
        }
    }
}
