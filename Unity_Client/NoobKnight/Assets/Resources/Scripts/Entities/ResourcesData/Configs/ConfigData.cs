using CustomInspector;
using NoobKnight.Utils;
using System;
using UnityEngine;

namespace NoobKnight.Entities
{
    [Serializable]
    public class ConfigData
    {
        [Dictionary]
        public SerializableDictionary<string, ScriptableObject> dictConfigs = new SerializableDictionary<string, ScriptableObject>();

        public T GetConfigByID<T>(int ID) where T : ScriptableObject
        {
            ItemType itemType = ConvertService.GetItemTypeByID(ID);
            switch (itemType)
            {
                case ItemType.Appearance:
                    return (T) dictConfigs.GetValue("Config" + itemType);
                default:
                    return null;
            }
        }
    }
}
