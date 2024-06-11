// reference site for math https://www.investor.gov/financial-tools-calculators/calculators/compound-interest-calculator

namespace Interest_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // storing of variables
            double principal = 0.00;
            double rate = 0.00;
            int timeInMonths = 0;
            double timeInYears = 0;
            int compound = 0;
            double loanTotal = 0.00;
            double interestTotal = 0.00;
            string input = "";

            // calling of methods to execute code
            GetLoanAmount(out principal);
            GetInterestRate(out rate);
            GetLoanLength(out timeInMonths, out timeInYears);
            GetLoanCompoundAmount(out compound);

            // getting final totals 
            loanTotal = Math.Round(GetLoanTotal(principal, rate, compound, timeInYears), 2);
            interestTotal = Math.Round(loanTotal - principal, 2);

            // formats final outputs to be more readable by user
            string formattedLoanTotal = loanTotal.ToString("0,000.00");
            string formattedInterestTotal = interestTotal.ToString("0,000.00");

            // calling last method to display formated methods to the user
            ShowAllLoanInformation(formattedLoanTotal, formattedInterestTotal);

        }
        // method to handle all user input
        static double GetUserInput(string message, bool isPercentage = false, bool isDollar = false)
        {
            double input;
            while (true)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();
                if (isDollar)
                {
                    userInput = userInput.TrimStart('$');
                }
                if (isPercentage)
                {
                    userInput = userInput.TrimEnd('%');
                }
                if (!double.TryParse(userInput, out input))
                {
                    Console.WriteLine("Please enter a number...");
                }
                else
                {
                    return input;
                }
            }
        }

        //greets user and gets initial loan amount
        static void GetLoanAmount(out double principal)
        {
            Console.WriteLine("COMPOUND INTEREST CALCULATOR");
            principal = GetUserInput("Please enter your total loan amount to begin: ", false, true);
        }

        //gets interest rate for users loan
        static void GetInterestRate(out double rate)
        {
            rate = GetUserInput("Please enter your loans interest rate: ", true, false);
            rate = rate / 100;
        }

        //gets loan length and converts it to years
        static void GetLoanLength(out int timeInMonths, out double timeInYears)
        {
            timeInMonths = Convert.ToInt32(GetUserInput("Please enter the length for your loan in months: "));
            timeInYears = timeInMonths / 12;
        }
        //gets the amount of times the interest will compound per year
        static void GetLoanCompoundAmount(out int compound)
        {
            compound = Convert.ToInt32(GetUserInput("How many times will the interest rate compound per year?: "));
        }

        //calculates loans total paid after terms are completed
        static double GetLoanTotal(double principal, double rate, int compound, double timeInYears)
        {
            return principal * Math.Pow((1 + (rate / compound)), (compound * timeInYears));
        }

        static void ShowAllLoanInformation(string loanTotal, string totalInterest)
        {
            Console.WriteLine($"\nYour total loan amount is ${loanTotal}");
            Console.WriteLine($"Your total interest paid is ${totalInterest}");
        }
    }
}