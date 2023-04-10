using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs22_collection
{
    class MyList
    {
        int[] array;

        public MyList()
        {
            array = new int[10];
        }

        public int Length
        {
            get { return array.Length; }
        }

        // 인덱서 프로퍼티
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length) // 3보다 더 많은 
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("MyList Resized {0}", array.Length);
                }

                array[index] = value;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5; // 이 이상 원소를 추가할 수 없음

            // Console.WriteLine(array[5]); // IndexOutOfRangeException

            char[] oldString = new char[5]; // 조선시대 방법 문자열의 길이를 지정해야하니까 => C에서만 쓰임
            string curString = ""; // 문자열길이 제한 없음

            // ArrayList
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6); // 위에 있는 배열과 다른점
            // 원소 입력에 제한이 없음

            // 여러가지 메서드
            ArrayList list2 = new ArrayList();
            list2.Add(8);
            list2.Add(4);
            list2.Add(14);
            list2.Add(25);
            list2.Add(7);
            list2.Add(2);

            foreach(var item in list2)
            {
                Console.WriteLine(item);
            }

            // list에서 데이터 삭제
            Console.WriteLine("7 삭제 후 ");
            list2.Remove(7);
            Console.WriteLine("3번째 데이터 삭제");
            list2.RemoveAt(3);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("0번째 위치 7 추가");
            list2.Insert(0, 7); //0번째 위치에 7을 입력
            
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("정렬");
            list2.Sort();

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            // ArrayList.Add(), Insert(x, val), .Remove(val), .RemoveAt(x), .Sort(), .Reverse()

            //새로만든My List
            MyList myList = new MyList();
            for(int i = 1; i<=5; i++)
            {
                myList[i] = i * 5; // 사이즈가 커짐
            }

        }
    }
}
