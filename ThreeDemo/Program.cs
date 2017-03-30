using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDemo
{

    public delegate void Play();
    class Program
    {
        static void Main(string[] args)
        {

            #region 单例模式
            Parallel.For(0, 100, item =>
            {
                SingletonSafe.GetInstance();
                if (SingletonSafe.count > 1)
                {
                    Console.WriteLine(SingletonNotSafe.count);
                }
            });
            Console.WriteLine("over");
            #endregion


            #region 事件与委托
            AlarmClock clock = new AlarmClock();
            ReceiveInfo rec = new ReceiveInfo(clock);
           //  clock.Run();
            #endregion


            #region 观察者模式One
            BeenObserved bee = new BeenObserved();
            //   bee.Run();
            #endregion

            #region 观察者模式Two

            BeenObservedT bot = new BeenObservedT();
            bot.AddObserved(new ObserverOne());
            bot.AddObserved(new ObserverTwo());
            //   bot.PublishInfo();
            #endregion

            Play play = new Play(clock.Run);
            play += bee.Run;
            play += bot.PublishInfo;
           // play.Invoke();
           // IAsyncResult result = play.BeginInvoke(null,null);
           // play.EndInvoke(result);
           //IAsyncResult result = play.BeginInvoke(new AsyncCallback(CallBack), "AsycState:OK");

            #region 抽象工厂模式
            Factory abFactory = new Factory();
            abFactory.GetProductA(new ProductFactoryOne());
            abFactory.GetProductB(new ProductFactoryTwo());
            #endregion
            Console.ReadKey();
        }

        public static void CallBack(IAsyncResult result)
        {
            Play handler = (Play)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
            Console.WriteLine(result.AsyncState);
        }
    }
}
