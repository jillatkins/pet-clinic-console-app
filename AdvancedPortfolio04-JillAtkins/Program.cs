/*
Purpose: Advanced Portfolio #4 - Classes and Objects (Pet Clinic)

Input: - Pet name
       - Pet age
       - Pet weight
       - Pet type (dog or cat)
       - Confirmation of info
       - Service type
       - Other pet needing service (y or n)

Processes: - Prompt user for input
           - Validate user input
           - Calculate medication doses
           - Write info to CSV file

Output: - Prompts
        - Pet information
        - Medication information
 
Author: Jill Atkins
Last Modified: 2020.04.21
*/

using System;
using System.IO;

namespace AdvancedPortfolio04_JillAtkins
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARE
            string petName;
            int petAge, serviceType;
            double petWeight;
            char petType;
            bool additionalPet = true;

            // Create the StreamWriter/file, add on to the existing data (do not overwrite it)
            StreamWriter petMedication = new StreamWriter("../../../../pet-medication.csv", true);

            WelcomeMessage();

            do
            {
                bool correctInfo = false;

                // Create instance
                Pet myPet = new Pet();

                do
                {
                    // Get pet info from user
                    UserPrompts(myPet);

                    // Display entered pet info, confirm correctness
                    correctInfo = CorrectPetInfo(petName = myPet.GetPetName(), 
                                 petAge = myPet.GetPetAge(), petWeight = myPet.GetPetWeight(), 
                                 petType = myPet.GetPetType());

                } while (correctInfo == false);

                // Display the service options, get service type from user
                serviceType = ServiceOptions();

                // calculate the pet's medication & write info to file
                CalculateMedications(myPet, serviceType, petName, petAge, petWeight, petType, petMedication);

                // Ask user if additional pet needs service
                additionalPet = AdditionalPet();

            } while (additionalPet == true);

            petMedication.Close(); // Close the stream writer

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nGood-bye and thanks for coming to the Pet Clinic.\n");
            Console.ResetColor();

        } // end Main() method

        static void WelcomeMessage()
        {
            // Program's startup message
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("| CPSC1012 Pet Clinic                   |");
            Console.WriteLine("|---------------------------------------|");
        } // end WelcomeMessage() method

        static void UserPrompts(Pet myPet)
        {
            // This method gets the pet's information from the user and saves it in the Pet class
            
            string petName;
            int petAge;
            double petWeight;
            char petType;
            
            // Prompt for pet name
            petName = myPet.SetPetName();

            // Prompt for pet age
            petAge = myPet.SetPetAge();

            // Prompt for pet weight
            petWeight = myPet.SetPetWeight();

            // Prompt for pet type
            petType = myPet.SetPetType();

        } // end UserPrompts() method

        public static int GetUserInt()
        {
            // This method gets a valid integer from the user
            string userInput;
            int userInt = 0;
            bool valid = false;

            do
            {
                userInput = ChangeInputTextToRed();
                try
                {
                    userInt = int.Parse(userInput);

                    if (userInt > 0)
                    {
                        valid = true;
                    } // end if

                    else
                    {
                        valid = false;
                        throw new Exception();
                    } // end else

                } // end try

                catch
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                } // end catch

            } while (valid == false);

            return userInt;
        } // end GetUserInt() method

        public static double GetUserDouble()
        {
            // This method gets a valid double from the user
            string userInput;
            double userDouble = 0;

            userInput = ChangeInputTextToRed();
            try
            {
                userDouble = double.Parse(userInput);
            } // end try

            catch
            {
                // The error message is the method myPet.SetPetWeight()

            } // end catch

            return userDouble;
        } // end GetUserDouble() method

        public static char GetUserChar()
        {
            // This method gets a valid char (letter) input from the user

            // DECLARE
            string userInput;
            char userChar = ' ';
            bool validInput = false, validLetter = false;

            // Prompt the user for input until valid input is entered
            do
            {
                userInput = ChangeInputTextToRed();
                try
                {
                    userChar = char.Parse(userInput);
                    userChar = char.ToUpper(userChar); // force the letter to uppercase

                    // check if the letter entered is a Letter Char (not a number or other character)
                    validLetter = Char.IsLetter(userChar);

                    if (validLetter == true)
                    {
                        validInput = true;
                    } // end if

                    else
                    {
                        throw new Exception();
                    } // end else

                } // end try

                catch
                {
                    Console.WriteLine("Invalid input. Please enter a single letter.");
                } // end catch

            } while (validInput == false);

            return userChar;
        } // end GetUserChar() method

        static bool CorrectPetInfo(string petName, int petAge, double petWeight, char petType)
        {
            // This method displays the inputted pet info, and gets confirmation from the user
            
            bool correctInfo = false, validInput = false;
            char validInfo;
            string pet;

            // Convert the pet type to a string
            if (petType == 'C')
            {
                pet = "Cat";
            }

            else
            {
                pet = "Dog";
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Name: {petName}, Age: {petAge} years, Weight: {petWeight} lb, Type: {pet}");
            Console.ResetColor();
            do
            {
                Console.Write("Is the information above about your pet correct? Enter y or n: ");

                validInfo = GetUserChar();

                // If yes, continue with program
                if (validInfo == 'Y')
                {
                    validInput = true;
                    correctInfo = true;
                } // end if

                // If no, re-prompt the user for pet info
                else if (validInfo == 'N')
                {
                    validInput = true;
                    correctInfo = false;
                }

                else
                {
                    Console.WriteLine("Invalid input value. Enter Y or N.");
                } // end else

            } while (validInput == false);

            return correctInfo;
        }

        static int ServiceOptions()
        {
            // This method displays the Service Option menu and
            // returns the service option value inputted by the user
            
            int serviceOption;

            Console.WriteLine("\nService Options");
            Console.WriteLine("1.\tPain Killer");
            Console.WriteLine("2.\tSedative");
            Console.WriteLine("3.\tBoth Pain Killer and Sedative");
            Console.Write("Enter the service (1-3) required for your pet: ");

            serviceOption = GetUserInt();

            return serviceOption;

        } // end ServiceOptions() method

        static bool AdditionalPet()
        {
            // This method asks the user if they have another pet that requires service
            
            bool additionalPet = false, validInput = false;
            char userInput;

            do
            {
                Console.Write("\nDo you have another pet that requires service? Enter y or n: ");

                userInput = GetUserChar();

                // If Yes, re-run the prompts
                if (userInput == 'Y')
                {
                    validInput = true;
                    additionalPet = true;
                } // end if

                // If no, end the program
                else if (userInput == 'N')
                {
                    validInput = true;
                    additionalPet = false;
                } // end else-if

                else
                {
                    Console.WriteLine("Invalid input value. Enter Y or N.");
                } // end else

            } while (validInput == false);

            return additionalPet;
        } // end AdditionalPet() method

        static void WriteToFile(StreamWriter petMedication, string petName, double carprofenDose, double acepromazineDose)
        {
            // This method writes the pet's information to a CSV file
            
            string medication = " ";
            DateTime currentDateTime = DateTime.Now;

            // If the pet requires carprofen
            if (carprofenDose > 0 && acepromazineDose == 0)
            {
                medication = "carprofen";
                petMedication.WriteLine(currentDateTime.ToString("MM/dd/yyyy hh:mm tt") + "," + petName + "," +
                medication + "," + carprofenDose + "ml");
            } // end if

            // If the pet requires acepromazine
            else if (carprofenDose == 0 && acepromazineDose > 0)
            {
                medication = "acepromazine";
                petMedication.WriteLine(currentDateTime.ToString("MM/dd/yyyy hh:mm tt") + "," + petName + "," +
                medication + "," + acepromazineDose + "ml");
            } // end else-if

            // If the pet requires BOTH medications
            else if (carprofenDose > 0 && acepromazineDose > 0)
            {
                petMedication.WriteLine(currentDateTime.ToString("MM/dd/yyyy hh:mm tt") + "," + petName + "," +
                "carprofen" + "," + carprofenDose + "ml");

                petMedication.WriteLine(currentDateTime.ToString("MM/dd/yyyy hh:mm tt") + "," + petName + "," +
                "acepromazine" + "," + acepromazineDose + "ml");
            } // end else-if
            
        } // end WriteToFile method

        static void CalculateMedications(Pet myPet, int serviceType, string petName, int petAge, double petWeight, char petType, StreamWriter petMedication)
        {
            // This method calculates the medication dosages for each type of medication
            
            double acepromazineDose = 0, carprofenDose = 0;
            Console.WriteLine(); // whitespace
            Console.ForegroundColor = ConsoleColor.Cyan;

            // If the pet requires carprofen
            if (serviceType == 1)
            {
                carprofenDose = myPet.Carprofen();
                Console.WriteLine($"Your pet requires {carprofenDose}ml of Carprofen.");
            } // end if

            // If the pet requires acepromazine
            else if (serviceType == 2)
            {
                acepromazineDose = myPet.Acepromazine();
                Console.WriteLine($"Your pet requires {acepromazineDose}ml of Acepromazine.");
            } // end else-if

            // If the pet requires BOTH medications
            else if (serviceType == 3)
            {
                carprofenDose = myPet.Carprofen();
                acepromazineDose = myPet.Acepromazine();

                Console.WriteLine($"Your pet requires {carprofenDose}ml of Carprofen.");
                Console.WriteLine($"Your pet requires {acepromazineDose}ml of Acepromazine.");
            } // end else-if
            Console.ResetColor();

            // Write this info to the file
            WriteToFile(petMedication, petName, carprofenDose, acepromazineDose);

        } // end CalculateMedications() method

        public static string ChangeInputTextToRed()
        {
            // This method changes all user input text to red
            string userInput;

            Console.ForegroundColor = ConsoleColor.Red;
            userInput = Console.ReadLine();
            Console.ResetColor();

            return userInput;
        } // end ChangeInputTextToRed() method

    } // end class
} // end namespace
