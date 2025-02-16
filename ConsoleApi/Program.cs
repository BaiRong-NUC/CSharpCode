using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApi
{
    class Program
    {
        //C# 控制台相关API与随机数
        static void Main(string[] args)
        {
            #region 控制台输入输出
            //控制台输出
            //Console.WriteLine("Hello World");//光标空行
            //Console.Write("Hello World", "Hello World");//光标不空行
            //控制台输入
            //string str=Console.ReadLine();//等待用户输入，并返回输入的字符串

            ////true表示不回显，false表示回显
            //char ch= Console.ReadKey(true).KeyChar;//等待用户输入，并返回输入的字符
            //Console.WriteLine("不回显"+ch);
            #endregion

            #region 控制台大小颜色
            Console.WriteLine("Hello C#");
            //1. 控制台清空
            Console.Clear();
            //2. 设置控制台窗口大小 缓冲区大小
            //  1. 先设置窗口大小，在设置缓冲区大小
            //  2. 缓冲区大小不能小于窗口大小
            //  3. 窗口大小不能大于控制台的最大尺寸
            //3. 设置窗口大小
            Console.SetWindowSize(100, 50);
            //4. 设置缓冲区大小
            Console.SetBufferSize(100, 50);
            //5. 设置光标位置
            //  1. 控制台左上角为原点0，0 右侧是x正方向，下方是y正方向
            //  2. 注意边界，视觉上y=2x的长度
            Console.SetCursorPosition(20, 10);
            //6. 设置颜色
            //  1.文字颜色
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello World");
            //  2. 设置背景颜色
            //Console.BackgroundColor= ConsoleColor.White;
            Console.Clear();
            //7. 光标显隐
            Console.CursorVisible = false;//光标隐藏
            //8. 关闭控制台
            //Environment.Exit(0);
            #endregion

            #region 随机数
            Random numbers = new Random();
            int num = numbers.Next();//生成非负数随机数
            Console.WriteLine(num);
            num=numbers.Next(100);//生成0-99之间的随机数
            Console.WriteLine(num);
            num = numbers.Next(100, 200);//生成100-199之间的随机数
            Console.WriteLine(num);
            #endregion
        }
    }
}
