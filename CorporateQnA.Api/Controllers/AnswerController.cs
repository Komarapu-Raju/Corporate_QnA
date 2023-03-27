using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerServices _answerServices;

        public AnswerController(IAnswerServices answerServices)
        {
            this._answerServices = answerServices;
        }
    }
}
