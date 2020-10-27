using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    struct Repository
    {

        #region Variables;

        private Record[] records; // DATA Records Array     

        private string path; //PATH to file

        public int index; // Current INDEX for record to add

        string[] titles; //TITLES array for PrintDbToConsole 

        #endregion Variables

        #region Constructor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Path">Path do DATA file</param>
        public Repository(string Path)
        {
            this.path = Path; // Saving DATA file PATH
            this.index = 0; // index of current RECORD
            this.titles = new string[0]; // TITLES array intiation
            this.records = new Record[1]; // RECORDS array initiation

            this.Load(); //Loading DATA
        }

        #endregion Constructor

        #region Methods;

        /// <summary>
        /// Method to load DATA
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    Add(new Record(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], args[3], args[4]));
                }
            }
        }

        /// <summary>
        /// Method to INCREASE Repository
        /// </summary>
        /// <param name="Flag">Boolen to check</param>
        private void Resize(bool Flag)
        {
            if (Flag)
                Array.Resize(ref this.records, this.records.Length * 2);
        }

        /// <summary>
        ///Method to add RECORD to Repository 
        /// </summary>
        /// <param name="CurrentRecord">Current Record</param>
        public void Add(Record CurrentRecord)
        {
            this.Resize(index >= this.records.Length);
            this.records[index] = CurrentRecord;
            this.index++;
        }

        /// <summary>
        /// Method to print DATA to Console
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.WriteLine($"\n{this.titles[0],5} {this.titles[1],14} {this.titles[2],14} {this.titles[3],19} {this.titles[4],14}");

            for (int i = 0; i < index; i++)
                Console.WriteLine(this.records[i].Print());

            Console.WriteLine();
        }

        /// <summary>
        /// Method to remove RECORD from Repository
        /// </summary>
        /// <param name="entryIndex">Entry number to remove</param>
        public void Remove(int entryIndex)
        {
            this.records = this.records.Where(rec => Convert.ToInt32(rec.Number) != entryIndex).ToArray();

            for (int i = 0; i < this.records.Length; i++)
                this.records[i].Number = i + 1;

            index--;

            PrintDbToConsole();
        }

        /// <summary>
        /// Method to edit RECOR in Repository
        /// </summary>
        /// <param name="entryIndex">Entry index to edit</param>
        /// <param name="title">New title</param>
        /// <param name="discription">New discription</param>
        /// <param name="signature">New signature</param>
        public void Edit(int entryIndex, string title, string discription, string signature)
        {
            this.records[entryIndex - 1].Title = title;
            this.records[entryIndex - 1].Discription = discription;
            this.records[entryIndex - 1].Signature = signature;

            PrintDbToConsole();
        }

        /// <summary>
        /// Method to load DATA
        /// </summary>
        public void AddFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                titles = sr.ReadLine().Split(',');

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    Add(new Record(index + 1, Convert.ToDateTime(args[1]), args[2], args[3], args[4]));
                }
            }

            PrintDbToConsole();
        }

        /// <summary>
        /// Method to load DATA
        /// </summary>
        public void AddFromFile(string path, DateTime date1, DateTime date2)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                titles = sr.ReadLine().Split(',');

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    if (Convert.ToDateTime(args[1]) >= date1 && Convert.ToDateTime(args[1]) <= date2)
                        Add(new Record(index + 1, Convert.ToDateTime(args[1]), args[2], args[3], args[4]));
                }
            }

            PrintDbToConsole();
        }

        /// <summary>
        /// Method to sort DATA by given Title
        /// </summary>
        /// <param name="sortNumber">Title number</param>
        public void SortBy(int sortNumber)
        {
            this.records = this.records.Where(rec => Convert.ToInt32(rec.Number) != 0).ToArray();

            switch (sortNumber)
            {
                case 1:
                    this.records = this.records.OrderBy(rec => rec.Number).ToArray();
                    PrintDbToConsole();
                    break;
                case 2:
                    this.records = this.records.OrderBy(rec => rec.Date).ToArray();
                    PrintDbToConsole();
                    break;
                case 3:
                    this.records = this.records.OrderBy(rec => rec.Title).ToArray();
                    PrintDbToConsole();
                    break;
                case 4:
                    this.records = this.records.OrderBy(rec => rec.Discription).ToArray();
                    PrintDbToConsole();
                    break;
                case 5:
                    this.records = this.records.OrderBy(rec => rec.Signature).ToArray();
                    PrintDbToConsole();
                    break;
                default:
                    SortBy(sortNumber);
                    break;
            }
        }
        /// <summary>
        /// Method to save DATA
        /// </summary>
        /// <param name="Path">Path to file</param>
        public void Save(string Path)
        {
            string temp = String.Format("{0}, {1}, {2}, {3}, {4}",
                                            this.titles[0],
                                            this.titles[1],
                                            this.titles[2],
                                            this.titles[3],
                                            this.titles[4]);

            File.AppendAllText(Path, $"{temp}\n");

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0}, {1}, {2}, {3}, {4}",
                                        this.records[i].Number,
                                        this.records[i].Date,
                                        this.records[i].Title,
                                        this.records[i].Discription,
                                        this.records[i].Signature);
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Number od RECORDS in Repository
        /// </summary>
        public int Count { get { return this.index; } }

        #endregion Methods
    }
}
