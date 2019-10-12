using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ActivePlus.Service
{
    public class APService : IAPService
    {
        /// <inheritdoc />
        public virtual int Task1(IEnumerable<int> array)
        {
            if(array == null)
            {
                throw new ArgumentNullException("The input array is null");
            }

            if(array.Count() < 1)
                return 0;

            int sum = 0;
            int num = 0;
            bool odd = false;
            foreach(var element in array)
            {
                if(num % 2 == 1)
                {
                    odd = !odd;
                    if(odd)
                    {
                        sum += Math.Abs(element);
                    }
                }
                num++;
            }
            return sum;
        }

        /// <inheritdoc />
        public LinkedList<byte> Task2(LinkedList<byte> list1, LinkedList<byte> list2)
        {
            if(list1 == null || !list1.Any())
                throw new ArgumentNullException("The input array " + nameof(list1) + " is null or empty");
            if(list2 == null || !list2.Any())
                throw new ArgumentNullException("The input array " + nameof(list2) + " is null or empty");

            LinkedListNode<byte> list1Node = list1.Last;
            LinkedListNode<byte> list2Node = list2.Last;
            var listResult = new LinkedList<byte>();
            byte decimals = 0;
            do
            {
                var list1Value = 
                    list1Node != null ? list1Node.Value : 0;
                var list2Value = 
                    list2Node != null ? list2Node.Value : 0;
                if(list1Value > 9 || list1Value < 0)
                   throw new ArgumentException("Wrong element at " + nameof(list1) + " list");
                if(list2Value > 9 || list2Value < 0)
                   throw new ArgumentException("Wrong element at " + nameof(list2) + " list");

                byte res = (byte)(list1Value + list2Value + decimals);
                listResult.AddFirst((byte)(res % 10));
                decimals = (byte)(res / 10);

                if(list1Node != null)
                    list1Node = list1Node.Previous;

                if(list2Node!=null)
                    list2Node = list2Node.Previous;
            }
            while(list1Node != null || list2Node != null);
            if(decimals > 0)
                listResult.AddFirst((byte)(decimals));


            return listResult;
        }

        /// <inheritdoc />
        public bool Task3(string phrase)
        {
            if(phrase.Length == 0)
                return false;

            string reversedPhrase;
            StringBuilder sb = new StringBuilder();

            var enumerator = StringInfo.GetTextElementEnumerator(phrase);
            while(enumerator.MoveNext())
            {
                sb.Insert(0, (string)enumerator.Current);
            }

            reversedPhrase = sb.ToString();

            // very incomplete list of symbols!
            var symbolsToSkip = new String[]{" ", "-", ",", "."}; 

            var enumeratorL = StringInfo.GetTextElementEnumerator(phrase);
            var enumeratorR = StringInfo.GetTextElementEnumerator(reversedPhrase);
            while(enumeratorL.MoveNext() && enumeratorR.MoveNext())
            {
                while(symbolsToSkip.Contains((string)enumeratorL.Current) && enumeratorL.MoveNext())
                {
                    ;
                }
                while(symbolsToSkip.Contains((string)enumeratorR.Current) && enumeratorR.MoveNext())
                {
                    ;
                }
                
                if(((string)enumeratorL.Current).ToLower() != ((string)enumeratorR.Current).ToLower())
                    return false;
                
            }
            return true;
        }
    }
}