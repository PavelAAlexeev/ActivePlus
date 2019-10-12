using System.Collections.Generic;

namespace ActivePlus.Service
{
    public interface IAPService
    {
        int Task1(IEnumerable<int> array); 
        LinkedList<byte> Task2(LinkedList<byte> list1, LinkedList<byte> list2); 
        bool Task3(string phrase); 
    }
}