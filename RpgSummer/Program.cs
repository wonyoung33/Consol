using System;

namespace SummerRpg
{
    internal class Program
    {

        enum Scene { Select, Confirm, Town, sea, Animal }

        enum race { Cat = 1, Panda, Dog }

        struct GameData
        {
            public bool running;

            public Scene scene;

            public string name;
            public race race;
            public int curHP;
            public int maxHP;
            public int STR;
            public int Charm;
            public int DEX;
            public int Gold;
            public int Animal;
        }

        static GameData data;
        static void Main(string[] args)
        {
            Start();

            while (data.running)
            {
                Run();
            }

            End();
        }

        static void Start()
        {
            data = new GameData();

            data.running = true;

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=          여름의 동물들            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();
        }

        static void End()
        {

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=            게임 종료!            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.Select:
                    SelectScene();
                    break;
                case Scene.Confirm:
                    ConfirmScene();
                    break;
                case Scene.Town:
                    TownScene();
                    break;
                case Scene.sea:
                    seaScene();
                    break;                
            }
        }

        static void printPrrofile()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"이름 : {data.name,-6} 종족 : {data.race,-6}");
            Console.WriteLine($"체력 : {data.curHP,+3} / {data.maxHP}");
            Console.WriteLine($"힘 : {data.STR,-3} 지력 : {data.Charm,-3} 민첩 : {data.DEX,-3}");
            Console.WriteLine($"소지금 : {data.Gold,+5} G");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        static void SelectScene()
        {
            Console.Write("닉네임을 설정해주세요 : ");
            data.name = Console.ReadLine();
            if (data.name == "")
            {
                Console.WriteLine("다시 설정해 주십시요");
                return;
            }

            Console.WriteLine("당신의 종족을 선택해주세요.");
            Console.WriteLine("1. 고양이");
            Console.WriteLine("2. 판다");
            Console.WriteLine("3. 강아지");
            if (int.TryParse(Console.ReadLine(), out int select) == false)
            {
                Console.WriteLine("다시 설정해 주십시요");
                return;
            }
            else if (Enum.IsDefined(typeof(race), select) == false)
            {
                Console.WriteLine("다시 설정해 주십시요");
                return;
            }

            switch ((race)select) // 스테이터스
            {
                case race.Cat:
                    data.race = race.Cat;
                    data.maxHP = 100;
                    data.curHP = data.maxHP;
                    data.STR = 120;
                    data.Charm = 90;
                    data.DEX = 100;
                    data.Gold = 10000;
                    break;
                case race.Panda:
                    data.race = race.Panda;
                    data.maxHP = 300;
                    data.curHP = data.maxHP;
                    data.STR = 50;
                    data.Charm = 120;
                    data.DEX = 0;
                    data.Gold = 1000000;
                    break;
                case race.Dog:
                    data.race = race.Dog;
                    data.maxHP = 120;
                    data.curHP = data.maxHP;
                    data.STR = 30;
                    data.Charm = 50;
                    data.DEX = 50;
                    data.Gold = 36280;
                    break;
            }
            data.scene = Scene.Confirm;
        }
        static void ConfirmScene()
        {
            Console.WriteLine("===================");
            Console.WriteLine($"이름 : {data.name}");
            Console.WriteLine($"종족 : {data.race}");
            Console.WriteLine($"체력 : {data.maxHP}");
            Console.WriteLine($"힘   : {data.STR}");
            Console.WriteLine($"매력 : {data.Charm}");
            Console.WriteLine($"민첩 : {data.DEX}");
            Console.WriteLine($"소지금 : {data.Gold}");
            Console.WriteLine("===================");
            Console.WriteLine();
            Console.Write("이대로 플레이 하시겠습니까?(y/n)");

            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "y":
                    Console.Clear();
                    Console.WriteLine("Loading 중~");
                    Wait(2);
                    data.scene = Scene.Town;
                    break;
                case "N":
                case "n":
                    data.scene = Scene.Select;
                    break;
                default:
                    data.scene = Scene.Confirm;
                    break;
            }
        }

        static void TownScene()
        {
            // Render
            printPrrofile();
            Console.WriteLine("어디로 갈까?");
            Console.WriteLine("어디로 이동하겠습니까?");
            Console.WriteLine("1. 일본");
            Console.WriteLine("2. 중국");
            Console.WriteLine("3. 바다");                        
            Console.Write("선택 : ");

            // Input
            string input = Console.ReadLine();

            // Update
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("일본으로 이동합니다...");
                    Console.WriteLine("추후 개발 예정...");
                    Wait(2);
                    data.scene = Scene.Town;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("중국으로 이동합니다...");
                    Console.WriteLine("추후 개발 예정...");
                    Wait(2);
                    data.scene = Scene.Town;
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("바다로 이동합니다...");
                    Wait(2);                    
                    data.scene = Scene.sea;
                    break;
                    
            }
        }

        static void seaScene()
        {            
            Console.WriteLine("당신은 바다에 도착했습니다.");
            Wait(1);
            Console.WriteLine("푸른하늘 넓은 평야와 해변 이곳이 바다구나!");
            Wait(1);
            Console.WriteLine();
            Console.WriteLine("당신의 행동을 선택해주세요");
            Console.WriteLine("1. 리조트");
            Console.WriteLine("2. 해변");
            Console.WriteLine("3. 夜(밤)");
            Console.Write("선택 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (data.STR > 100)  //고양이 루트
                    {                        
                        Console.WriteLine("당신은 집사의 통장을 털어서 여름휴양지를 사이판 리조트에서 보내게 되었습니다.");
                        Wait(2);
                        Console.WriteLine("집사가 기쁨과 슬픔의 눈물을 동시에 가지게 되었습니다!");
                        Wait(2);
                        Console.WriteLine("3122Km 4시간 비행기를 타고 사이판에 도착했습니다.");
                        Wait(2);
                        Console.WriteLine("싸이판 켄싱턴 호텔에 도착합니다 530000$의 5성급 호텔이라 그런지 눈이 즐겁습니다.");
                        Wait(3);
                        Console.WriteLine("그러나 당신은 고양이 입니다 ^^");
                        Wait(2);
                        Console.WriteLine("당신은 리조트체어에 앉아서 그림같은 풍경을 바라 볼 뿐입니다.");
                        Wait(2);
                        Console.WriteLine("저기봐요~! 집사는 풀에 들어가서 신나게 놀고있네요!");
                        Wait(2);
                        Console.WriteLine("직장 스트레스로 인한 피로를 푸는 모습을 보니 오늘만큼은 (패시브 : 집사괴롭히기)를 하지않기로 다짐합니다.");
                        Wait(4);
                        Console.WriteLine("여기까지 왔는데 물놀이는 하고가야겠다는 당신의 생각이 머릿속에서 순간 무엇을 번뜩이게 만듭니다.");
                        Wait(3);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("프리미어");
                        Console.ResetColor();
                        Console.WriteLine("룸 투숙객만 이용이가능한 전용 풀! 그곳이라면 당신은 물과 싸우지 않고도 의자 하나만 띄워놓고 휴양을 즐길 수 있을것입니다!");
                        Wait(6);
                        Console.WriteLine("저녁이 될때까지 당신은 사이판의 아름다운 전망을 보며 휴양을 보냅니다.");
                        Wait(3);
                        Console.WriteLine("풀에서 야경을보며 그렇게 사이판에서의 하루가 끝나갑니다  저기좀 봐요! 집사는 인스타에 올릴 사진을 찍기위해 음식을 물위에 세팅중이네요!");
                        Wait(6);
                        Console.WriteLine("고양이지만 당신은 (패시브 : 집사괴롭히기)를 하지않기로 다짐했기때문에 츄르를먹으며 야경을 마저 즐깁니다~");
                        Wait(2);
                        Console.WriteLine("당신의지출은 집사통장이기에 없습니다.");
                        Wait(2);
                        Console.WriteLine("Gold -0$");
                        Wait(5);
                        data.Gold -= 0;
                    }
                    else
                    {
                        Console.WriteLine("당신은 푸켓의 리조트에 도착했습니다.");
                        Wait(1);
                        Console.WriteLine("휴양지라 그런지 바다가 아름답네요");
                        Wait(1);
                        Console.WriteLine("그러나 당신은 이미6시간의 비행으로 녹초가 되어있는 상태입니다.");
                        Wait(3);
                        Console.WriteLine("urHP -30");
                        Wait(1);
                        Console.WriteLine("그래도 왔으니까 즐겨야겠죠?");
                        Wait(2);
                        Console.WriteLine("푸른바다");
                        Wait(1);
                        Console.WriteLine("뜨거운태양");
                        Wait(1);
                        Console.WriteLine("아름다운광경");
                        Wait(1);
                        Console.WriteLine("여름이다");
                        Wait(1);
                        Console.WriteLine("당신은 저녁까지 신나게 휴양을 즐기며 푸켓의 하룻밤을 보냅니다...");
                        Wait(4);

                        data.curHP -= 30;
                    }
                    break;
                case "2":                                                    
                    if (data.Charm > 100) //푸바오 루트
                    {
                        Console.WriteLine("당신은 푸바오입니다.");
                        Wait(1);
                        Console.WriteLine("해변을 지나가던 아이바오가 푸바오를보고 안아줍니다.");
                        Wait(2);
                        Console.WriteLine("(아이바오는 푸바오의 엄마 입니다.)");
                        Wait(2);
                        Console.WriteLine("사람들이 푸바오의 존재를 확인하고 모여듭니다.");
                        Wait(2);
                        Console.WriteLine("러바오가 급하게 실시간 방송을 켜서 조회수가 폭주합니다.");
                        Wait(2);
                        Console.WriteLine("(러바오는 푸바오의 아빠입니다.)");
                        Wait(2);
                        Console.WriteLine("실시간 조회수와 후원으로 러바오는 오늘도 기분이 좋습니다.");
                        Wait(2);
                        Console.WriteLine("돈은 러바오의 통장으로입금됩니다.");
                        Wait(2);
                        Console.WriteLine("Gold +100000$ 가족끼리 맛있게 판다 빵을 사 먹었답니다~ ^^");
                        Wait(5);
                        data.Gold += 100000;                        
                    }
                    else
                    {
                        Console.WriteLine("당신은 해변가를 돌아다닙니다.");
                        Wait(1);
                        Console.WriteLine("저 멀리서 푸바오 가족들이 상봉해 있네요!");
                        Wait(1);
                        Console.WriteLine("이런 러바오가 실시간 방송도 켯네요!");
                        Wait(1);
                        Console.WriteLine("(러바오는 푸바오의 아빠입니다.)");
                        Wait(2);
                        Console.WriteLine("당신은 러바오에게 대나무를 건네면서 푸바오가족과의 사진촬영을 부탁합니다.");
                        Wait(3);
                        Console.WriteLine("러바오는 금산의 반짝이는 대나무를 보고 흔쾌히 허락합니다!.");
                        Wait(3);
                        Console.WriteLine("대나무값은 18000원 입니다.");
                        Wait(2);
                        Console.WriteLine("Gold -18000$");
                        Wait(2);
                        Console.WriteLine("당신은 푸바오 가족과의 사진을 인스타에 업로드해서 조회수가 증가했습니다.");
                        Wait(2);
                        Console.WriteLine("당신의 매력이 +10 증가했습니다.");
                        Wait(2);
                        Console.WriteLine("Charm+10");
                        Wait(5);
                        data.Gold -= 18000;
                        data.Charm += 10;
                    }
                    break;
                case "3":
                    Console.WriteLine("밤입니다.");
                    Wait(1);
                    Console.WriteLine("휴양지의 저녁은 여럿불빛들로인해 더욱 아름답죠");
                    Wait(1);
                    Console.WriteLine("아름다운 저녁노을을 지나 여러색들의 불빛이 당신의 밤을 더욱 아름답게 비춰줍니다.");
                    Wait(3);
                    Console.WriteLine("당신은 이 순간 한가지의 생각을 하게됩니다.");
                    Wait(5);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("다음주에 출근해야 되네");
                    Console.ResetColor();
                    Wait(1);
                    data.curHP -= 30;
                    break;
                default:
                    break;
            }

            Console.Clear();
            Console.WriteLine("Loading 중~");
            Wait(2);
            data.scene = Scene.Town;
        }

        
    }
}
