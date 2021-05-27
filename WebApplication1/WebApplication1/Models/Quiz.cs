using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Models{
    public class Quiz{
        public int rightAnswersCount { get; set; } = 0;
        public int answersCount { get; set; } = 0;
        public List<string> Results { get; set; } = new List<string>();


        public int curRightAnswersCount { get; set; } = 0;
        public int curAnswersCount { get; set; } = 0;
        public List<string> curResults { get; set; } = new List<string>();

        public void ResetСurrentValue()
        {
            curRightAnswersCount = curAnswersCount = 0;
            curResults.Clear();
        }
        public void UpdateValue(int answerH, string expressionH, int answer)
        {
            curAnswersCount += 1; answersCount += 1;
            if (answerH == answer)
            {
                rightAnswersCount += 1;
                curRightAnswersCount += 1;
            }
            curResults.Add(expressionH + " = " + answer);
            Results.Add(expressionH + " = " + answer);
        }
    }
}
