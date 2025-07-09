class Test
{
    public int i = 1;
    public Test2 test2 = new Test2();

    public Test clone()
    {
        return object.MemberwiseClone() as Test; // MemberwiseClone方法用于浅拷贝
    }

    //重写Equals虚方法
    public override bool Equals(object obj)
    {
        if (obj is Test other)
        {
            return this.i == other.i && this.test2.i == other.test2.i;
        }
        return false;
    }

    //重写GetHashCode虚方法
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    //重写ToString虚方法
    public override string ToString()
    {
        return $"自定义 Test: i={i}, test2.i={test2.i}"; // 自定义字符串表示
    }
}
public class Test2
{
    public int i = 2;
}

class Program
{
    static void Main(string[] args)
    {
        // object中的静态方法,Object类是所有类的基类
        Console.WriteLine(object.Equals(1, 1));//判断值类型是否相同
        Console.WriteLine(object.ReferenceEquals(new object(), new object()));//判断引用类型是否相同                                                           //object中的成员方法
        Console.WriteLine(object.GetType());//获取对象的类型,用于反射操作

        Test t = new Test();
        Test t2 = t.clone(); // 浅拷贝,新对象中引用变量和老对象一致
        Console.WriteLine(t.i); // 输出: 1
        Console.WriteLine(t.test2.i); // 输出: 2
        t.i = 3; // 修改原对象的值
        Console.WriteLine(t2.i); // 输出: 1,因为是值类型
        Console.WriteLine(t2.test2.i); // 输出: 2,因为是引用类型,浅拷贝后test2的引用没有改变

        //object中的虚方法
        //1. Equals虚方法，可以自定义比较规则(默认比较引用是否相同)
        //所有的类都可以重写这个方法,自定义比较规则
        //2. 虚方法GetHashCode,可以自定义哈希值(默认是对象的内存地址)
        //3. ToString虚方法,可以自定义字符串表示(默认是对象的类型名称),调用打印时默认调用此方法
        Console.WriteLine(t);
    }
}
