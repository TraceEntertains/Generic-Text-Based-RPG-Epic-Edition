using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Weapon : Item
    {
        [JsonIgnore]
        public static Dictionary<int, (Type Type, Func<Weapon> Creator)> Weapons { get; set; } = new();

        public override ItemTypes ItemType { get; set; } = ItemTypes.Weapon;

        public abstract int Damage { get; set; }
        public abstract double Bonus { get; set; } // interpret as a multiplier

        new public static void RuntimeGetChildren()
        {
            Weapons = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(Weapon).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t =>
            {
                var ctor = t.GetConstructor(Array.Empty<Type>());
                var expr = Expression.New(ctor);
                var lambda = Expression.Lambda<Func<Weapon>>(expr).Compile();
                var placeholder = lambda();

                return (placeholder.ItemID, Type: t, Creator: lambda);
            })
            .ToDictionary(p => p.ItemID, p => (p.Type, p.Creator));
        }

        new public static Weapon GetByID(int id)
        {
            if (Weapons.TryGetValue(id, out (Type Type, Func<Weapon> Creator) value))
            {
                Weapon weapon = value.Creator.Invoke();
                return weapon;
            }
            return null;
        }

        /*public static implicit operator Weapon(SaveWeapon sw)
        {
            Weapon w = GetByID(sw.ID);
            return w;
        }*/
    }
}
