namespace KeralaQuizApp.Models
{
    public class Question
    {
        public int Id { get; set; } // Unique question ID
        public string Text { get; set; } // Question text
        public string Option1 { get; set; } // First option
        public string Option2 { get; set; } // Second option
        public string Option3 { get; set; } // Third option
        public string Option4 { get; set; } // Fourth option
        public int CorrectAnswerIndex { get; set; } // Index of correct answer (0,1,2,3)
    }
}
