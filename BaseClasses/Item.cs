using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Item
    {
        [JsonIgnore]
        public static Dictionary<int, (Type Type, Func<Item> Creator)> Items { get; set; } = new();

        public enum ItemTypes
        {
            Basic,
            Weapon
        }

        public abstract int ItemID { get; set; }
        public abstract ItemTypes ItemType { get; set; }
        public abstract string Name { get; set; }

        public static void RuntimeGetChildren()
        {
            Items = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(Item).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t =>
            {
                var ctor = t.GetConstructor(Array.Empty<Type>());
                var expr = Expression.New(ctor);
                var lambda = Expression.Lambda<Func<Item>>(expr).Compile();
                var placeholder = lambda();

                return (placeholder.ItemID, Type: t, Creator: lambda);
            })
            .ToDictionary(p => p.ItemID, p => (p.Type, p.Creator));
        }

        public static Item GetByID(int id)
        {
            if (Items.TryGetValue(id, out (Type Type, Func<Item> Creator) value))
            {
                Item item = value.Creator.Invoke();
                return item;
            }
            return null;
        }
    }
}
