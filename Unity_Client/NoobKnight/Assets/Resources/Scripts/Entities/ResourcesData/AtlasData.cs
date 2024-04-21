using CustomInspector;
using System;
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
