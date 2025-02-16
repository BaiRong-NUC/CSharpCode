using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPracticeDemo
{
    class Program
    {
        static int _gameWeith = 50;
        static int _gameHeight = 30;
        //初始化游戏参数
        static void InitGame()
        {
            //隐藏光标
            Console.CursorVisible = false;
            //设置舞台大小
            Console.SetWindowSize(_gameWeith,_gameHeight);
            Console.SetBufferSize(_gameWeith, _gameHeight);
        }
        static void Main(string[] args)
        {
            InitGame();
        }
    }
}
