namespace CorporateQnA.Core.Models.Dtos.Request
{
    public class NewAnswerDto
    {
        public string Description { get; set; }

        public int QuestionId { get; set; }

        public int Answeredby { get; set; }

    }
}
