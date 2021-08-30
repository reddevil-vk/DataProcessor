using System;
using System.Linq;
using System.Text;
namespace DataProcessor.Processor
{
    public class FileProcessing : IProcessing
    {
        public FileProcessing()
        {
           //Do Nothing 
        }

        /// <summary>
        /// Displays the first 4 characters of input text in Binary format
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string getBinary(string text)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                

                return Convert.ToBase64String(bytes,0,4);
            }
            catch (Exception)
            {
                throw new Exception("There was a problem with converting the data to binary");
            }
            
        }

        /// <summary>
        /// Displays the first 7 characters of Input Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string getText(string text)
        {
            try
            {
                string result = "";

                char[] arr = text.ToCharArray();
                char[] newarr = new char[7];

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (i == 6)
                    {
                        break;
                    }
                    else
                    {
                        newarr[i] = arr[i];
                    }
                }

                byte[] getByte = new byte[newarr.Length];

                UTF8Encoding utf8 = new UTF8Encoding();
                getByte = utf8.GetBytes(newarr);
                
                for (int i = 0; i < getByte.Length; i++)
                {

                    result += getByte[i] + " ";
                }


                return result;
            }
            catch (Exception)
            {
                throw new Exception("There was a problem encoding the text file.");
            }
        }

        /// <summary>
        /// Reverse the first 6 characters of input text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string getTextReverse(string text)
        {
            try
            {
                string result = "";

                char[] arr = text.ToCharArray();
                char[] newarr = new char[6];

                for (int i = 0; i < arr.Length -1 ; i++)
                {
                    if (i == 6)
                    {
                        break;
                    }
                    else
                    {
                        newarr[i] = arr[i];
                    }
                }
                
                byte[] getByte = new byte[newarr.Length];

                UTF8Encoding utf8 = new UTF8Encoding();
                getByte = utf8.GetBytes(newarr);
                getByte = getByte.Reverse().ToArray();

                for (int i = 0; i < getByte.Length; i++)
                {
                    
                    result += getByte[i]+" ";
                }

                
                return result;
            }
            catch (Exception)
            {
                throw new Exception("There was a problem with encoding and/or reversing the text in the file.");

            }
        }
    }
}
