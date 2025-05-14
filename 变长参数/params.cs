using System;

//params 关键字用于定义方法参数，它允许方法接受任意数量的参数

/**
- 允许方法接受可变数量的参数
- 必须是方法的最后一个参数
- 参数类型必须是一维数组
*/

// 计算任意数量整数的和
int Sum(params int[] numbers)
{
    int sum = 0;
    foreach (int num in numbers)
    {
        sum += num;
    }
    return sum;
}

// 调用方式1：直接传递多个参数
Console.WriteLine(Sum(1, 2, 3)); // 输出6

// 调用方式2：传递数组
int[] nums = { 4, 5, 6, 7 };
Console.WriteLine(Sum(nums)); // 输出22

// 调用方式3：不传参数
Console.WriteLine(Sum()); // 输出0
