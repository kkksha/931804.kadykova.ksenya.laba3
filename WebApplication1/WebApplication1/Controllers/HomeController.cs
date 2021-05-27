using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers{
    public class HomeController : Controller{
        static Quiz quiz = new Quiz();
        int answer;
        static Dictionary<int, string> operations = new Dictionary<int, string>
        {
            {0, "+"},
            {1, "-"},
        };
        private (int, string) RandomizeValues(){
            Random rand = new Random();
            int first = rand.Next(0, 25);
            int second = rand.Next(0, 25);
            var operation = operations[rand.Next(0, 2)];

            switch (operation){
                case "+":
                    answer = first + second; break;
                case "-":
                    answer = first - second; break; };

            string value = first + " " + operation + " " + second;
            return (answer, value);}

        private void UpdateValue() { }
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger){ _logger = logger; }
        public IActionResult Index(){ return View(); }
        public IActionResult Quiz() {
            quiz.ResetСurrentValue();
            (ViewBag.Answer, ViewBag.Value) = RandomizeValues();
            return View(); }
        public IActionResult QuizRes()
        {
            ViewBag.RightAnswersCount = quiz.rightAnswersCount;
            ViewBag.AnswersCount = quiz.answersCount;
            ViewBag.Results = quiz.Results;
            return View();
        }
        [HttpPost]
        public IActionResult QuizNext(int answerH, string expressionH, int answer)
        {
            quiz.UpdateValue(answerH, expressionH, answer);
            (ViewBag.Answer, ViewBag.Value) = RandomizeValues();         
            return View("Quiz");
        }

        public IActionResult QuizFinish(int answerH, string expressionH, int answer)
        {
            quiz.UpdateValue(answerH, expressionH, answer);
            ViewBag.RightAnswersCount = quiz.curRightAnswersCount;
            ViewBag.AnswersCount = quiz.curAnswersCount;
            ViewBag.Results = quiz.curResults;
            return View("QuizRes");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
