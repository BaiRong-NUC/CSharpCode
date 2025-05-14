using Internal;

Person p = new Person();
p[0] = new Person();
p[0].name = "Tom";
Console.WriteLine(p[0].name);

//让对象可以像数组一样通过下标访问其中的元素
class Person
{
    // private int age;
    public string name { get; set; }
    private Person[] friends = null;

    //索引器
    public Person this[int index]
    {
        get { return friends[index]; }
        set
        {
            if (this.friends == null)
            {
                this.friends = new Person[] { value };
                return;
            }
            else if (index < friends.Length && index >= 0)
            {
                friends[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    //索引器可以重载
}
