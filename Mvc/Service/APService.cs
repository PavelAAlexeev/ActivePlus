using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ActivePlus.Service
{
    public class APService : IAPService
    {
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

        public LinkedList<byte> Task2(LinkedList<byte> list1, LinkedList<byte> list2)
        {
            if(list1 == null || !list1.Any())
                throw new ArgumentNullException("The input array " + nameof(list1) + " is null or empty");
            if(list2 == null || !list2.Any())
                throw new ArgumentNullException("The input array " + nameof(list2) + " is null or empty");

            byte list1Node, list2Node;
            var listResult = new LinkedList<byte>();
            byte decimals = 0;
            do
            {
                if(list1.Any())
                    list1Node = list1.Last();
                else
                    list1Node = 0;

                if(list2.Any())
                    list2Node = list2.Last();
                else
                    list2Node = 0;

                if(list1Node > 9 || list1Node < 0)
                   throw new ArgumentException("Wrong element at " + nameof(list1) + " list");
                if(list2Node > 9 || list2Node < 0)
                   throw new ArgumentException("Wrong element at " + nameof(list2) + " list");

                byte res = (byte)(list1Node + list2Node);
                listResult.AddFirst((byte)(res % 10 + decimals));
                decimals = (byte)(res / 10);

                if(list1.Any())
                    list1.RemoveLast();

                if(list2.Any())
                    list2.RemoveLast();
            }
            while(list1.Any() || list2.Any());
            if(decimals > 0)
                listResult.AddFirst((byte)(decimals));


            return listResult;
        }

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

            var enumeratorL = StringInfo.GetTextElementEnumerator(phrase);
            var enumeratorR = StringInfo.GetTextElementEnumerator(reversedPhrase);
            while(enumeratorL.MoveNext() && enumeratorR.MoveNext())
            {
                while((string)enumeratorL.Current == " " && enumeratorL.MoveNext())
                {
                    ;
                }
                while((string)enumeratorR.Current == " " && enumeratorR.MoveNext())
                {
                    ;
                }
                
                if((string)enumeratorL.Current != (string)enumeratorR.Current)
                    return false;
                
            }
            return true;


        }
   
    }
}