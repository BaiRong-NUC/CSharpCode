using Internal;

/**
在C#中， ref 和 out 都是用于参数传递的关键字，但它们有以下主要区别：

1. 初始化要求 ：
   
   - ref 参数必须在传递前初始化
   - out 参数不需要在传递前初始化
2. 赋值要求 ：
   
   - ref 参数在方法内部可以被读取或修改
   - out 参数在方法内部必须被赋值后才能读取
3. 使用场景 ：
   
   - ref 通常用于需要双向传递数据的场景
   - out 通常用于需要从方法返回多个值的场景
4. 编译器检查 ：
   
   - 编译器会强制检查 out 参数是否在方法内被赋值
   - 对 ref 参数没有这种强制检查

*/
void ModifyWithRef(ref int x)
{
    x++; // 可以直接使用
}

void GetValueWithOut(out int y)
{
    y = 10; // 必须先赋值
    // int z = y;  // 赋值后才能读取
}

// 调用示例
int a = 5;
ModifyWithRef(ref a); // a变为6

int b;
GetValueWithOut(out b); // b被赋值为10

Console.WriteLine($"a的值为:{a}"); // 输出：a的值为：6
Console.WriteLine($"b的值为:{b}"); // 输出：b的值为：10
