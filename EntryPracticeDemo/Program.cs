using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPracticeDemo
{
    class Boss
    {
        //boss信息
        public int[] _bossPos = { 24, 13 };
        public int[] _bossAtkRange = { 7, 13 };
        public int _bossHp = 100;
        public string _bossIcon = "■";
        public ConsoleColor _bossColor = ConsoleColor.Green;
    }
    class Program
    {
        static int _gameWeith = 50;
        static int _gameHeight = 30;
        //场景id
        static int _sceneId = 1;

        //boss信息
        static Boss _bossInfo=new Boss();

        //初始化游戏参数
        static void InitGame()
        {
            //隐藏光标
            Console.CursorVisible = false;
            //设置舞台大小
            Console.SetWindowSize(_gameWeith,_gameHeight);
            Console.SetBufferSize(_gameWeith, _gameHeight);
        }

        //打印游戏边界
        static void _PrintGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < _gameWeith; i += 2)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, _gameHeight - 2);
                Console.Write("■");
                Console.SetCursorPosition(i, _gameHeight - 7);
                Console.Write("■");
            }
            for (int i = 0; i < _gameHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(_gameWeith - 2, i);
                Console.Write("■");
            }
        } 

        //开始游戏场景
        static void BeginGameMenue()
        {
            Console.SetCursorPosition(_gameWeith/ 2-7, 8);
            Console.Write("控 制 台 游 戏");
            //持续处理用户输入
            int select = 0;//0表示开始游戏，1表示退出游戏
            while (true)
            {
                Console.SetCursorPosition(_gameWeith / 2 - 4, 11);
                Console.ForegroundColor = select == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("开始游戏");

                Console.SetCursorPosition(_gameWeith / 2 - 4, 13);
                Console.ForegroundColor = select == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("退出游戏");
                char input = Console.ReadKey(true).KeyChar;
                switch (input)
                {
                    case 'W':
                    case 'w':
                        select = (select + 1) % 2;
                        break;
                    case 'S':
                    case 's':
                        select -= 1;
                        if (select < 0)
                        {
                            select = 1;
                        }
                        break;
                    case 'J':
                    case 'j':
                        //跳转场景
                        if (select == 0)
                        {
                            //跳转到游戏场景
                            _sceneId = 2;
                        }
                        else
                        {
                            //退出游戏
                            Environment.Exit(0);
                        }
                        break;
                }
                if(_sceneId != 1)
                {
                    //场景要切换
                    break;
                }
            }
        }
         
        //游戏场景
        static void GameScene()
        {
            //打印游戏边界
            _PrintGame();
            while (true)
            {
                Console.SetCursorPosition(_bossInfo._bossPos[0], _bossInfo._bossPos[1]);
                Console.ForegroundColor = _bossInfo._bossColor;
                Console.Write(_bossInfo._bossIcon);
            }
        }

        static void Main(string[] args)
        {
            InitGame();

            while (true)
            {
                switch (_sceneId)
                {
                    //开始游戏菜单
                    case 1:
                        Console.Clear();
                        BeginGameMenue();
                        break;
                    //游戏场景
                    case 2:
                        Console.Clear();
                        GameScene();
                        break;
                    //结束场景
                    case 3:
                        Console.Clear();
                        Console.WriteLine("游戏结束");
                        break;
                }
            }
        }
    }
}
