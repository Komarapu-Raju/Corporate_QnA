namespace CorporateQnA.Core.Models.Dtos.AnswerDtos
{
    public class NewAnswer
    {
        public string Description { get; set; }

        public int QuestionId { get; set; }

        public int Answeredby { get; set; }

    }
}
