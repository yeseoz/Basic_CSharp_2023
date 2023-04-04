using System;

namespace cs03_object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Object 형식
            //int == System.Int32
            //long == System.Int64

            //Int32 idata = 1024; // 모든게 다 클래스화 되어있어서 데이터 타입도 다 클래스화 되어있음 그래서 사실 Int32로 쓰는게 맞음 c나 c++ 처럼 쓸 수 있도록 하기 위해서 int를 쓸 수 있는 것
            long idata = 1024;
            Console.WriteLine(idata);
            Console.WriteLine(idata.GetType()); // System.Int32

            object iobj = (object)idata; // 박싱(Boxing) : 데이터타입값을 object로 담아라
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            long udata = (long)iobj; // 언박싱(UnBoxing) : object를 원래 데이터 값으로 바꿔라
            Console.WriteLine(udata);  
            Console.WriteLine(udata.GetType()); // 아무리 오브젝트 타입을 변환해도 타입은 바뀌지 않음

            double ddata = 3.141592;
            object pobj = (object)ddata;
            double pdata = (double)pobj;

            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            short sdata = 32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata); // 작은데이터를 큰테이터에 넣을때 형변환 안적어줘도 상관없음
                                       // 하지만 큰데이터를 작은데이터에 넣을때는 형변환 적어줘야함
            indata = (int)lndata; // overflow 
            Console.WriteLine(indata);

            // float double 간 형변환
            float fval = 3.141592f; // float형은 마지막에 f를 붙여줘야한다.
            Console.WriteLine("fval = " + fval);
            double dval = (double)fval;
            Console.WriteLine("dval = " + dval);
            Console.WriteLine(fval == dval); // 똑같다고 나오는데?
            Console.WriteLine(dval == 3.141592); // 얘는 다르다고 나옴;
            // 형변환을 한다고 해서 overflow가 발생하진 않지만 정밀도가 떨어짐

            // !!-- 정말 중요 --!! 실무에서
            Console.WriteLine("=================================");
            int numival = 1024;
            string strival = numival.ToString(); // numival을 String 으로 바꿔준다
            Console.WriteLine(strival);
            //Console.WriteLine(numival == strival); // 비교 x
            Console.WriteLine(strival.GetType());

            double numdval = 3.14159265358979;
            string strdval = numdval.ToString();
            Console.WriteLine(strdval);

            // 문자열을 숫자로
            // 문자열 내에 숫자가 아닌 특수 문자나 정수인데 . 이 있거나 
            string originstr = "34567890"; // 중간에 소수점 있으면 바로 예외 발생 ## 절대 조심 ##
            int convval = Convert.ToInt32(originstr); //int.Parse() 동일
            Console.WriteLine(convval);
            Console.WriteLine(convval.GetType()); 

            originstr = "1.2345";
            float convfloat = float.Parse(originstr);
            Console.WriteLine(convfloat);
            Console.WriteLine(convfloat.GetType());

            // 예외발생하지 않도록 형변환 방법
            originstr = "123.0f"; // f 들어가면 문자가 들어가있기 때문에 바로 오류남
            float ffval;
            float.TryParse(originstr, out ffval); // 예외 발생하지 않게 숫자 변환
            // 이걸 형변환 할 수 없으면 0 으로 반환해라
            // TryParse는 예외가 발생하면 값은 0 대체, 예외없으면 원래값으로...
            Console.WriteLine(ffval);
            Console.WriteLine(ffval.GetType()); // system.single = float

            // Convert 거의 모든 형 변환 가능 하지만 예외 처리 x
            // TryParse => 예외 처리 가능

            const double pi = 3.14159265358979;
            Console.WriteLine(pi);

            // pi = 4.56; => 절대!! 바뀔 수 없음 상수화 시켰기 때문에

        }
    }
}
