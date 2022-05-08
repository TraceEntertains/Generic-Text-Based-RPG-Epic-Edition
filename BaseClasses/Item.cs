using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Item
    {
        [JsonIgnore]
        public static List<Item> Items { get; set; } = new();

        public enum ItemTypes
        {
            Basic,
            Weapon
        }

        public Item()
        {
            Items.Add(this);
        }

        public abstract ItemTypes ItemType { get; set; }
        public abstract string Name { get; set; }
        public abstract int ID { get; set; }

        public static Item GetByID(int id)
        {
            foreach (var item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
