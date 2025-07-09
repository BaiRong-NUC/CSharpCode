// string每次重新赋值或拼接时会分配新的内存空间
// 因此在需要频繁修改字符串的场景下，应该使用StringBuilder(修改字符串不会产生新的对象)
class program
{
    static void Main(string[] args)
    {
        // StringBuilder的使用
        //StringBuilder每次增加内容时会自动扩容
        System.Text.StringBuilder sb = new System.Text.StringBuilder("init", 30); // 初始化StringBuilder，初始容量为30
        sb.Append("Hello");
        sb.Append(" ");
        sb.Append("World");
        sb.AppendLine("!");
        sb.AppendFormat("今天是{0}年{1}月{2}日", 2025, 10, 1);

        // 输出结果
        Console.WriteLine(sb.ToString());
        
        // 清空StringBuilder
        sb.Clear();
        Console.WriteLine("清空后内容: " + sb.ToString()); 
    }
}