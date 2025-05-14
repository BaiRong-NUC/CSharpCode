using Internal;

Person p = new Person();
p.Name = "Tom";
Console.WriteLine(p.Name);

class Person
{
    private string name;
    private int age;
    public string Name
    {
        /**
            1.默认不加 会使用属性申明时的访问权限
            2.加的访问修饰符要低于属性的访问权限
            3.不能让get和set的访问权限都低于属性的权限
        */
        get { return name; }
        set
        {
            //value 是一个关键字，用于表示属性的新值，在set访问器中使用，用于设置属性的新值，外部传入的值。
            //类型是string
            name = value;
        }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    //自动属性
    public float Height { get; private set; }
}
