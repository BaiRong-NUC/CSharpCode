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
        public int[] _bossPos = { 24, 12 };
        public int[] _bossAtkRange = { 7, 13 };
        public int _bossHp = 100;
        public string _bossIcon = "■";
        public ConsoleColor _bossColor = ConsoleColor.Green;
    }
    class Player
    {
        //玩家信息
        public int[] _playerPos = { 6, 5 };
        public int _playerHp = 100;
        public string _playerIcon = "●";
        public ConsoleColor _playerColor = ConsoleColor.Yellow;
        public int[] _playerAtkRange = { 1, 13 };
    }
    class Program
    {
        static int _gameWeith = 50;
        static int _gameHeight = 30;
        //场景id
        static int _sceneId = 1;

        //boss信息
        static Boss _bossInfo=new Boss();

        static Player _playerInfo = new Player();

        //当前是否战斗
        static bool _isFight = false;

        //提示信息，当玩家到boss旁提示
        static string _msg = "";
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

        //判断玩家是否与boss相邻
        static bool _IsAdjust()
        {
            int[] playerPos = _playerInfo._playerPos;
            int[] bossPos = _bossInfo._bossPos;
            if ((playerPos[0] == bossPos[0] && Math.Abs(playerPos[1] - bossPos[1]) == 1) || playerPos[1] == bossPos[1] && Math.Abs(playerPos[0] - bossPos[0]) == 2) 
            {
                return true;
            }
            return false;
        }

        //擦除信息,从row col位置开始，长度为2*length
        static void _ClearMsg(int row,int col,int length)
        {
            for (int begin = row; begin <= length; begin++)
            {
                Console.SetCursorPosition(begin, col);
                Console.Write(" ");
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
                //画boss
                if (_bossInfo._bossHp > 0)
                {
                    Console.SetCursorPosition(_bossInfo._bossPos[0], _bossInfo._bossPos[1]);
                    Console.ForegroundColor = _bossInfo._bossColor;
                    Console.Write(_bossInfo._bossIcon);
                }
                //画玩家
                Console.SetCursorPosition(_playerInfo._playerPos[0], _playerInfo._playerPos[1]);
                Console.ForegroundColor = _playerInfo._playerColor;
                Console.Write(_playerInfo._playerIcon);
                //检测玩家输入
                char input = Console.ReadKey(true).KeyChar;
                if (_isFight == false)
                {
                    //非战斗状态
                    //擦除之前的位置
                    Console.SetCursorPosition(_playerInfo._playerPos[0], _playerInfo._playerPos[1]);
                    Console.Write("  ");
                    //改位置
                    switch (input)
                    {
                        case 'W':
                        case 'w':
                            _playerInfo._playerPos[1] -= 1;
                            if (_playerInfo._playerPos[1] < 1)
                            {
                                _playerInfo._playerPos[1] = 1;
                            }
                            if (_playerInfo._playerPos[0] == _bossInfo._bossPos[0] && _playerInfo._playerPos[1] == _bossInfo._bossPos[1] && _bossInfo._bossHp > 0)
                            {
                                _playerInfo._playerPos[1] += 1;
                            }
                            break;
                        case 'S':
                        case 's':
                            _playerInfo._playerPos[1] += 1;
                            if (_playerInfo._playerPos[1] >= _gameHeight - 7)
                            {
                                _playerInfo._playerPos[1] -= 1;
                            }
                            if (_playerInfo._playerPos[0] == _bossInfo._bossPos[0] && _playerInfo._playerPos[1] == _bossInfo._bossPos[1] && _bossInfo._bossHp > 0)
                            {
                                _playerInfo._playerPos[1] -= 1;
                            }
                            break;
                        case 'A':
                        case 'a':
                            _playerInfo._playerPos[0] -= 2;
                            if (_playerInfo._playerPos[0] < 2)
                            {
                                _playerInfo._playerPos[0] = 2;
                            }
                            if (_playerInfo._playerPos[0] == _bossInfo._bossPos[0] && _playerInfo._playerPos[1] == _bossInfo._bossPos[1] && _bossInfo._bossHp > 0)
                            {
                                _playerInfo._playerPos[0] += 2;
                            }
                            break;
                        case 'D':
                        case 'd':
                            _playerInfo._playerPos[0] += 2;
                            if (_playerInfo._playerPos[0] >= _gameWeith - 2)
                            {
                                _playerInfo._playerPos[0] -= 2;
                            }
                            if (_playerInfo._playerPos[0] == _bossInfo._bossPos[0] && _playerInfo._playerPos[1] == _bossInfo._bossPos[1] && _bossInfo._bossHp > 0)
                            {
                                _playerInfo._playerPos[0] -= 2;
                            }
                            break;
                        //开始战斗
                        case 'J':
                        case 'j':
                            //变为战斗状态
                            _isFight = true;
                            if (_bossInfo._bossHp > 0 && _IsAdjust() == true)
                            {
                                Console.SetCursorPosition(2, _gameHeight - 4);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("当前玩家血量{0}", _playerInfo._playerHp);
                            }
                            break;
                    }
                    if (_bossInfo._bossHp > 0 && _IsAdjust() == true)
                    {
                        //相邻时修改提示信息
                        _msg = "战斗开始，请按J键攻击";
                    }
                    else
                    {
                        //不相邻清空提示
                        _ClearMsg(2, _gameHeight - 5, _msg.Length * 2);
                        _msg = "";
                    }
                    //打印提示
                    Console.SetCursorPosition(2, _gameHeight - 5);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(_msg);
                }
                else
                {
                    //战斗状态
                    if (input == 'J' || input == 'j')
                    {
                        //判断当前血量是否结束游戏
                        if (_playerInfo._playerHp <= 0 || _bossInfo._bossHp <= 0)
                        {
                            if (_playerInfo._playerHp <= 0)
                            {
                                //跳转游戏结束场景
                                _sceneId = 3;
                                break;
                            }
                            else
                            {
                                //玩家胜利，擦除boss                           
                                Console.SetCursorPosition(_bossInfo._bossPos[0], _bossInfo._bossPos[1]);
                                Console.Write("  ");
                                _isFight = false;
                                //break;
                            }
                        }
                        else
                        {
                            //随机攻击力
                            Random random = new Random();
                            int playerAtk = random.Next(_playerInfo._playerAtkRange[0], _playerInfo._playerAtkRange[1]);
                            //boss血量减少
                            _bossInfo._bossHp -= playerAtk;
                            //打印信息
                            //擦除原有位置的信息,这里20是当前玩家血量{0}的大概长度，硬编码
                            _ClearMsg(2, _gameHeight - 4, 40);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(2, _gameHeight - 4);
                            Console.Write("玩家造成{0}点伤害，boss剩余血量{1}", playerAtk, _bossInfo._bossHp);

                            if (_bossInfo._bossHp > 0)
                            {
                                //boss攻击
                                int bossAtk = random.Next(_bossInfo._bossAtkRange[0], _bossInfo._bossAtkRange[1]);
                                //玩家血量减少
                                _playerInfo._playerHp -= bossAtk;
                                _ClearMsg(2, _gameHeight - 3, 40);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, _gameHeight - 3);
                                Console.Write("boss造成{0}点伤害，玩家剩余血量{1}", bossAtk, _playerInfo._playerHp);
                                if( _playerInfo._playerHp <= 0)
                                {
                                    //boss胜利
                                    _ClearMsg(2, _gameHeight - 3, 40);
                                    Console.SetCursorPosition(2, _gameHeight - 3);
                                    Console.Write("玩家死亡，游戏结束!");
                                }
                            }
                            else
                            {
                                //玩家胜利擦除战斗信息
                                _ClearMsg(2, _gameHeight - 5, 40);
                                _ClearMsg(2, _gameHeight - 4, 40);
                                _ClearMsg(2, _gameHeight - 3, 40);
                                Console.SetCursorPosition(2, _gameHeight - 4);
                                Console.Write("玩家胜利，快前往公主前按J继续！");
                            }
                        }
                    }
                }
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
