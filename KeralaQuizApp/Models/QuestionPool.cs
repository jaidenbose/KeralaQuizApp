using System;
using System.Collections.Generic;
using System.Linq;
using KeralaQuizApp.Models;

namespace KeralaQuizApp.Models
{
    public static class QuestionPool
    {
        private static readonly List<Question> Questions = new()
        {
            new Question { Id = 1, Text = "What is the capital of Kerala?", Option1 = "Kochi", Option2 = "Thiruvananthapuram", Option3 = "Kozhikode", Option4 = "Kottayam", CorrectAnswerIndex = 1 },
            new Question { Id = 2, Text = "Which river is known as the lifeline of Kerala?", Option1 = "Periyar", Option2 = "Bharathapuzha", Option3 = "Pamba", Option4 = "Chaliyar", CorrectAnswerIndex = 0 },
            new Question { Id = 3, Text = "Which festival is known as the ‘Festival of Kerala’?", Option1 = "Onam", Option2 = "Vishu", Option3 = "Thrissur Pooram", Option4 = "Easter", CorrectAnswerIndex = 0 },
            new Question { Id = 4, Text = "Who is the founder of modern Kerala?", Option1 = "Mahatma Gandhi", Option2 = "E. M. S. Namboodiripad", Option3 = "Sree Narayana Guru", Option4 = "Swami Vivekananda", CorrectAnswerIndex = 2 },
            new Question { Id = 5, Text = "Which dance form originated in Kerala?", Option1 = "Bharatanatyam", Option2 = "Kathakali", Option3 = "Odissi", Option4 = "Manipuri", CorrectAnswerIndex = 1 },
            new Question { Id = 6, Text = "Which is the largest lake in Kerala?", Option1 = "Vembanad Lake", Option2 = "Ashtamudi Lake", Option3 = "Pookode Lake", Option4 = "Sasthamkotta Lake", CorrectAnswerIndex = 0 },
            new Question { Id = 7, Text = "Which dam is the largest in Kerala?", Option1 = "Mullaperiyar Dam", Option2 = "Idukki Dam", Option3 = "Malampuzha Dam", Option4 = "Banasura Sagar Dam", CorrectAnswerIndex = 1 },
            new Question { Id = 8, Text = "Which is the state animal of Kerala?", Option1 = "Indian Elephant", Option2 = "Bengal Tiger", Option3 = "Nilgiri Tahr", Option4 = "Lion-tailed Macaque", CorrectAnswerIndex = 2 },
            new Question { Id = 9, Text = "What is the official language of Kerala?", Option1 = "Tamil", Option2 = "Sanskrit", Option3 = "Malayalam", Option4 = "English", CorrectAnswerIndex = 2 },
            new Question { Id = 10, Text = "Which is the highest peak in Kerala?", Option1 = "Agasthyakoodam", Option2 = "Anamudi", Option3 = "Meesapulimala", Option4 = "Banasura Hill", CorrectAnswerIndex = 1 },
            new Question { Id = 11, Text = "Which Kerala city is known as the 'Queen of the Arabian Sea'?", Option1 = "Kochi", Option2 = "Alappuzha", Option3 = "Kollam", Option4 = "Thiruvananthapuram", CorrectAnswerIndex = 0 },
            new Question { Id = 12, Text = "Which Kerala district has the longest coastline?", Option1 = "Kozhikode", Option2 = "Ernakulam", Option3 = "Alappuzha", Option4 = "Kannur", CorrectAnswerIndex = 2 },
            new Question { Id = 13, Text = "Who was the first Chief Minister of Kerala?", Option1 = "E. M. S. Namboodiripad", Option2 = "K. Karunakaran", Option3 = "V. S. Achuthanandan", Option4 = "A. K. Antony", CorrectAnswerIndex = 0 },
            new Question { Id = 14, Text = "Which river is also called the 'Dakshina Ganga' of Kerala?", Option1 = "Bharathapuzha", Option2 = "Pamba", Option3 = "Periyar", Option4 = "Chaliyar", CorrectAnswerIndex = 1 },
            new Question { Id = 15, Text = "Which is the first airport in India to be fully powered by solar energy?", Option1 = "Cochin International Airport", Option2 = "Trivandrum International Airport", Option3 = "Calicut International Airport", Option4 = "Kannur International Airport", CorrectAnswerIndex = 0 },
            new Question { Id = 16, Text = "Which wildlife sanctuary is famous for its tigers in Kerala?", Option1 = "Periyar Wildlife Sanctuary", Option2 = "Wayanad Wildlife Sanctuary", Option3 = "Silent Valley National Park", Option4 = "Chinnar Wildlife Sanctuary", CorrectAnswerIndex = 0 },
            new Question { Id = 17, Text = "Which Kerala district is known for backwaters and houseboats?", Option1 = "Kollam", Option2 = "Alappuzha", Option3 = "Kozhikode", Option4 = "Ernakulam", CorrectAnswerIndex = 1 },
            new Question { Id = 18, Text = "Which mountain pass connects Kerala with Tamil Nadu?", Option1 = "Palakkad Gap", Option2 = "Bodi Metu", Option3 = "Thamarassery Churam", Option4 = "Sengottai Pass", CorrectAnswerIndex = 0 },
            new Question { Id = 19, Text = "Which spice is Kerala famous for producing?", Option1 = "Cinnamon", Option2 = "Pepper", Option3 = "Cloves", Option4 = "Cardamom", CorrectAnswerIndex = 1 },
            new Question { Id = 20, Text = "Which Malayalam movie won India's first Best Film National Award?", Option1 = "Chemmeen", Option2 = "Piravi", Option3 = "Swaham", Option4 = "Elippathayam", CorrectAnswerIndex = 0 }
        };

        public static List<Question> GetRandomQuestions()
        {
            return Questions.OrderBy(q => Guid.NewGuid()).Take(10).ToList();
        }
    }
}
