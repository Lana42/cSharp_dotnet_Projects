using System;

using System.Windows.Forms;

namespace WindowsFormsBoolTest
{
        public partial class BoolTest : Form
    {
         public BoolTest()
        {
            InitializeComponent();
        }
                    
        public bool computerEvaluation;
        public int totalTimesPlay = 0;
        
        private void makeBoolExpression(object sender, EventArgs e)
        {
            //Call the method to make a bool expression.
            computerEvaluation = makeABool();
            //Calculates and displays the number of times played.
            totalTimesPlay += 1;
            totalAnswered.Text = Convert.ToString(totalTimesPlay);
        }
        public bool makeABool()
        {
            //Resets the form.
            trueButton.Checked = false;
            falseButton.Checked = false;
            computerAnswer.Text = "";
            answerAssesment.Text = "";

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
            
            //Prints the bool expression
             boolExpressionPrint.Text = boolExpression;

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

            return computerEvaluation;
        }
        public int point = 0;
        public void checkUserAnswer(bool computerEvaluation)

        {
            
            string userAnswer = "";
            playAgain.Text = "Play Again?";

            //Gets the users answer
            if (trueButton.Checked)
            {
                userAnswer = "True";
            }
            else if (falseButton.Checked)
            {
                userAnswer = "False";
            }

            //Prints the computer evaluated answer to the screen
            computerAnswer.Text = Convert.ToString(computerEvaluation);

            /*Takes the users answer and compares it to the string value of the evaluted expression. If the answer is correct,
            the user get a point. */
            if (userAnswer == Convert.ToString(computerEvaluation))
            {
                answerAssesment.Text = "Correct! Great Job!";
                point += 1;
                currentScore.Text = Convert.ToString(point);
            }
            else
            {
                answerAssesment.Text = "Sorry, Try again.";
                currentScore.Text = Convert.ToString(point);
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

        //Call the method to check the users answer when they have clicked.
        public void checkAnswer(object sender, EventArgs e)
        {
            checkUserAnswer(computerEvaluation);
        }

     }
}



