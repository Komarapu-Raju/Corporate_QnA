using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Core.Models.Dtos.AnswersDtos
{
    public class AddAnswerDto
    {
        public string Description { get; set; }

        public int QuestionId { get; set; }

        public int Answeredby { get; set; }

    }
}
