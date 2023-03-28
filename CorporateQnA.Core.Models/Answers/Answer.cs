namespace CorporateQnA.Core.Models.Answers
{
    public class Answer
    {
        public string Description { get; set; }

        public int QuestionId { get; set; }

        public int Answeredby { get; set; }

    }
}
