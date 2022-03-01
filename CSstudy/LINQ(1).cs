using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSstudy
{
    public enum ClassType
    {
        Knight, Archer, Mage
    }

    public class Player
    { 
        public ClassType ClassType { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
    }

    internal class Program
    {
        static List<Player> _players = new List<Player>();

        static void Main(string[] args)
        {

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                ClassType type = ClassType.Knight;
                switch (rand.Next(0, 3))
                { 
                    case 0:
                        type = ClassType.Archer;
                        break;

                    case 1: 
                        type = ClassType.Mage;
                        break;

                    case 2:
                        type = ClassType.Knight;
                       break;
                }

                Player player = new Player()
                {
                    ClassType = type,
                    Level = rand.Next(1, 100),
                    Hp = rand.Next(100, 1000),
                    Attack = rand.Next(5, 50)
                };

                _players.Add(player);
            }

            // 일반 버전
            // 0) 레벨이 50 이상인 Knight만 추려내서, 레벨을 오름차순 정렬
            {
                List<Player> players = GetHighLevelKnights();
                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Level}, {p.Hp}");
                }
            }

            // LINQ 버전 from (Foreach), where 필터역할
            // orderby 기본적으로 ascending 
            // select 최종 결과 추출 -> 가공해서 추출도 가능
            {
                var players =
                    from p in _players
                    where p.ClassType == ClassType.Knight && p.Level >= 50
                    orderby p.Level // ascending, descending
                    select p;
                // select new {Hp = p.Hp, Level = p.Level * 2 };

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Level}, {p.Hp}");
                }
            }
        }

        static public List<Player> GetHighLevelKnights()
        {
            List<Player> players = new List<Player>();

            foreach(Player player in _players)
            {
                if (player.ClassType != ClassType.Knight)
                    continue;
                if (player.Level < 50)
                    continue;

                players.Add(player);
            }

            players.Sort((lhs, rhs) => { return lhs.Level - rhs.Level; });
            return players;
        }
    }

    // Unity 할때는 굳이 LINQ를 사용하지 않고 예전에는 ios관련 버그가 있었음
    // WebServer에서만 활용

    // Database와 연동해서 데이터를 뽑아온다거나 할 때 MS에서 제품들이 어느정도 호환이됨
    // 간단하게 LINQ로만 질의를 했더니 실제로 DB에서 데이터를 추출하거나 하는 기술들이 있음
    // 편하게 사용할 수 있는 기술들이 많이 있음
}
