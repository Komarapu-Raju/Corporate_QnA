namespace CorporateQnA.Core.Models.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public int QuestionsAsked { get; set; }

        public int QuestionsSolved { get; set; }

        public int QuestionsAnswered { get; set; }

        public int UpvotesRecieved { get; set; }

        public int DownvotesRecieved { get; set; }
    }
}
