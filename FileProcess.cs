using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingFile
{
    public class FileProcess
    {

        private readonly string _dataFilePath;
        private readonly string _nameFilePath;
        private readonly string _addressFilePath;

       

        private List<Result> results;

        public List<Result> Results
        {
            get { return results; }
          //  set { results = value; }
        }


        /// <summary>
        /// Constructor, which accepts datafile, resutls file details
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <param name="outputNameFilePath"></param>
        /// <param name="outputAddressFilePath"></param>
        public FileProcess(string dataFilePath, string outputNameFilePath, string outputAddressFilePath)
        {
            _dataFilePath = dataFilePath;
            _nameFilePath = outputNameFilePath;
            _addressFilePath = outputAddressFilePath;
            results = new List<Result>();
        }

        /// <summary>
        /// Process the file
        /// </summary>
        /// <returns></returns>
        public bool ProcessFile()
        {
            bool isSucess = false;

            isSucess = (ValidateDataFilePath() & ValidateNameResultFilePath() & ValidateAddressFilePath());
            if (isSucess == false)
                return isSucess;

          

            
            try
            {
                string[] lst = ReadInformationFromFile();



                if (lst.Count() > 0)
                {
                    List<Person> lstPerson = GetListOfPerson(lst);

                    if (lstPerson.Count > 0)
                    {
                        List<string> lstNames = ExtractNameFromPerson(lstPerson);
                        WriteNameListToFile(lstNames);
                        WriteAddressToFile(lstPerson);
                    }
                }

                results.Add(new Result()
                {
                    ErrorMessage = "Successfully Processed",
                    IsSucess = true,
                    Title = "File Processing "
                });

            }
            catch (Exception ex)
            {
                results.Add(new Result()
                {
                    ErrorMessage = ex.Message,
                    IsSucess = false,
                    Title = "Generic Exception"
                });
            }

            return true;
        }


        public string[] ReadInformationFromFile()
        {
            string[] lstPerons = File.ReadAllLines(_dataFilePath).Skip(1).ToArray();
            return lstPerons;
        }

        /// <summary>
        /// Validates Data file Directory 
        /// </summary>
        /// <returns></returns>
        public bool ValidateDataFilePath()
        {
            bool isSucess = false;

            
           if(HelperClass.IsValidPath(_dataFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Data File Path",
                    IsSucess = false,
                    Title = "Data File Path"
                });
                return false;
            }

   
           if(HelperClass.IsValidDirectory(_dataFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Data File Path",
                    IsSucess = false,
                    Title = "Data File Path"
                });
                return false;
            }

           
           
           if(!HelperClass.IsFieExists(_dataFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = (new FileNotFoundException()).Message,
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }

           
            if(!HelperClass.IsValidFileExtension(_dataFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Data File",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }

            isSucess = true;

            return isSucess;
        }

        /// <summary>
        /// Validates Name Result file directory
        /// </summary>
        /// <returns></returns>
        public bool ValidateNameResultFilePath()
        {
            bool isSucess = false;

            

            if(HelperClass.IsValidPath(_nameFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Name Result file path",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }


           if(HelperClass.IsValidDirectory(_nameFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Name Result file path",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }

            if (!HelperClass.IsDirectoryExists(_nameFilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_nameFilePath));

            }


            if (!HelperClass.IsValidFileExtension(_nameFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Name Result File extension",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }

            isSucess = true;

            return isSucess;
        }

        /// <summary>
        /// Validate Address results Directory
        /// </summary>
        /// <returns></returns>
        public bool ValidateAddressFilePath()
        {
            bool isSucess = false;

                        
            if(HelperClass.IsValidPath(_addressFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Address Result file path",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }

             
           if(HelperClass.IsValidDirectory(_addressFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Address Result file path",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }

           
           if(!HelperClass.IsDirectoryExists(_addressFilePath))
            {
                Directory.CreateDirectory(_addressFilePath);

            }

           
            if (!HelperClass.IsValidFileExtension(_addressFilePath))
            {
                results.Add(new Result()
                {
                    ErrorMessage = "Invalid Address Result File extension",
                    IsSucess = false,
                    Title = "Data File "
                });
                return isSucess;
            }


            isSucess = true;

            return isSucess;
        }

        /// <summary>
        /// Gets list of person
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public List<Person> GetListOfPerson(string[] lst)
        {
            List<Person> lstPerson = new List<Person>();

            if (lst != null)
            {
                foreach (string s in lst)
                {
                    string[] pStr = s.Split(',');

                    if (pStr.Count() == 4)
                    {
                        Person p = new Person(pStr[0], pStr[1], pStr[2], pStr[3]);
                        lstPerson.Add(p);
                    }
                }
            }

            return lstPerson;
        }

        /// <summary>
        /// Return list of names
        /// </summary>
        /// <param name="lstPerson"></param>
        /// <returns></returns>
        public List<string> ExtractNameFromPerson(List<Person> lstPerson)
        {
        

            List<string> namelist = lstPerson.Select(s => s.FirstName).ToList();
            List<string> lastNameLst = lstPerson.Select(s => s.LastName).ToList();
            namelist.AddRange(lastNameLst);

            return namelist;

        }

        /// <summary>
        /// Writes Name, count in a file
        /// </summary>
        /// <param name="lstNames"></param>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public bool WriteNameListToFile(List<string> lstNames)
        {
            bool isSuccess = false;

            isSuccess = ValidateNameResultFilePath();

            if (isSuccess == true)
            {
                var result = lstNames.GroupBy(s => s)
                    .Select(g => new { PersonName = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .OrderBy(y => y.PersonName);

                using (StreamWriter writer = new StreamWriter(_nameFilePath))
                {
                    foreach (var single in result)
                    {
                        writer.WriteLine(single.PersonName + "," + single.Count);
                    }
                    writer.Flush();
                    writer.Close();
                }

            }


                return isSuccess;

        }

        /// <summary>
        /// Writes Address in a file
        /// </summary>
        /// <param name="lstPerson"></param>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public bool WriteAddressToFile(List<Person> lstPerson)
        {
            bool isSucess = false;

            isSucess = ValidateAddressFilePath();

            if (isSucess == true)
            {
                var result = lstPerson.OrderBy(x => x.Address)
                    .Select(x => new { Address = x.Address });


                using (StreamWriter writer = new StreamWriter(_addressFilePath))
                {
                    foreach (var single in result)
                    {
                        writer.WriteLine(single.Address);
                    }
                    writer.Flush();
                    writer.Close();
                }
            }

            return isSucess;

        }
    }
}


