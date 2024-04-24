using CustomInspector;
using NoobKnight.Utils;
using System;
using UnityEngine;
using UnityEngine.U2D;

namespace NoobKnight.Entities
{
    [Serializable]
    public class AtlasData 
    {
        [Dictionary]
        public SerializableDictionary<string, SpriteAtlas> dictAtlases = new SerializableDictionary<string, SpriteAtlas>();
    }
}
