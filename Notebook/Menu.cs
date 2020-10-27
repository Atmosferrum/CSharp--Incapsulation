using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Notebook
{
    struct Menu
    {
        Repository repository; //Link to Repository


        #region Constuctor;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Repository">Repository to adjust</param>
        public Menu(Repository Repository)
        {
            this.repository = Repository;
        }

        #endregion Constuctor


        #region Methods;

        /// <summary>
        /// Only public Method start MENU
        /// </summary>
        public void StartMenu()
        {
            ShowMenu();
            GetOption();
        }

        /// <summary>
        /// Show user MAIN MENU
        /// </summary>
        private void ShowMenu()
        {
            WriteLine($"NOTEBOOK" +
                      $"\n" +
                      $"\n1. Create entry." +
                      $"\n2. Delete entry." +
                      $"\n3. Edit entry." +
                      $"\n4. Load DATA from file." +
                      $"\n5. Save DATA to file." +
                      $"\n6. Add DATA to current Notebook from file." +
                      $"\n7. Import DATA from given dates." +
                      $"\n8. Sort Notebook entries by given field." +
                      $"\n" +
                      $"\nInput option number : ");
        }

        /// <summary>
        /// Get MAIN OPTIONS from user
        /// </summary>
        private void GetOption()
        {
            int optionNumber;

            bool parsed = false;

            do
            {
                //Bool to check if file text is legit
                bool result = Int32.TryParse(ReadLine(), out optionNumber);
                //If legit, end loop. If not, repeat
                if (result && optionNumber < 9 && optionNumber > 0)
                    parsed = true;
                else
                    WriteLine("There's no available option with given number, please input another one : ");
            } while (!parsed);

            switch (optionNumber)
            {
                case 1:
                    AddEntry(); //Option to ADD Entry
                    break;
                case 2:
                    DeleteEntry(); //Option to DELETE Entry
                    break;
                case 3:
                    EditEntry(); //Option to EDIT Entry
                    break;
                case 4:
                    GetPathToLoadData(); // Option to LOAD DATA from file
                    break;
                case 5:
                    GetPathToSaveData(); //Option to SAVE DATA to file
                    break;
                case 6:
                    AddFromFile(); //Option to ADD DATA from file
                    break;
                case 7:
                    ImportByDate(); //Option to IMPORT by DATA by DATE
                    break;
                case 8:
                    SortByField(); //Option to sort entries by given FILED
                    break;
                default:
                    GetOption();
                    break;
            }
        }

        /// <summary>
        /// Method to ADD Record to Repository
        /// </summary>
        private void AddEntry()
        {
            string title;

            string discription;

            string signature;

            WriteLine("\nInput entry Title : ");

            title = ReadLine();

            WriteLine("\nInput entry Discription : ");

            discription = ReadLine();

            WriteLine("\nInput entry Signature : ");

            signature = ReadLine();

            repository.Add(new Record(repository.index + 1, DateTime.Now, title, discription, signature));

            repository.PrintDbToConsole();

            AdditionalActions(1);
        }

        /// <summary>
        /// Method to DELETE Record from Repository
        /// </summary>
        private void DeleteEntry()
        {
            repository.PrintDbToConsole();

            WriteLine("\nInput entry number you want to delete : ");

            int deleteEntryNumber;

            bool parsed = false;

            do
            {
                //Bool to check if file text is legit
                bool result = Int32.TryParse(ReadLine(), out deleteEntryNumber);
                //If legit, end loop. If not, repeat
                if (result && deleteEntryNumber <= repository.index && deleteEntryNumber > 0)
                    parsed = true;
                else
                    WriteLine("There's no entry with given number, please input another one : ");
            } while (!parsed);

            repository.Remove(deleteEntryNumber);

            AdditionalActions(2);
        }

        /// <summary>
        /// Method to EDIT Record in Repository
        /// </summary>
        private void EditEntry()
        {
            int deleteEntryNumber;

            bool parsed = false;

            string title;

            string discription;

            string signature;

            repository.PrintDbToConsole();

            WriteLine("\nInput entry number you want to edit : ");

            do
            {
                //Bool to check if file text is legit
                bool result = Int32.TryParse(ReadLine(), out deleteEntryNumber);
                //If legit, end loop. If not, repeat
                if (result && deleteEntryNumber <= repository.index && deleteEntryNumber > 0)
                    parsed = true;
                else
                    WriteLine("There's no entry with given number, please input another one : ");
            } while (!parsed);

            WriteLine("\nInput entry Title : ");

            title = ReadLine();

            WriteLine("\nInput entry Discription : ");

            discription = ReadLine();

            WriteLine("\nInput entry Signature : ");

            signature = ReadLine();

            repository.Edit(deleteEntryNumber, title, discription, signature);

            AdditionalActions(3);
        }

        /// <summary>
        /// Method to ADD New Records from given File
        /// </summary>
        private void AddFromFile()
        {
            string path;

            repository.PrintDbToConsole();

            WriteLine("\nInput path to the file you want to ADD : ");

            path = ReadLine();

            repository.AddFromFile(path);

            AdditionalActions(4);
        }

        /// <summary>
        /// Method to ADD New Rcords from given File by given Dates
        /// </summary>
        private void ImportByDate()
        {
            DateTime date1;

            DateTime date2;

            string path;

            repository.PrintDbToConsole();

            WriteLine("\nInput path to the file you want to ADD : ");

            path = ReadLine();

            WriteLine("\nInput dates you want to import : ");

            date1 = DateTime.Parse(ReadLine());

            date2 = DateTime.Parse(ReadLine());

            repository.AddFromFile(path, date1, date2);

            AdditionalActions(5);
        }

        /// <summary>
        /// Method to SORT dates by given Title 
        /// </summary>
        private void SortByField()
        {
            bool parsed = false;

            int optionNumber;

            repository.PrintDbToConsole();

            WriteLine($"Chose sorting method : " +
                     $"\n" +
                     $"\n1. Number." +
                     $"\n2. Date." +
                     $"\n3. Title." +
                     $"\n4. Discription." +
                     $"\n5. Signature." +
                     $"\n" +
                     $"\nInput option number : ");

            do
            {
                //Bool to check if file text is legit
                bool result = Int32.TryParse(ReadLine(), out optionNumber);
                //If legit, end loop. If not, repeat
                if (result && optionNumber < 6 && optionNumber > 0)
                    parsed = true;
                else
                    WriteLine("There's no available option with given number, please input another one : ");
            } while (!parsed);

            repository.SortBy(optionNumber);

            AdditionalActions(6);

        }

        /// <summary>
        /// Method to LOAD DATA from given File
        /// </summary>
        private void GetPathToLoadData()
        {
            string path = "";

            WriteLine("\nInput path to the file you want to LOAD : ");

            path = ReadLine();

            repository = new Repository(path);

            repository.PrintDbToConsole();
        }

        /// <summary>
        /// Method to GET Path to SAVE DATA to File
        /// </summary>
        private void GetPathToSaveData()
        {
            string path;

            WriteLine("\nInput path to the file you want to SAVE : ");

            path = ReadLine();

            repository.Save(path);

            WriteLine($"\nFile {path} successfully saved !");
            WriteLine();

            StartMenu();
        }

        /// <summary>
        /// Method with Options after first wave of Actions
        /// </summary>
        /// <param name="currentAction">Current action (Add, Delete, Save, Sort, etc...)</param>
        private void AdditionalActions(int currentAction)
        {
            int optionNumber;

            WriteLine($"Chose option : " +
                     $"\n" +
                     $"\n1. Choose another entry/file or sorting method." +
                     $"\n2. Save DATA to File." +
                     $"\n" +
                     $"\nInput option number : ");

            bool parsed = false;

            do
            {
                //Bool to check if file text is legit
                bool result = Int32.TryParse(ReadLine(), out optionNumber);
                //If legit, end loop. If not, repeat
                if (result && optionNumber < 3 && optionNumber > 0)
                    parsed = true;
                else
                    WriteLine("There's no available option with given number, please input another one : ");
            } while (!parsed);

            switch (optionNumber)
            {
                case 1:
                    switch (currentAction)
                    {
                        case 1:
                            AddEntry();
                            break;
                        case 2:
                            DeleteEntry();
                            break;
                        case 3:
                            EditEntry();
                            break;
                        case 4:
                            AddFromFile();
                            break;
                        case 5:
                            ImportByDate();
                            break;
                        case 6:
                            SortByField();
                            break;
                        default:
                            AdditionalActions(currentAction);
                            break;
                    }
                    break;
                case 2:
                    GetPathToSaveData();
                    break;
                default:
                    AdditionalActions(currentAction);
                    break;
            }
        }

        #endregion Methods
    }
}
