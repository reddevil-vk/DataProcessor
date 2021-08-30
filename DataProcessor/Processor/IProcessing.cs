using System;
namespace DataProcessor.Processor
{
    public interface IProcessing
    {
        string getBinary(string text);
        string getText(string text);
        string getTextReverse(string text);
    }
}
