namespace Interest_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // this is where you enter your principal for the loan
            Console.WriteLine("Please enter your total loan amount: ");
            double principal = Convert.ToDouble(Console.ReadLine());

            // this is where you enter your loan interest rate and it is converted from % to double
            Console.WriteLine("Please enter your interest rate: ");
            double rate = Convert.ToDouble(Console.ReadLine()) / 100;

            // this is where you enter the length of your total loan
            Console.WriteLine("Now please enter your loan term length in months: ");
            double time = Convert.ToDouble(Console.ReadLine());
            double years = time / 12;

            // this is where you enter how often your interest rate is compounded
            Console.WriteLine("How many times will this interest compound per year?: ");
            double compound = Convert.ToInt32(Console.ReadLine());

            // this calculates the total of your loan payment
            double totalInterest = principal * Math.Pow(1 + rate / compound, compound * years);

            // rounds out the code to having only 2 decimal points and shows total amount owed & total interest paid     
            double totalAmount = Math.Round(totalInterest, 2);
            double totalPaidInterest = Math.Round(totalAmount - principal, 2);
            Console.WriteLine($"Total Payment: {totalAmount}");
            Console.WriteLine($"Your total interest paid: {totalPaidInterest}");
        }
    }
}