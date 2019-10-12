using System.Collections.Generic;

namespace ActivePlus.Service
{
    /// <summary>
    /// Service with logic
    /// </summary>
    public interface IAPService
    {
        /// <summary>
        /// Task1 - adding elements of arrays by modulo
        /// </summary>
        int Task1(IEnumerable<int> array); 
        
        /// <summary>
        /// Task2 - adding elements of 2 linnked lists at one
        /// </summary>
        LinkedList<byte> Task2(LinkedList<byte> list1, LinkedList<byte> list2); 

        /// <summary>
        /// Task3 - is phrase a palindrome
        /// </summary>
        bool Task3(string phrase); 
    }
}