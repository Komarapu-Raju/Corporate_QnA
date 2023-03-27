using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionServices;

        public QuestionController(IQuestionService questionServices)
        {
            this._questionServices = questionServices;
        }
    }
}
