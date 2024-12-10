using System.Linq.Expressions;
using System.Text;

namespace HomeWork7C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            //Task 1
            /*Console.WriteLine("Enter the first amount of money:");
            string firstSum = Console.ReadLine();
            int firstPart = int.Parse(firstSum.Split('.')[0]);
            int secondPart = int.Parse(firstSum.Split('.')[1]);
            Money firstCash = new Money(firstPart, secondPart);

            Console.WriteLine("\n1. + \n2. - \n3. / \n4. * \n5. ++ \n6. -- \n7. < \n8. > \n9. == \n10. != \n0. Exit");
            Console.WriteLine("\nYour choice: ");
            string[] operators = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "0" };
            int choice = int.Parse(Console.ReadLine());
            int newChoice = -1;

            foreach (var op in operators)
            {
                if (choice == int.Parse(op))
                {
                    newChoice = int.Parse(op);
                    break;
                }
            }

            if (newChoice == -1)
            {
                throw new ArgumentException("Невідомий оператор. Доступні оператори: +, -, /, *, ++, --, <, >, ==, !=.");
            }

            switch (choice)
            {
                case 1:
                    Money Addition = firstCash + createSecondCash();
                    Console.WriteLine(Addition);
                    break;
                case 2:
                    Money Subtraction = firstCash - createSecondCash();
                    Console.WriteLine(Subtraction);
                    break;
                case 3:
                    Console.WriteLine("Enter divisor: ");
                    int Divisor = int.Parse(Console.ReadLine());
                    if (Divisor == 0)
                    {
                        throw new DivideByZeroException("Ділення на 0 заборонено");
                    }
                    Money Divide = firstCash / Divisor;
                    Console.WriteLine(Divide);
                    break;
                case 4:
                    Console.WriteLine("Enter multiplier: ");
                    int Multiplier = int.Parse(Console.ReadLine());
                    Money Multiplication = firstCash * Multiplier;
                    Console.WriteLine(Multiplication);
                    break;
                case 5:
                    Money Increment = ++firstCash;
                    Console.WriteLine(Increment);
                    break;
                case 6:
                    Money Decrement = --firstCash;
                    Console.WriteLine(Decrement);
                    break;
                case 7:
                    bool isSmaller = firstCash < createSecondCash();
                    Console.WriteLine(isSmaller);
                    break;
                case 8:
                    bool isLarger = firstCash > createSecondCash();
                    Console.WriteLine(isLarger);
                    break;
                case 9:
                    bool isEqual = firstCash == createSecondCash();
                    Console.WriteLine((isEqual == true ? "Same amount of money" : "Different amounts of money"));
                    break;
                case 10:
                    bool isDifferent = firstCash != createSecondCash();
                    Console.WriteLine((isDifferent == true ? "Different amounts of money" : "Same amount of money"));
                    break;
                case 0:
                    break;
            }*/

            //Task 2
            //Console.WriteLine("Введіть логічний вираз (наприклад, 3>2 або 7<3):");
            //string input = Console.ReadLine();

            //try
            //{
            //    bool result = EvaluateLogicalExpression(input);
            //    Console.WriteLine($"Результат: {result}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Помилка: {ex.Message}");
            //}
        }

        public static Money createSecondCash()
        {
            Console.WriteLine("\nEnter the second amount of money:");
            string secondSum = Console.ReadLine();
            int firstPart = int.Parse(secondSum.Split('.')[0]);
            int secondPart = int.Parse(secondSum.Split('.')[1]);
            Money secondCash = new Money(firstPart, secondPart);
            return secondCash;
        }

        static bool EvaluateLogicalExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Введений вираз не може бути порожнім.");
            }

            string[] operators = { "<", ">", "<=", ">=", "==", "!=" };
            string operatorUsed = null;

            foreach (var op in operators)
            {
                if (expression.Contains(op))
                {
                    operatorUsed = op;
                    break;
                }
            }

            if (operatorUsed == null)
            {
                throw new ArgumentException("Невідомий оператор. Доступні оператори: <, >, <=, >=, ==, !=.");
            }

            string[] parts = expression.Split(new string[] { operatorUsed }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException("Неправильний формат виразу. Вираз повинен містити два числа і один оператор.");
            }

            if (!int.TryParse(parts[0].Trim(), out int leftOperand))
            {
                throw new ArgumentException("Ліва частина виразу не є коректним цілим числом.");
            }

            if (!int.TryParse(parts[1].Trim(), out int rightOperand))
            {
                throw new ArgumentException("Права частина виразу не є коректним цілим числом.");
            }

            switch (operatorUsed)
            {
                case "<": return leftOperand < rightOperand;
                case ">": return leftOperand > rightOperand;
                case "<=": return leftOperand <= rightOperand;
                case ">=": return leftOperand >= rightOperand;
                case "==": return leftOperand == rightOperand;
                case "!=": return leftOperand != rightOperand;
                default: throw new ArgumentException("Невідомий оператор.");
            }
        }
    }
}
