using System;
using System.Globalization;

namespace BooleanConsoleApp
{
    class BooleanQuiz
    {
        static void Main()

        //User takes the quiz 5 times and gets a point for each right answer.
        {
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                int point = takeBoolQuiz();
                score += point;
                Console.WriteLine($"Your score is:{score}! \n");
            }
        }

        private static int takeBoolQuiz()
        {
            int point = 0;
            Random boolChoice = new Random();

            /*The choice for each part of the bool expression, bool Values, operator and the presence or absence of Not
             around the expression.*/
            string[] boolValues = { "true", "false", "1", "0" };
            string[] operatorValues = { "==", "!=", "&&", "||" };
            string[] notValues = { "Not", "Without Not" };

            //Assigning a random number from the each list to each part of the bool expression.
            int randomFirstValue = boolChoice.Next(boolValues.Length);
            int randomOperator = boolChoice.Next(operatorValues.Length);
            int randomSecondValue = boolChoice.Next(boolValues.Length);
            int randomNot = boolChoice.Next(notValues.Length);

            //Extracting the string of the numeric list
            string firstValue = boolValues[randomFirstValue];
            string operatorValue = operatorValues[randomOperator];
            string secondValue = boolValues[randomSecondValue];
            string notValue = notValues[randomNot];

            //Creates the string inital bool string to present to the user.
            string boolExpression = ($"{firstValue} {operatorValue} {secondValue}");

            //Checks if the Not value has been selected and if it has, the bool expresion will be enveloped in a not expression.
            if (notValue == "Not")
            {
                boolExpression = ($"Not ({boolExpression})");
            }

            //Calls the method to convert the numeric values of 0 and 1 to the bool values of false and true.
            string switchNumericFirstValue = evaluteNumeric(firstValue);
            string switchNumericSecondValue = evaluteNumeric(secondValue);

            //Call the method to convert the string values to bool values
            bool boolFirstValue = switchToBool(switchNumericFirstValue);
            bool boolSecondValue = switchToBool(switchNumericSecondValue);

            //Calls the method to evalute the initial bool expression.
            bool computerEvaluation = boolEvalution(operatorValue, boolFirstValue, boolSecondValue);

            //Flips the bool value if the Not value is present.
            if (notValue == "Not")
            {
                if (computerEvaluation == true)
                {
                    computerEvaluation = false;
                }
                else if (computerEvaluation == false)
                {
                    computerEvaluation = true;
                }
            }

            //Writes the bool expression to the console and asks the user for input
            Console.WriteLine("Will this boolean expression evaluate to True or False?");
            Console.WriteLine($"{boolExpression}");
            Console.WriteLine("Submit your answer");

            //takes input from the user
            string userAnswer = Console.ReadLine();

            //The input is first dropped to lower case then converted to title case.
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            userAnswer = textInfo.ToLower(userAnswer);
            userAnswer = textInfo.ToTitleCase(userAnswer);

            /*Takes the users answer and compares it to the string value of the evaluted expression. If the answer is correct,
            the user get a point. */
            if (userAnswer == Convert.ToString(computerEvaluation))
            {
                Console.WriteLine("You are correct! Great job.");
                Console.WriteLine($"Computer evaluation: {computerEvaluation}");
                point += 1;
                return point;
            }
            else
            {
                Console.WriteLine("Sorry that is not correct. Try again.");
                Console.WriteLine($"Computer evaluation: {computerEvaluation}");
                return point;
            }

        }

        //Evalutes the initial bool expression.
        private static bool boolEvalution(string operatorValue, bool boolFirstValue, bool boolSecondValue)
            {
                switch (operatorValue)
                {
                    case "==":
                        return boolFirstValue == boolSecondValue;
                    case "!=":
                        return boolFirstValue != boolSecondValue;
                    case "&&":
                        return boolFirstValue && boolSecondValue;
                    default:
                        return boolFirstValue || boolSecondValue;
                }
            }
            //Coverts the the bool to a string value.
            public static bool switchToBool(string stringToBool) => Convert.ToBoolean(stringToBool);

            //Convert the numeric values of 0 and 1 to the bool values of false and true.
            public static string evaluteNumeric(string numberToBool)
            {
                if (numberToBool == "1")
                {
                    numberToBool = "true";
                }
                else if (numberToBool == "0")
                {
                    numberToBool = "false";
                }
                return numberToBool;
            }
    }
}
