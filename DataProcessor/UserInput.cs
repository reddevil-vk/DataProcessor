using System;
using System.IO;
using System.Text;
using DataProcessor.Enums;
using DataProcessor.Processor;
namespace DataProcessor
{
    public class UserInput
    {
        private string _sourceInput;
        private string _dataTypeInput;
        private string _filePath;
        private FileProcessing _fileprocessor;
        private string _fileContents;
        private string _output;

        public string sourceInput
        {
            get { return _sourceInput; }
            set { _sourceInput = value; }
        }
        public string dataTypeInput
        {
            get { return _dataTypeInput; }
            set { _dataTypeInput = value; }
        }

        public string filePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public UserInput()
        {
            

        }

        /// <summary>
        /// Asks for File Path
        /// </summary>
        /// <returns></returns>
        public void fileInput()
        {
            try
            {
                Console.WriteLine("Please enter a Filepath");
                _filePath = Console.ReadLine();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("There was a problem with filepath - "+ ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Verifies the source input
        /// </summary>
        public void inputSourceValidation()
        {
            try
            {
                int source = 0;
                int.TryParse(_sourceInput, out source);
                switch (source)
                {
                    case (int)sourceEnum.file:
                        fileInput();
                        break;
                    case (int)sourceEnum.database:
                        Console.Write("Not implemented");
                        break;
                    case (int)sourceEnum.eventLog:
                        Console.Write("Not implemented");
                        break;

                    default:
                        Console.Write("Please Enter correct value");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifies the Data Type Input
        /// </summary>
        public void inputDataTypeValidation()
        {
            try
            {
                _fileprocessor = new FileProcessing();
                _fileContents = readFileFromSource();
                int source = 0;
                int.TryParse(_dataTypeInput, out source);
                switch (source)
                {
                    case (int)datatypeEnum.binary:
                        _output = _fileprocessor.getBinary(_fileContents);

                        Console.WriteLine("First 5 bytes of the file are - ");
                        Console.WriteLine(_output);

                        break;
                    case (int)datatypeEnum.text:
                        _output = _fileprocessor.getText(_fileContents);

                        Console.WriteLine("First 7 bytes of the file in UTF8 format are - ");
                        Console.WriteLine(_output);

                        break;
                    case (int)datatypeEnum.textReverse:
                        _output = _fileprocessor.getTextReverse(_fileContents);

                        Console.WriteLine("First 6 bytes of the file in reverse in UTF8 format are - ");
                        Console.WriteLine(_output);

                        break;
                    default:
                        Console.Write("Please enter correct value");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reds the file into a string variable
        /// </summary>
        /// <returns></returns>
        public string readFileFromSource()
        {
            try
            {
                string contents = null;
                if (File.Exists(_filePath))
                {
                    using (StreamReader sr = new StreamReader(_filePath, Encoding.UTF8))
                    {
                        contents = sr.ReadToEnd();
                    }
                }
                return contents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
