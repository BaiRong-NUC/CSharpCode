/**
1. 接口的规范 interface
    不包含成员变量，只包含方法，属性，索引器，事件
    成员不能实现
    成员方法不能私有，默认公共，接口不能继承类，但可以继承另一个接口
    类可以继承多个接口，类继承接口后必须实现所有的成员
    接口不能实例化，但是可以作为容器存储对象
    接口继承接口后，类继承后需要实现所有的功能
2. 接口的作用
    作为类的附加属性，通过接口可以利用里氏替换原则，提取出类的接口类的功能
*/

interface IFly
{
    void Fly();

    //属性
    string Name { get; set; }

    //索引器
    int this[int index] { get; set; }

    //事件
    event Action doSomething;
}

class Bird : IFly
{
    //子类可以重写Fly函数
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying");
    }

    public string Name { get; set; }

    public int this[int index]
    {
        get { return 0; }
        set { }
    }

    public event Action doSomething;
}

// 显示实现接口
/**
    当一个类继承两个接口时，接口中存在同名方法。
    显示实现接口时不需要写访问修饰符
*/
interface IAtk
{
    void Atk();
}
interface IAtkSuper : IAtk
{
    void Atk();
}

class Player : IAtk, IAtkSuper
{
    // 显示实现接口
    void IAtk.Atk()
    {
        Console.WriteLine("Player IAtk is attacking");
    }

    void IAtkSuper.Atk()
    {
        Console.WriteLine("Player is using super attack");
    }

    void Atk()
    {
        Console.WriteLine("Player is attacking");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bird bird = new Bird();
        bird.Fly(); // 输出: Bird is flying

        IFly flyableBird = bird;
        flyableBird.Fly(); // 也可以通过接口调用,接口也遵守里氏替换原则

        IAtk player = new Player();
        player.Atk(); // 输出: Player IAtk is attacking
        IAtkSuper superPlayer = new Player();
        superPlayer.Atk(); // 输出: Player is using super attack

        Player player = new Player();
        player.Atk(); // 输出: Player is attacking
        (player as IAtk).Atk(); // 输出: Player IAtk is attacking
        (player as IAtkSuper).Atk(); // 输出: Player is using super attack
    }
}