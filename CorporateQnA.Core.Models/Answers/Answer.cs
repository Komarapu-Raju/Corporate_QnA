namespace CorporateQnA.Core.Models.Answers
{
    public class Answer
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid QuestionId { get; set; }

        public Guid Answeredby { get; set; }

    }
}
