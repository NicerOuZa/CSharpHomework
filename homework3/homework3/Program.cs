using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//使用简单工厂模式创建4个图形（三角形、圆形、正方形、长方形），然后计算每个图形的面积。
namespace homework3
{
    //方法一：利用简单工厂模式，基本思路是在工厂类里实现选择，可以通过switch或者if实现，子类继承抽象的形状类来选择，缺点很明显，增加删除图形的时候需要改动工厂类
    public class SimpleShapeFactory
    {

        public Shape creatSimpleShape(string type)
        {
            Shape shape = null;
            if (type.Equals("三角形"))
            {
                shape = new TriShape();
            }
            else if (type.Equals("圆形"))
            {
                shape = new CirShape();
            }
            else if (type.Equals("正方形"))
            {
                shape = new SquShape();
            }
            else if (type.Equals("长方形"))
            {
                shape = new RecShape();
            }
            else
                Console.WriteLine("输入错误！");

            return shape;
        }

  
    }
    public class TriShape : Shape
    {
       
        public override void area()
        {
            Console.WriteLine("TriShape area = 1/2*border*high");
        }
    }
    public class CirShape : Shape
    {
        public override void area()
        {
            Console.WriteLine("CirShape area = PAI*radius*radius");
        }
    }
    public class SquShape : Shape
    {
        public override void area()
        {
            Console.WriteLine("SquShape area = border * border");
        }
    }
    public class RecShape : Shape
    {
        public override void area()
        {
            Console.WriteLine("RecShape area = length*width");
        }
    }
    public abstract class Shape
    {
        public abstract void area();
     
    }
    public class ShapeArea
    {
        SimpleShapeFactory factory;
            public ShapeArea(SimpleShapeFactory factory)
        {
            this.factory = factory;
        }
        public Shape getShapeArea(string type)
        {
            Shape shape;
            shape = factory.creatSimpleShape(type);
            shape.area();
            return shape;
        }
    }
    //方法二：利用工厂模式，不用改工厂代码，需要添加的时候再写一个子类图形和工厂类就可以了,实现了封装，缺点，，，个人认为加两个子类代码量上去了
    public abstract class ShapeFactory
    {
        public abstract Shape CreatShape();
    }
    public class TriShapeFactory : ShapeFactory
    {
        public override Shape CreatShape()
        {
            return new TriShape();
        }
    }
    public class CirShapeFactory : ShapeFactory
    {
        public override Shape CreatShape()
        {
            return new CirShape();
        }
    }
    public class SquShapeFactory : ShapeFactory
    {
        public override Shape CreatShape()
        {
            return new SquShape();
        }
    }
    public class RecShapeFactory : ShapeFactory
    {
        public override Shape CreatShape()
        {
            return new RecShape();
        }
    }
    public class Program
    {
      public  static void Main(string[] args)
        {
            //方法一客户端实现
            string type;
            Console.WriteLine("请输入要求面积的图形形状：");
            type = Console.ReadLine();           
            SimpleShapeFactory factory = new SimpleShapeFactory();
            ShapeArea a = new ShapeArea(factory);
            a.getShapeArea(type);
            //方法二客户端实现
            ShapeFactory TriShapeFactory = new TriShapeFactory();
            Shape TriShapeArea = TriShapeFactory.CreatShape();
            TriShapeArea.area();
            ShapeFactory SquShapeFactory = new SquShapeFactory();
            Shape SquShapeArea = SquShapeFactory.CreatShape();
            SquShapeArea.area();
            ShapeFactory RecShapeFactory = new RecShapeFactory();
            Shape RecShapeArea = RecShapeFactory.CreatShape();
            RecShapeArea.area();
            ShapeFactory CirShapeFactory = new CirShapeFactory();
            Shape CirShapeArea = CirShapeFactory.CreatShape();
            CirShapeArea.area();
            //总结：对于这个作业，其实简单工厂模式很高效，用工厂模式反而复杂化了，工厂模式更多的应用于更复杂的问题：
            //举个例子，pizza，分地区，每个地区又有不同口味，这样，抽象工厂类，地区类继承工厂，地区类里creat方法选择口味，这样地区类和口味类就成了一个简单工厂模式
            //每个地区类继承父类，这样就是工厂模式了
            //还可以利用反射机制

        }
    }

}

