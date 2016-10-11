using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingFile
{
    public class Result
    {

        private bool isSucess;

        public bool IsSucess
        {
            get { return isSucess; }
            set { isSucess = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }


    }
}
