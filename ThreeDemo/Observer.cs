using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeDemo
{
    #region 通过事件实现的观察者模式
    public class EventArgEat : EventArgs
    {
        private string foodName;

        public string FoodName
        {
            get
            {
                return foodName;
            }
        }

        public EventArgEat(string foodName)
        {
            this.foodName = foodName;
        }
    }

    public class AlarmClock
    {
        public delegate void Eat(EventArgEat foodName);
        public event Eat EatEvent;

        public void Run()
        {
            int j = 0;
            while (j<2)
            {
                for (int i = 1; i <= 24; i++)
                {
                    Thread.Sleep(100);
                    switch (i)
                    {
                        case 8:
                            {
                                EatEvent(new EventArgEat("breakfast"));
                            }
                            break;
                        case 13:
                            {
                                EatEvent(new EventArgEat("lunch"));
                            }
                            break;
                        case 18:
                            {
                                EatEvent(new EventArgEat("dinner"));
                            }
                            break;
                    }
                }
                j++;
            }
        }
    }

    public class ReceiveInfo
    {
        public ReceiveInfo(AlarmClock clock)
        {
            clock.EatEvent += new AlarmClock.Eat(this.Clock);
        }

        public void Clock(EventArgEat args)
        {
            Console.WriteLine(args.FoodName);
        }

    }
    #endregion

    #region 简单的观察者模式
    public class Oberver
    {
        private string info;
        public Oberver(string info)
        {
            this.info = info;
        }

        public void GetInfomation()
        {
            Console.WriteLine(info);
        }

    }

    public class BeenObserved
    {
        private Oberver observer;

        private void SendInfomation(string info)
        {
            observer = new Oberver(info);
            observer.GetInfomation();
        }

        public void Run()
        {
            int i = 0;
            while (i<50)
            {
                if (i++ % 2 == 0)
                {
                    Thread.Sleep(100);
                    SendInfomation($"消息{i}来了");
                }
            }
        }
    }
    #endregion

    #region 常用的观察者模式

    public interface IObserved
    {
        void Notify();

    }

    public class ObserverOne : IObserved
    {
        public void Notify()
        {
            Console.WriteLine("1 到");
        }

    }

    public class ObserverTwo : IObserved
    {
        public void Notify()
        {
            Console.WriteLine("2 到");
        }

    }



    public class BeenObservedT
    {
        private List<IObserved> ObservedList = new List<IObserved>();

        public void AddObserved(IObserved ob)
        {
            ObservedList.Add(ob);
        }

        public void DelObserved(IObserved ob)
        {
            ObservedList.Remove(ob);
        }

        public void PublishInfo()
        {
            int i = 0;
            while (i<50)
            {
                if (i++ % 2 == 0)
                {
                    Thread.Sleep(1000);
                    SendInfomation($"消息{i}来了");
                }
            }
        }

        private void SendInfomation(string info)
        {
            Parallel.ForEach(ObservedList,item=>
            {
                item.Notify();
            });
        }

    }

    #endregion

}
