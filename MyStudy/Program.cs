using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******三维数组******");
            //三维数组
            int[,,] arr = 
                { 
                { { 1, 2 }, { 3, 4 } },
                { { 5, 6 }, { 7, 8 } }, 
                { { 9, 10 }, { 11, 12 } }
            };
            Console.WriteLine(arr[0, 1, 1]);

            Console.WriteLine("******锯齿数组******");
            //锯齿数组
            //二维数组的大小对应于一个矩形,如对应的元素个数为3× 3。 而锯齿数组的大小设置比较灵活,在
            //锯齿数组中,每一行都可以有不同的大小。
            int[][] jagged = new int[3][];
            jagged[0] = new int[2] { 0, 1 };
            jagged[1] = new int[5] { 2, 3, 4, 5, 6 };
            jagged[2] = new int[3] { 7, 8, 9 };

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.WriteLine($"第{i+1}行{j+1}列值{jagged[i][j]}");
                }
            }
            

            //Array类 数组实现排序
            Person[] persons = {
            new Person{ FirstName="D" ,LastName="H"},
            new Person{ FirstName="N" ,LastName="L"},
            new Person{ FirstName="A" ,LastName="S"},
            new Person{ FirstName="G" ,LastName="H"},
            };

            Array.Sort(persons);//必须实现Icomparable

            foreach (var p in persons)
            {
                Console.WriteLine(p);
            }
            //元组
            //1.利用构造函数创建元组：
            var testTuple6 = new Tuple<int, int, int, int, int, int>(1, 2, 3, 4, 5, 6);
            Console.WriteLine($"Item 1: {testTuple6.Item1}, Item 6: {testTuple6.Item6}");


            var testTuple10 = new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>(1, 2, 3, 4, 5, 6, 7, new Tuple<int, int, int>(8, 9, 10));
            Console.WriteLine($"Item 1: {testTuple10.Item1}, Item 10: {testTuple10.Rest.Item3}");


            //2.利用Tuple静态方法构建元组，最多支持八个元素
            var testTuple16 = Tuple.Create<int, int, int, int, int, int>(1, 2, 3, 4, 5, 6);
            Console.WriteLine($"Item 1: {testTuple16.Item1}, Item 6: {testTuple16.Item6}");

            var testTuple8 = Tuple.Create<int, int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine($"Item 1: {testTuple8.Item1}, Item 8: {testTuple8.Rest.Item1}");

            Console.ReadKey();




        }
    }
}
