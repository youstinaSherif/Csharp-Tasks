using System;
using System.Collections.Generic;

public class Question
{
    public string QuestionBody { get; set; }
    public int Mark { get; set; }

    public Question(string questionBody, int mark)
    {
        QuestionBody = questionBody;
        Mark = mark;
    }

    public override string ToString()
    {
        return $"{QuestionBody} ({Mark} mark)";
    }
}

public class Answer
{
    public int Num { get; set; }
    public string ChoiceText { get; set; }

    public Answer(int num, string choiceText)
    {
        Num = num;
        ChoiceText = choiceText;
    }
    
    public override string ToString()
    {
        return $"{Num} - {ChoiceText}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Question> questions = new List<Question>
        {
            new Question("OOP stands for ...?", 10),
            new Question("What is polymorphism?", 15)
        };

        Console.WriteLine("Questions:");
        foreach (var question in questions)
        {
            Console.WriteLine(question);
        }

        List<Answer> answers1 = new List<Answer>
        {
            new Answer(1, "Object Oriented Programming"),
            new Answer(2, "Object Oriented Procedure")
        };

        List<Answer> answers2 = new List<Answer>
        {
            new Answer(1, "Ability to take multiple forms"),
            new Answer(2, "Inheritance")
        };

        Dictionary<Question, List<Answer>> exam = new Dictionary<Question, List<Answer>>
        {
            { questions[0], answers1 },
            { questions[1], answers2 }
        };

        Console.WriteLine("\nExam:");
        foreach (var entry in exam)
        {
            Console.WriteLine(entry.Key); 
            foreach (var answer in entry.Value) 
            {
                Console.WriteLine("  " + answer);
            }
        }
    }
}
