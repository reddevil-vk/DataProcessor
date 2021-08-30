using System;
using DataProcessor.Processor;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                UserInput input = new UserInput();

                Console.WriteLine("=======================================");
                Console.WriteLine("** Welcome to Data Processor **");
                Console.WriteLine("=======================================");

                Console.WriteLine("Please select one of the below source for your data - ");
                Console.WriteLine("1: File");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Input a number below");

                input.sourceInput = Console.ReadLine();
                
                Console.WriteLine("----------------------------------------");

                input.inputSourceValidation();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Please select one of the output format - ");
                Console.WriteLine("1: Binary");
                Console.WriteLine("2: Text");
                Console.WriteLine("3: TextReverse");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Input a number below");

                input.dataTypeInput = Console.ReadLine();

                Console.WriteLine("----------------------------------------");

                Console.WriteLine("Processing Data ...... ");
                Console.WriteLine("");

                input.inputDataTypeValidation();

                Console.WriteLine("=======================================");
                Console.WriteLine("** End **");



            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
