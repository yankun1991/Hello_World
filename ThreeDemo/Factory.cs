using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDemo
{
    public interface IProduct
    {
        void CreateProductA();
        void CreateProductB();
    }
    public  class ProductOne : IProduct
    {
        public void CreateProductA()
        {
            Console.WriteLine("创建产品OneA");
        }

        public void CreateProductB()
        {
            Console.WriteLine("创建产品OneB");
        }
    }

    public  class ProductTwo : IProduct
    {
        public void CreateProductA()
        {
            Console.WriteLine("创建产品TwoA");
        }

        public void CreateProductB()
        {
            Console.WriteLine("创建产品TwoB");
        }
    }

    public abstract class AbFactory
    {
        public abstract void GetProductA();
        public abstract void GetProductB();
    }

    public class ProductFactoryOne: AbFactory
    {
        private static IProduct _po = new ProductOne();
        public override void GetProductA()
        {
            _po.CreateProductA();

        }

        public override void GetProductB()
        {
            _po.CreateProductB();
        }
    }

    public class ProductFactoryTwo: AbFactory
    {
        private static IProduct _po = new ProductTwo();

        public override void GetProductA()
        {
            _po.CreateProductA();
        }

        public override void GetProductB()
        {
            _po.CreateProductB();
        }
    }

    public class Factory
    {
        public  void GetProductA(AbFactory _abFactoryOne)
        {
            _abFactoryOne.GetProductA();
        }

        public  void GetProductB(AbFactory _abFactoryOne)
        {
            _abFactoryOne.GetProductB();
        }
    }

}
