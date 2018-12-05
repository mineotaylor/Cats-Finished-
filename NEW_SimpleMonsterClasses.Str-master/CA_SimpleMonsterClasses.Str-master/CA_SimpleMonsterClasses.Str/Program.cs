using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreedsOfCat
{
    class Program
    {
        // *********************************************************
        //
        // Cat Breeds
        //
        // *********************************************************
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// instantiate and initialize G the cat
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>SeaMonster object</returns>
        static CatBreed InitializeSeaMonsterSid(string name)
        {
            CatBreed sid = new CatBreed(name);

            sid.Weight = 2.5;
            sid.Adopted = true;
            sid.CurrentMood = CatBreed.Mood.sad;
            sid.FavoriteTreat = "Turkey";


            return sid;
        }

        /// <summary>
        /// instantiate and initialize suzy the sea monster
        /// </summary>
        /// <returns>SeaMonster object</returns>
        static CatBreed InitializeSeaMonsterSuzy()
        {
            CatBreed suzy = new CatBreed();

            suzy.Name = "Suzy";
            suzy.Weight = 1.2;
            suzy.Adopted = true;
            suzy.CurrentMood = CatBreed.Mood.happy;
            suzy.FavoriteTreat = "Bikini Bottom";

            return suzy;
        }

        /// <summary>
        /// display all information about a sea monster
        /// </summary>
        /// <param name="seaMonster">SeaMonster object</param>
        static void DisplaySeaMonsterInfo(List<CatBreed> seaMonsters)
        {

            string userSeaMonsterChoice;


            DisplayHeader("Display Sea Monster Info");

            //
            // get sea monster name from user
            //

            foreach (CatBreed seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.Name);

            }
            Console.WriteLine();
            Console.Write("Enter Name:");
            userSeaMonsterChoice = Console.ReadLine();

            //
            // display sea monster info
            //

            bool seaMonsterFound = false;
            foreach (CatBreed seaMonster in seaMonsters)
            {
                if (seaMonster.Name == userSeaMonsterChoice)
                {
                    Console.WriteLine(seaMonster.Name);
                    Console.WriteLine(seaMonster.Weight);
                    Console.WriteLine(seaMonster.CurrentMood);
                    Console.WriteLine(seaMonster.Adopted);
                    Console.WriteLine(seaMonster.FavoriteTreat);
                    seaMonsterFound = true;
                    break;
                }
                
            }

            if (!seaMonsterFound)
            {
                Console.WriteLine($"Unable to locate the sea monster named {userSeaMonsterChoice}.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayDeleteSeaMonster(List<CatBreed> seaMonsters)
        {

            string userSeaMonsterChoice;


            DisplayHeader("Delete Sea Monster Info");

            //
            // get sea monster name from user
            //

            foreach (CatBreed seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.Name);

            }
            Console.WriteLine();
            Console.Write("Enter Name:");
            userSeaMonsterChoice = Console.ReadLine();

            //
            // delete sea monster
            //

            bool seaMonsterFound = false;
            foreach (CatBreed seaMonster in seaMonsters)
            {
                if (seaMonster.Name == userSeaMonsterChoice)
                {
                    seaMonsters.Remove(seaMonster);
                    seaMonsterFound = true;
                    break;
                }

            }

            if (!seaMonsterFound)
            {
                Console.WriteLine($"Unable to locate the sea monster named {userSeaMonsterChoice}.");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all sea monsters
        /// </summary>
        /// <param name="seaMonsters">list of SeaMonster</param>
        static void DisplayAllSeaMonsters(List<CatBreed> seaMonsters)
        {
            DisplayHeader("List of Sea Monsters");

            foreach (CatBreed seaMonster in seaMonsters)
            {
                Console.WriteLine(seaMonster.CurrentEmotionInfo());
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a screen to get a new sea monster from the user
        /// </summary>
        /// <param name="seaMonsters">list of SeaMonster</param>
        static void DisplayGetUserSeaMonster(List<CatBreed> seaMonsters)
        {
            //
            // create (instantiate) a new SeaMonster object
            // 
            CatBreed userSeaMonster = new CatBreed();

            DisplayHeader("Add a Sea Monster");

            //
            // get the SeaMonster object's property values from user
            //
            Console.Write("Enter Name:");
            userSeaMonster.Name = Console.ReadLine();
            Console.Write("Enter Weight:");
            double.TryParse(Console.ReadLine(), out double weight);
            userSeaMonster.Weight = weight;
            Console.Write("Can Use Freshwater:");
            if (Console.ReadLine().ToUpper() == "YES")
            {
                userSeaMonster.Adopted = true;
            }
            else
            {
                userSeaMonster.Adopted = false; 
            }
            Console.Write("Enter Emotional State:");
            Enum.TryParse(Console.ReadLine(), out CatBreed.Mood emotionalState);
            userSeaMonster.CurrentMood = emotionalState;
            Console.Write("Enter Home Sea:");
            userSeaMonster.FavoriteTreat = Console.ReadLine();


            //
            // add SeaMonster object to list
            //
            seaMonsters.Add(userSeaMonster);


            DisplayContinuePrompt();
        }

        /// <summary>
        /// display menu and process user menu choices
        /// </summary>
        static void DisplayMenu()
        {
            //
            // instantiate sea monsters
            //
            CatBreed suzy;
            suzy = InitializeSeaMonsterSuzy();
            CatBreed sid;
            sid = InitializeSeaMonsterSid("Sid");

            //
            // add sea monsters to list
            //
            List<CatBreed> seaMonsters = new List<CatBreed>();
            seaMonsters.Add(suzy);
            seaMonsters.Add(sid);

            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Sea Monsters");
                Console.WriteLine("\tB) Add a Sea Monster");
                Console.WriteLine("\tC) Delete a Sea Monster");
                Console.WriteLine("\tD) Display Sea Monster Info");
                Console.WriteLine("\tF) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllSeaMonsters(seaMonsters);
                        break;

                    case "B":
                    case "b":
                        DisplayGetUserSeaMonster(seaMonsters);
                        break;

                    case "C":
                    case "c":
                        DisplayDeleteSeaMonster(seaMonsters);
                        break;

                    case "D":
                    case "d":
                        DisplaySeaMonsterInfo(seaMonsters);
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
            Console.WriteLine("\t\tWelcome to Simple Monster Classes");
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
            Console.WriteLine("\t\tThanks for using Simple Monster Classes.");
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
