using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorina
{
    internal class QuizHistory
    {
        public double Score = 0;
        public string Name { get; set; }

        List<string> questions = new List<string>()
        {
            "Когда произошла Отечественная война?",
            "Кто такой Наполеон?",
            "Где был изобретён первый автомобиль?",
            "Когда произошла Великая Отечественная война?"
        };

        List<string[]> variantsQuestions = new List<string[]>()
        {
            new string[4] { "1941", "1863", "1812", "993" },
            new string[4] { "Император", "Полководец", "Крестьянин", "Не знаю" },
            new string[4] { "Англия", "Америка", "Российская Империя", "Китай" },
            new string[4] { "1945", "1823", "1812", "1941" }
        };

        List<bool[]> rightAnswers = new List<bool[]>()
        {
            new bool[4] { false,false,true,false },
            new bool[4] { true,true,false,false },
            new bool[4] { false,true,false,true },
            new bool[4] { false,false,false,true }
        };

        List<int> ScoreAnswers = new List<int>()
        {
            12,12,12,12
        };

        public QuizHistory(string name)
        {
            Name = name;
        }


        public double StartQuiz()
        {
            int index = 0;
            foreach (string quest in questions)
            {

                Console.WriteLine(quest);
                int count = 1;
                foreach (string variant in variantsQuestions[index])
                {
                    Console.WriteLine(count + "." + variant);
                    count++;
                }
                bool scoreAdding = false;
                Console.WriteLine("Введите правильный ответ цифрой варианта. Если ответов несколько, то через запятую.");
                string answer = Console.ReadLine();
                if (answer.Contains(','))
                {
                    string[] answers = answer.Split(",");

                    foreach (string ans in answers)
                    {
                        if (rightAnswers[index][Int32.Parse(ans) - 1] == true)
                        {
                            scoreAdding = true;
                        }
                        else
                        {
                            scoreAdding = false;
                            break;
                        }
                    }
                    if (scoreAdding)
                    {
                        Score += ScoreAnswers[index];
                    }

                }
                else
                {
                    if (rightAnswers[index][Int32.Parse(answer) - 1] == true)
                    {
                        scoreAdding = true;
                    }
                    if (scoreAdding)
                    {
                        Score += ScoreAnswers[index];
                    }
                }
                index++;
            }
            return Score;
        }
    }
}