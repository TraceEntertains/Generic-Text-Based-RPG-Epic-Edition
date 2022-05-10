using Generic_Text_Based_RPG_Epic_Edition.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Enemy
    {
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }
        public abstract int Health { get; set; }
        public abstract int Defense { get; set; }
        public abstract int CoinBonus { get; set; }
        public abstract int XP { get; set; }
        public abstract bool IsBoss { get; set; }
        public abstract int ID { get; set; }

        public static Random Rand { get; set; } = new();

        public static Dictionary<int, (Type Type, Func<Enemy> Creator)> Enemies { get; set; } = new();

        public abstract void StartBattle();
        public abstract void PreBattle();

        public static implicit operator Enemy(SaveEnemy se)
        {
            Enemy e = GetByID(se.ID);
            e.Power = se.Power;
            e.Health = se.Health;
            e.Defense = se.Defense;
            e.CoinBonus = se.CoinBonus;
            e.XP = se.XP;
            return e;
        }

        public abstract void PostBattle(bool bonusCoins = false, int coinBonus = 0);

        public static void RuntimeGetChildren()
        {
            Enemies = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(Enemy).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t =>
            {
                var ctor = t.GetConstructor(Array.Empty<Type>());
                var expr = Expression.New(ctor);
                var lambda = Expression.Lambda<Func<Enemy>>(expr).Compile();
                var placeholder = lambda();

                return (placeholder.ID, Type: t, Creator: lambda);
            })
            .ToDictionary(p => p.ID, p => (p.Type, p.Creator));
        }

        public static Enemy GetByID(int id)
        {
            if (Enemies.TryGetValue(id, out (Type Type, Func<Enemy> Creator) value))
            {
                Enemy enemy = value.Creator.Invoke();
                return enemy;
            }
            return null;
        }
    }
}
