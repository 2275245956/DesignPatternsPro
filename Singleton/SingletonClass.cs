using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class SingletonClass
    {

        public static SingletonClass _singleton = null;
        public static readonly object lockObj = new object();

        public void Show()
        {

            Console.WriteLine("Singleton............");
        }
        public static SingletonClass GetInstance()
        {
            ///方法1： 多线程下不可取
            //if (_singleton == null)
            //{
            //    _singleton = new SingletonClass();
            //}
            ///方法2： 双重if 加锁的方式
            if (_singleton == null)
            {

                lock (lockObj)
                {
                    if (_singleton == null)
                    {
                        _singleton = new SingletonClass();
                    }
                }
            }



            return _singleton;

        }
        private SingletonClass()
        {
            var IResult = 0L;
            for (int i = 0; i < 1000000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine("SingletonClass被构造。。。。。。。");
        }

    }



    ///方法3： 采用静态构造方法   
    ///静态构造方法 CLR会保证改方法只会构造一次
    public sealed class SingletonSecClass
    {
        public static SingletonSecClass _singletonSec = null;

        private SingletonSecClass()
        {
            var IResult = 0L;
            for (int i = 0; i < 1000000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine("SingletonSecClass被构造。。。。。。。");

        }

        static SingletonSecClass()
        {
            _singletonSec = new SingletonSecClass();
        }

        public static SingletonSecClass GetInstance()
        {
            return _singletonSec;
        }
        public void Show()
        {
            Console.WriteLine("Singleton............");
        }
    }
}
