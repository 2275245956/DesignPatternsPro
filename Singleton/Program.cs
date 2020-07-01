using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //方法1：非多线程下
            //for (int i = 0; i < 10; i++)
            //{
            //    SingletonClass singleton = SingletonClass.GetInstance();
            //    singleton.Show();
            //}

            //方法2：多线程下
            //for (int i = 0; i < 5; i++)
            //{
            //    Task.Run(() =>
            //    {
            //        SingletonClass singleton = SingletonClass.GetInstance();
            //        singleton.Show();
            //    });
            //}

            //方法3：多线程下使用静态构造函数
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    SingletonSecClass singletonSec = SingletonSecClass.GetInstance();
                    singletonSec.Show();
                });
            }

            Console.ReadLine();
        }
    }
}
