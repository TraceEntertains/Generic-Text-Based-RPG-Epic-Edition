using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Generic_Text_Based_RPG_Epic_Edition.BaseClasses.Item;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public struct SaveVarStorage
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
    }

    public static class ConverterHelpers
    {
        public static void WritePolymorphicData<TWriteClass>(ref Utf8JsonWriter writer, TWriteClass mainvar, string idType)
        {
            foreach (var members in mainvar.GetType().GetProperties())
            {
                if (members.Name != idType)
                {
                    switch (members.PropertyType.Name)
                    {
                        case "String":
                            writer.WriteString(members.Name, (string)members.GetValue(mainvar));
                            break;
                        case "Int32":
                        case "ItemTypes":
                            writer.WriteNumber(members.Name, (int)members.GetValue(mainvar));
                            break;
                        case "Boolean":
                            writer.WriteBoolean(members.Name, (bool)members.GetValue(mainvar));
                            break;
                        case "Double":
                            writer.WriteNumber(members.Name, (double)members.GetValue(mainvar));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static TPropertyType PropertySetter<TPropertyType>(ref Utf8JsonReader reader, string idType, TPropertyType deserialized) where TPropertyType : class
        {
            string? propertyName;

            propertyName = reader.GetString();
            reader.Read();
            PropertyInfo propertyStuff = deserialized.GetType().GetProperty(propertyName);
            Type propertyType = propertyStuff.PropertyType;

            if (propertyName != idType)
            {
                switch (propertyType.Name)
                {
                    case "String":
#if DEBUG
                        Console.WriteLine(propertyStuff.Name + " (" + propertyType.Name + ")" + ": " + reader.GetString());
#endif
                        propertyStuff.SetValue(deserialized, reader.GetString());
                        break;
                    case "Int32":
                    case "ItemTypes":
#if DEBUG
                        Console.WriteLine(propertyStuff.Name + " (" + propertyType.Name + ")" + ": " + reader.GetInt32());
#endif
                        propertyStuff.SetValue(deserialized, reader.GetInt32());
                        break;
                    case "Boolean":
#if DEBUG
                        Console.WriteLine(propertyStuff.Name + " (" + propertyType.Name + ")" + ": " + reader.GetBoolean());
#endif
                        propertyStuff.SetValue(deserialized, reader.GetBoolean());
                        break;
                    case "Double":
#if DEBUG
                        Console.WriteLine(propertyStuff.Name + " (" + propertyType.Name + ")" + ": " + reader.GetDouble());
#endif
                        propertyStuff.SetValue(deserialized, reader.GetDouble());
                        break;
                    default:
#if DEBUG
                        Console.WriteLine(propertyStuff.Name + " (" + propertyType.Name + "/Unimplemented)" + ": " + reader.GetString());
#endif
                        break;
                }
            }

            return deserialized;
        }
    }

    public class ItemConverter : JsonConverter<Item>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Item).IsAssignableFrom(typeToConvert);

        public override Item Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Item? deserialized;

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = reader.GetString();
            if (propertyName != "ItemID")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            deserialized = GetByID(reader.GetInt32());

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject || JsonTokenType.StartObject == reader.TokenType)
                {
                    return deserialized;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                   ConverterHelpers.PropertySetter(ref reader, "ItemID", deserialized);
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Item item, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteNumber("ItemID", item.ItemID);

            ConverterHelpers.WritePolymorphicData(ref writer, item, "ItemID");

            writer.WriteEndObject();
        }
    }

    public class EnemyConverter : JsonConverter<Enemy>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Enemy).IsAssignableFrom(typeToConvert);

        public override Enemy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Enemy? deserialized;

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = reader.GetString();
            if (propertyName != "EnemyID")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            deserialized = Enemy.GetByID(reader.GetInt32());

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject || JsonTokenType.StartObject == reader.TokenType)
                {
                    return deserialized;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    ConverterHelpers.PropertySetter(ref reader, "EnemyID", deserialized);
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Enemy enemy, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteNumber("EnemyID", enemy.EnemyID);

            ConverterHelpers.WritePolymorphicData(ref writer, enemy, "EnemyID");

            writer.WriteEndObject();
        }
    }
}
