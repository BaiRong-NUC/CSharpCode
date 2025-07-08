/**
1. 密封类 sealed修饰的类，表示这个类不能被继承
2. 密封方法 sealed修饰的方法，让虚方法或抽象方法不能被重写，和override修饰符一起使用
*/

abstract class Animal
{
    public string name;

    public abstract void Eat();

    public virtual void Sleep()
    {
        Console.WriteLine($"{name} is sleeping");
    }
}

class Dog : Animal
{
    //后序继承Dog的子类不能重写下面两个方法
    public sealed override void Eat()
    {
        throw new System.NotImplementedException();
    }

    public sealed override void Sleep()
    {
        base.Sleep();
    }
}