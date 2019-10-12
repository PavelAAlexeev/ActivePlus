using System.Collections.Generic;
using Xunit;


namespace ActivePlus.Service.Test
{
    public class APServiceTest
    {

        [Theory]
        [InlineData(new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 15 )]
        [InlineData(new int[]{0}, 0 )]
        [InlineData(new int[]{0, 1}, 1)]
        public void Test1(int[] array, int expected)
        {
            IAPService apService = new APService();
            int result = apService.Task1(array);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new byte[]{0}, new byte[]{0}, new byte[]{0} )]
        [InlineData(new byte[]{9}, new byte[]{9}, new byte[]{1, 8} )]
        [InlineData(new byte[]{9,9}, new byte[]{9}, new byte[]{1, 0, 8} )]
        [InlineData(new byte[]{9}, new byte[]{9,9}, new byte[]{1, 0, 8} )]
        [InlineData(new byte[]{9,9}, new byte[]{1,1}, new byte[]{1, 1, 0} )]
        public void Test2(byte[] array1, byte[] array2, byte[] expected)
        {
            IAPService apService = new APService();
            LinkedList<byte> list1 = new LinkedList<byte>(array1);
            LinkedList<byte> list2 = new LinkedList<byte>(array2);
            LinkedList<byte> result = apService.Task2(list1, list2);

            Assert.Equal(expected.Length, result.Count);
            int i = 0;
            foreach(var e in result)
            {
                Assert.Equal(expected[i], e);
                i++;
            }
        }

        [Theory]
        [InlineData("А роза упала на лапу Азора", true )]
        [InlineData("Never odd or even", true )]
        [InlineData("A man, a plan, a canal - Panama", true )]
        [InlineData("Le\u0301l", true )]
        [InlineData(" 1 2 3 ", false)]
        public void Test3(string phrase, bool expected)
        {
            IAPService apService = new APService();

            Assert.Equal(expected, apService.Task3(phrase));
        }
    }
}