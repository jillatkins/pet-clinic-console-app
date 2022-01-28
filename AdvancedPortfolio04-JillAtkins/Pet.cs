using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedPortfolio04_JillAtkins
{
    class Pet
    {
        // Instance fields
        private string Name = "Spot";
        private int Age = 1;
        private double Weight = 5;
        private char Type = 'D';

        // Methods

        // No-argument constructor (default)
        public Pet()
        {

        } // end default constructor

        public Pet(string name, int age, double weight, char type)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.Type = type;
        } // end constructor method

        public string GetPetName()
        {
            // Returns the pet's name
            return this.Name;
        } // end GetPetName() method

        public string SetPetName()
        {
            // This method changes the pet's name
            bool validInput = false;
            string newPetName;

            do
            {
                Console.Write("Enter the name of your pet: ");
                newPetName = Program.ChangeInputTextToRed();
                
                // Check if entered pet name is empty
                if (String.IsNullOrEmpty(newPetName) || newPetName == " ")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid input value. A pet name is required and " +
                                      "must contain at least one character.");
                    Console.ResetColor();
                } // end if

                else
                {
                    validInput = true;
                    this.Name = newPetName;
                } // end else

            } while (validInput == false);

            return this.Name;
            
        } // end SetPetName() mutator method

        public int GetPetAge()
        {
            // Returns the pet's age
            return this.Age;
        } // end GetPetAge() method

        public int SetPetAge()
        {
            // This method changes the pet's age
            
            string userInput;
            bool validInput = false;
            int petAge;

            do
            {
                Console.Write("Enter the age of your pet: ");
                userInput = Program.ChangeInputTextToRed();

                try
                {
                    petAge = int.Parse(userInput);

                    if (petAge > 0)
                    {
                        validInput = true;
                        this.Age = petAge;
                    } // end if

                    else
                    {
                        validInput = false;
                        throw new Exception();
                    } // end else

                } // end try

                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid input value. Age must be at least 1 year old.");
                    Console.ResetColor();
                } // end catch

            } while (validInput == false);

            return this.Age;
        } // end SetPetAge() method

       public double GetPetWeight()
        {
            // Returns the pet's weight
            return this.Weight;
        } // end GetPetWeight() method

        public double SetPetWeight()
        {
            // This method changes the pet's weight
            
            bool validInput = false;
            double petWeight;

            // Check if pet weight is equal to or greater than 5
            do
            {
                Console.Write("Enter the weight (in pounds) of your pet: ");

                petWeight = Program.GetUserDouble();

                if (petWeight >= 5)
                {
                    this.Weight = petWeight;
                    validInput = true;
                } // end if

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid input value. Weight must be at least 5 pounds.");
                    Console.ResetColor();
                } // end else

            } while (validInput == false);

            return this.Weight;
        } // end SetPetWeight() mutator method

        public char GetPetType()
        {
            // This method returns the pet's type
            return this.Type;
        } // end GetPetType() method

        public char SetPetType()
        {
            // This method changes the pet's type
            
            bool validInput = false;
            char petType;

            // Prompt & Check if pet type is equal to D or C
            do
            {
                Console.Write("Enter D for Dog, C for cat: ");

                petType = Program.GetUserChar();

                if (petType == 'D' || petType == 'C')
                {
                    this.Type = petType;
                    validInput = true;
                } // end if

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid input value. Pet type must be D or C.");
                    Console.ResetColor();
                } // end else

            } while (validInput == false);

            return this.Type;
        } // end SetPetType() mutator method

        public double Acepromazine()
        {
           // This method calculates the dosage for Acepromazine
            
            double acepromazineDosage = 0;
            double petWeightKG;

            // Convert petweight from LBS to KG
            petWeightKG = this.Weight / 2.205;

            if (this.Type == 'D')
            {
                acepromazineDosage = petWeightKG * (0.03/10);
            } // end if

            else if (this.Type == 'C')
            {
                acepromazineDosage = petWeightKG * (0.002 / 10);
            } // end else-if

            acepromazineDosage = Math.Round(acepromazineDosage, 3);

            return acepromazineDosage;
        } // end Acepromazine() method

        public double Carprofen()
        {
            // This method calculates the dosage for Carprofen

            double carprofenDosage = 0;
            double petWeightKG;

            // Convert petweight from LBS to KG
            petWeightKG = this.Weight / 2.205;

            if (this.Type == 'D')
            {
                carprofenDosage = petWeightKG * (0.5 / 12);
            } // end if

            else if (this.Type == 'C')
            {
                carprofenDosage = petWeightKG * (0.25 / 12);
            } // end else-if

            carprofenDosage = Math.Round(carprofenDosage, 3);

            return carprofenDosage;
        } // end Acepromazine() method

    } // end class
} // end namespace
