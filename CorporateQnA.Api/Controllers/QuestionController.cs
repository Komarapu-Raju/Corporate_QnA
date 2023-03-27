using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices _questionServices;

        public QuestionController(IQuestionServices questionServices)
        {
            this._questionServices = questionServices;
        }
    }
}
