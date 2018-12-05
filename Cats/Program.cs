using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    class Program
    {
        // *********************************************************
        //
        // Pet Cat Info
        // Taylor Mineo 
        // 12/05/18 - Programming
        //
        // *********************************************************
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// instantiate and initialize G the Cat
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>PetCat object</returns>
        static PetCat InitializePetCatG(string name)
        {
            PetCat G = new PetCat(name);

            G.Weight = 5.5;
            G.CatWasAdopted = true;
            G.CurrentMood = PetCat.Mood.playful;
            G.CatBreed = "Tabby";


            return G;
        }

        /// <summary>
        /// instantiate and initialize Rue the Cat
        /// </summary>
        /// <returns>PetCat object</returns>
        static PetCat InitializePetCatRue()
        {
            PetCat rue = new PetCat();

            rue.Name = "Rue";
            rue.Weight = 2.2;
            rue.CatWasAdopted = true;
            rue.CurrentMood = PetCat.Mood.tired;
            rue.CatBreed = "Torti";

            return rue;
        }

        /// <summary>
        /// display all information about a Pet Cat
        /// </summary>
        /// <param name="petcat">PetCat object</param>
        static void DisplayPetCatInfo(List<PetCat> petCats)
        {

            string userPetCatChoice;


            DisplayHeader("Display Pet Cat Info");

            //
            // get cat name from user
            //

            foreach (PetCat petCat in petCats)
            {
                Console.WriteLine(petCat.Name);

            }
            Console.WriteLine();
            Console.Write("Enter Name:");
            userPetCatChoice = Console.ReadLine();

            //
            // display Pet Cat info
            //

            bool petCatFound = false;
            foreach (PetCat petCat in petCats)
            {
                if (petCat.Name == userPetCatChoice)
                {
                    Console.WriteLine(petCat.Name);
                    Console.WriteLine(petCat.Weight);
                    Console.WriteLine(petCat.CurrentMood);
                    Console.WriteLine(petCat.CatWasAdopted);
                    Console.WriteLine(petCat.CatBreed);
                    petCatFound = true;
                    break;
                }

            }

            if (!petCatFound)
            {
                Console.WriteLine($"Unable to locate the pet cat named {userPetCatChoice}.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayDeletePetCat(List<PetCat> petCats)
        {

            string userPetCatChoice;


            DisplayHeader("Delete Pet Cat Info");

            //
            // get pet cat name from user
            //

            foreach (PetCat petCat in petCats)
            {
                Console.WriteLine(petCat.Name);

            }
            Console.WriteLine();
            Console.Write("Enter Name:");
            userPetCatChoice = Console.ReadLine();

            //
            // delete pet cat
            //

            bool petCatFound = false;
            foreach (PetCat petCat in petCats)
            {
                if (petCat.Name == userPetCatChoice)
                {
                    petCats.Remove(petCat);
                    petCatFound = true;
                    break;
                }

            }

            if (!petCatFound)
            {
                Console.WriteLine($"Unable to locate the cat named {userPetCatChoice}.");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all cats
        /// </summary>
        /// <param name="petCats">list of Cats</param>
        static void DisplayAllPetCats(List<PetCat> petCats)
        {
            DisplayHeader("List of Pet Cats");

            foreach (PetCat petCat in petCats)
            {
                Console.WriteLine(petCat.CurrentEmotionInfo());
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a screen to get a new pet cat from the user
        /// </summary>
        /// <param name="petCats">list of Cats</param>
        static void DisplayGetUserPetCat(List<PetCat> petCats)
        {
            //
            // create (instantiate) a new PetCat object
            // 
            PetCat userPetCat = new PetCat();

            DisplayHeader("Add a Cat");

            //
            // get the PetCat object's property values from user
            //
            Console.Write("Enter Name:");
            userPetCat.Name = Console.ReadLine();
            Console.Write("Enter Weight:");
            double.TryParse(Console.ReadLine(), out double weight);
            userPetCat.Weight = weight;
            Console.Write("Cat Was Adopted:");
            if (Console.ReadLine().ToUpper() == "YES")
            {
                userPetCat.CatWasAdopted = true;
            }
            else
            {
                userPetCat.CatWasAdopted = false;
            }
            Console.Write("Enter Emotional State:");
            Enum.TryParse(Console.ReadLine(), out PetCat.Mood emotionalState);
            userPetCat.CurrentMood = emotionalState;
            Console.Write("Enter Cat Breed:");
            userPetCat.CatBreed = Console.ReadLine();


            //
            // add PetCat object to list
            //
            petCats.Add(userPetCat);


            DisplayContinuePrompt();
        }

        /// <summary>
        /// display menu and process user menu choices
        /// </summary>
        static void DisplayMenu()
        {
            //
            // instantiate cats
            //
            PetCat rue;
            rue = InitializePetCatRue();
            PetCat g;
            g = InitializePetCatG("G");

            //
            // add cats to list
            //
            List<PetCat> petCats = new List<PetCat>();
            petCats.Add(rue);
            petCats.Add(g);

            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Cats");
                Console.WriteLine("\tB) Add a Cat");
                Console.WriteLine("\tC) Delete a Cat");
                Console.WriteLine("\tD) Display Cat Info");
                Console.WriteLine("\tF) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllPetCats(petCats);
                        break;

                    case "B":
                    case "b":
                        DisplayGetUserPetCat(petCats);
                        break;

                    case "C":
                    case "c":
                        DisplayDeletePetCat(petCats);
                        break;

                    case "D":
                    case "d":
                        DisplayPetCatInfo(petCats);
                        break;

                    case "E":
                    case "e":

                        break;

                    case "F":
                    case "f":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }

        #region HELPER METHODS

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Pet Cat Info");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThanks for using Pet Cat Info.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }

        #endregion


    }
}
