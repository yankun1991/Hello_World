using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDemo
{
    public class SingletonCurrency
    {
        private static SingletonCurrency _singleton = new SingletonCurrency();

        private SingletonCurrency() { }

        public static SingletonCurrency GetInstance()
        {
            return _singleton;
        }

    }

    public class SingletonNotSafe
    {
        private static SingletonNotSafe _instance = null;
        private SingletonNotSafe() { }

        public static int count=0;
        public static SingletonNotSafe GetInstance()
        {
            if (_instance == null)
            {
                count++;
                _instance = new SingletonNotSafe();
            }
            return _instance;
        }
    }

    public class SingletonSafe
    {
        private volatile static SingletonSafe _instance = null;
        private static readonly object lockHelper = new object();
        public static int count = 0;
        private SingletonSafe() { }
        public static SingletonSafe GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        count++;
                        _instance = new SingletonSafe();
                    }
                }
            }
            return _instance;
        }
    }
}
