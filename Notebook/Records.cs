using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    struct Record
    {
        #region Fields;

        /// <summary>
        /// Filed "Number"
        /// </summary>
        private int number;
        /// <summary>
        /// Filed "Date"
        /// </summary>
        private DateTime date;
        /// <summary>
        /// Filed "Title"
        /// </summary>
        private string title;
        /// <summary>
        /// Filed "Discription"
        /// </summary>
        private string discription;
        /// <summary>
        /// Filed "Signature"
        /// </summary>
        private string signature;

        #endregion Fields

        #region Constructor;

        /// <summary>
        /// Record creation
        /// </summary>
        /// <param name="Number">Number</param>
        /// <param name="Date">Date</param>
        /// <param name="Title">Title</param>
        /// <param name="Discription">Discription</param>
        /// <param name="Signature">Signature</param>

        public Record(int Number, DateTime Date, string Title, string Discription, string Signature)
        {
            this.number = Number;
            this.date = Date;
            this.title = Title;
            this.discription = Discription;
            this.signature = Signature;
        }

        #endregion Constructor

        #region Methods;
        /// <summary>
        /// Printing data
        /// </summary>
        /// <returns>String with all data</returns>
        public string Print()
        {
            return $"{this.number,5}{this.date.ToShortDateString(),15}{this.title,15}{this.discription,20}{this.signature,15}";
        }

        #endregion Methods

        #region Properties;

        /// <summary>
        /// Number
        /// </summary>
        public int Number { get { return this.number; } set { this.number = value; } }
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get { return this.date; } set { this.date = value; } }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get { return this.title; } set { this.title = value; } }
        /// <summary>
        /// Discription
        /// </summary>
        public string Discription { get { return this.discription; } set { this.discription = value; } }
        /// <summary>
        /// Signature
        /// </summary>
        public string Signature { get { return this.signature; } set { this.signature = value; } }

        #endregion Properties


    }
}
