
long sum = 0;

do
{
    Console.Write("Enter a string with numbers and characters: ");
    string inputString = Console.ReadLine();

    CheckForMatch(inputString);

    Console.WriteLine();

    if (sum > 0)
    {
        continue;
    }

    PrintInvalidMessage();

} while (sum < 1);

PrintResult();




void CheckForMatch(string inputString)
{

    for (int i = 0; i < inputString.Length; i++)
    {
        char firstCheck = inputString[i];

        for (int j = i + 1; j < inputString.Length; j++)
        {

            int stringLengthAfterMatch = inputString.Length - j - 1;
            int lengthBetweenFirstCheckAndSecondCheck = j - i;
            char secondCheck = inputString[j];
            string stringBeforeMatch = inputString.Substring(0, i);
            string stringMatch = inputString.Substring(i, lengthBetweenFirstCheckAndSecondCheck + 1);
            string stringAfterMatch = inputString.Substring(j + 1, stringLengthAfterMatch);
            Console.ForegroundColor = ConsoleColor.Green;

            bool isNumber = char.IsDigit(inputString[j]);

            if (isNumber == false)
            {
                break;
            }

            if (secondCheck == firstCheck)
            {
                ChangeColourAndPrint(stringBeforeMatch, stringMatch, stringAfterMatch);
                long markedNumber = Convert.ToInt64(stringMatch);
                sum = sum + markedNumber;
                j = inputString.Length;
            }
        }
    }
}

void ChangeColourAndPrint(string stringBeforeMatch, string stringMatch, string stringAfterMatch)
{
    Console.Write(stringBeforeMatch);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(stringMatch);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(stringAfterMatch);
    Console.WriteLine();
}

void PrintInvalidMessage()
{
    Console.WriteLine($"Invalid entry.");

}

void PrintResult()
{
    Console.WriteLine();
    Console.WriteLine($"The total sum of all marked number is {sum}");

}