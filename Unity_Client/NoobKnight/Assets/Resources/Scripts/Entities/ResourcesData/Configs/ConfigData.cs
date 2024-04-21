using CustomInspector;
using System;
using UnityEngine;

namespace NoobKnight.Entities
{
    [Serializable]
    public class ConfigData
    {
        [Dictionary]
        public SerializableDictionary<string, ScriptableObject> dictConfigs = new SerializableDictionary<string, ScriptableObject>();
    }
}
