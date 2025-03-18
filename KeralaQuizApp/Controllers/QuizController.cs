using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KeralaQuizApp.Models;
using KeralaQuizApp.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace KeralaQuizApp.Controllers
{
    public class QuizController : Controller
    {
        private const string SessionKeyQuestions = "QuizQuestions";
        private const string SessionKeyAnswers = "UserAnswers";
        private const string SessionKeyIndex = "CurrentQuestionIndex";

        public IActionResult Start()
        {
            var questions = QuestionPool.GetRandomQuestions();
            HttpContext.Session.SetObject(SessionKeyQuestions, questions);
            HttpContext.Session.SetObject(SessionKeyAnswers, new Dictionary<int, int?>()); // Store answers per index
            HttpContext.Session.SetInt32(SessionKeyIndex, 0);

            return RedirectToAction("Question");
        }

        public IActionResult Question()
        {
            var questions = HttpContext.Session.GetObject<List<Question>>(SessionKeyQuestions);
            int currentIndex = HttpContext.Session.GetInt32(SessionKeyIndex) ?? 0;
            var answers = HttpContext.Session.GetObject<Dictionary<int, int?>>(SessionKeyAnswers);

            if (questions == null || currentIndex >= questions.Count)
                return RedirectToAction("Result");

            ViewBag.CurrentIndex = currentIndex;
            ViewBag.TotalQuestions = questions.Count;

            // Retrieve selected answer from session using currentIndex
            ViewBag.SelectedAnswer = answers.ContainsKey(currentIndex) ? answers[currentIndex] : null;

            return View(questions[currentIndex]);
        }

        [HttpPost]
        public IActionResult Question(int selectedAnswer, string action)
        {
            var questions = HttpContext.Session.GetObject<List<Question>>(SessionKeyQuestions);
            int currentIndex = HttpContext.Session.GetInt32(SessionKeyIndex) ?? 0;
            var answers = HttpContext.Session.GetObject<Dictionary<int, int?>>(SessionKeyAnswers);

            if (questions == null || answers == null)
                return RedirectToAction("Start");

            // Store answer using question index
            answers[currentIndex] = selectedAnswer;
            HttpContext.Session.SetObject(SessionKeyAnswers, answers);

            if (action == "Submit")
            {
                return RedirectToAction("Result");
            }

            // Handle navigation
            if (action == "Next" && currentIndex < questions.Count - 1)
            {
                HttpContext.Session.SetInt32(SessionKeyIndex, currentIndex + 1);
            }
            else if (action == "Previous" && currentIndex > 0)
            {
                HttpContext.Session.SetInt32(SessionKeyIndex, currentIndex - 1);
            }

            return RedirectToAction("Question");
        }

        public IActionResult Result()
        {
            var questions = HttpContext.Session.GetObject<List<Question>>(SessionKeyQuestions);
            var answers = HttpContext.Session.GetObject<Dictionary<int, int?>>(SessionKeyAnswers);

            if (questions == null || answers == null)
                return RedirectToAction("Start");

            // Calculate the score
            int score = questions
                .Select((q, index) => answers.ContainsKey(index) && answers[index] == q.CorrectAnswerIndex)
                .Count(isCorrect => isCorrect);

            ViewBag.Score = score;
            ViewBag.Message = score >= 8 ? "Great! You passed the test!" : "Unfortunately, you did not pass. Please try again!";

            return View();
        }
    }
}
