using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessingFile;
using System.Collections.Generic;

namespace ProcessingFileUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        #region DataFile

        [TestMethod]
        public void DataDirectoryExists()
        {
            bool expectedResult = true;
            string dataPath = @"C:\DataLoad\data.csv";
            
            FileProcess fp = new FileProcess(dataPath, "","");
            bool result = fp.ValidateDataFilePath();

            Assert.IsTrue(expectedResult == result);
                        
        }

        [TestMethod]
        public void DataDirectoryDoesntExists()
        {
            bool expectedResult = false;
            string dataPath = @"C:\DataLoad1\data.csv";

            FileProcess fp = new FileProcess(dataPath, "", "");
            bool result = fp.ValidateDataFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        [TestMethod]
        public void DataFileExists()
        {
            bool expectedResult = true;
            string dataPath = @"C:\DataLoad\data.csv";

            FileProcess fp = new FileProcess(dataPath, "", "");
            bool result = fp.ValidateDataFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        [TestMethod]
        public void DataFileDoesntExists()
        {
            bool expectedResult = false;
            string dataPath = @"C:\DataLoad\data1.csv";

            FileProcess fp = new FileProcess(dataPath, "", "");
            bool result = fp.ValidateDataFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        [TestMethod]
        public void DataEmptyFileExists()
        {
            bool expectedResult = false;
            string dataPath = @"C:\DataLoad";

            FileProcess fp = new FileProcess(dataPath, "", "");
            bool result = fp.ValidateDataFilePath();

            Assert.IsTrue(expectedResult == result);

        }


        [TestMethod]
        public void DataInvalidFile()
        {
            bool expectedResult = false;
            string dataPath = @"C:\DataLoad\data.txt";

            FileProcess fp = new FileProcess(dataPath, "", "");
            bool result = fp.ValidateDataFilePath();

            Assert.IsTrue(expectedResult == result);

        }
        #endregion


        #region NameFile


        [TestMethod]
        public void NameResultsDirectoryExists()
        {
            bool expectedResult = true;
            string dataPath = @"C:\DataLoad\Results\NameResult.csv";

            FileProcess fp = new FileProcess("", dataPath, "");
            bool result = fp.ValidateNameResultFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        [TestMethod]
        public void NameResultsDirectoryDoesntExists()
        {
            bool expectedResult = false;
            string dataPath = "Test";

            FileProcess fp = new FileProcess("", dataPath, "");
            bool result = fp.ValidateNameResultFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        #endregion

        #region AddressFile


        [TestMethod]
        public void AddressResultsDirectoryExists()
        {
            bool expectedResult = true;
            string dataPath = @"C:\DataLoad\Results\NameResult.csv";

            FileProcess fp = new FileProcess("", "", dataPath);
            bool result = fp.ValidateAddressFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        [TestMethod]
        public void AddressResultsDirectoryDoesntExists()
        {
            bool expectedResult = false;
            string dataPath = "Test";

            FileProcess fp = new FileProcess("", "", dataPath);
            bool result = fp.ValidateAddressFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        [TestMethod]
        public void AddressResultsInvalidDirectory()
        {
            bool expectedResult = false;
            string dataPath = "";

            FileProcess fp = new FileProcess("", "", dataPath);
            bool result = fp.ValidateAddressFilePath();

            Assert.IsTrue(expectedResult == result);

        }

        #endregion

        #region Get Information from file

        [TestMethod]
        public void ExtractDataFromFile()
        {
            
            string dataPath = @"c:\dataload\data.csv";

            FileProcess fp = new FileProcess(dataPath, "", "");
            string[] result = fp.ReadInformationFromFile();

            Assert.IsTrue(result.Length > 0);

        }

        [TestMethod]
        public void ExtractEmptyDataFromFile()
        {

            string dataPath = @"c:\dataload\dataempty.csv";

            FileProcess fp = new FileProcess(dataPath, "", "");
            string[] result = fp.ReadInformationFromFile();

            Assert.IsTrue(result.Length == 0);

        }

        #endregion

        #region Get Person Details

        [TestMethod]
        public void GetPersonDetails()
        {
            

            FileProcess fp = new FileProcess("", "", "");
            string[] inputString = new string[3]
            {
                "Jimmy,Smith,102 Long Lane,29384857",
                "Clive,Owen,65 Ambling Way,31214788",
                "James,Brown,82 Stewart St,32114566"
            };

            List<Person> result = fp.GetListOfPerson(inputString);

            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod]
        public void ExtractEmptyPersonDetails()
        {
            

            FileProcess fp = new FileProcess("", "", "");
            string[] inputString = null;


            List<Person> result = fp.GetListOfPerson(inputString);

            Assert.IsTrue(result.Count == 0);

        }

        [TestMethod]
        public void GetNameFromPerson()
        {



            FileProcess fp = new FileProcess("", "", "");
            List<Person> input = new List<Person>();
            input.Add(new Person()
            {
                FirstName = "James",
                LastName = "Clive",
                Address = "7 Main Road",
                TelephoneNumber = "213213123"
            });

            List<string> result = fp.ExtractNameFromPerson(input);

            Assert.IsTrue(result.Count > 0);

        }


        #endregion


        #region Write To File

        [TestMethod]
        public void WritePersonWithCountInFile()
        {

            bool expected = true;

            FileProcess fp = new FileProcess("", @"C:\dataload\Result\NameResult.csv", "");
            
            List<string> input = new List<string>();
            input.Add("Jimmy");
            input.Add("Clive");
            input.Add("Smith");
            input.Add("James");
            input.Add("Clive");
            input.Add("Smith");


            bool result = fp.WriteNameListToFile(input);

            Assert.IsTrue(expected == result);

        }

        [TestMethod]
        public void WritePersonWithCountInInvalidFile()
        {

            bool expected = false;

            FileProcess fp = new FileProcess("", @"C:\dataload\Result\NameResult.txt", "");

            List<string> input = new List<string>();
            input.Add("Jimmy");
            input.Add("Clive");
            input.Add("Smith");
            input.Add("James");
            input.Add("Clive");
            input.Add("Smith");


            bool result = fp.WriteNameListToFile(input);

            Assert.IsTrue(expected == result);

        }

        [TestMethod]
        public void WriteAddressInFile()
        {

            bool expected = true;

            FileProcess fp = new FileProcess("", "",  @"C:\dataload\Result\AddressResult.csv");

            List<Person> input = new List<Person>();
            input.Add(new Person()
            {
                FirstName = "James",
                LastName = "Clive",
                Address = "7 Main Road",
                TelephoneNumber = "213213123"
            });
            input.Add(new Person()
            {
                FirstName = "Smith",
                LastName = "Clive",
                Address = "49 Sutherland St",
                TelephoneNumber = "213213123"
            });

            bool result = fp.WriteAddressToFile(input);

            Assert.IsTrue(expected == result);

        }

        [TestMethod]
        public void WriteAddressInInvalidFile()
        {

            bool expected = false;

            FileProcess fp = new FileProcess("", "", @"C:\dataload\Result\AddressResult.txt");

            List<Person> input = new List<Person>();
            input.Add(new Person()
            {
                FirstName = "James",
                LastName = "Clive",
                Address = "7 Main Road",
                TelephoneNumber = "213213123"
            });
            input.Add(new Person()
            {
                FirstName = "Smith",
                LastName = "Clive",
                Address = "49 Sutherland St",
                TelephoneNumber = "213213123"
            });

            bool result = fp.WriteAddressToFile(input);

            Assert.IsTrue(expected == result);

        }

        #endregion

    }
}
