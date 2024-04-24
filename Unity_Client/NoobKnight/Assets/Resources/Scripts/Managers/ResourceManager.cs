using NoobKnight.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using NoobKnight.Utils;

namespace NoobKnight.Managers
{
    public class ResourceManager : MonoBehaviour
    {
        public AtlasData AtlasData = new AtlasData();
        public ConfigData ConfigData = new ConfigData();

        public async Task LoadResourcesAsync()
        {
            AsyncOperationHandle<IList<SpriteAtlas>> handleAtlases = Addressables.LoadAssetsAsync<SpriteAtlas>("Atlases", null);
            await handleAtlases.Task;

            if (handleAtlases.Status == AsyncOperationStatus.Succeeded)
            {
                foreach (var atlas in handleAtlases.Result)
                {
                    AtlasData.dictAtlases.Add(atlas.name, atlas);
                }
            }

            AsyncOperationHandle<IList<ScriptableObject>> handleConfigs = Addressables.LoadAssetsAsync<ScriptableObject>("Configs", null);
            await handleConfigs.Task;

            if (handleConfigs.Status == AsyncOperationStatus.Succeeded)
            {
                foreach (var config in handleConfigs.Result)
                {
                    ConfigData.dictConfigs.Add(config.name, config);
                }
            }
        }

        public Sprite GetSpriteByID(int ID, Direction direction = default)
        {
            ItemType itemType = ConvertService.GetItemTypeByID(ID);
            switch (itemType)
            {
                case ItemType.Appearance:
                    ConfigAppearanceSciptable config = GetConfigByID<ConfigAppearanceSciptable>(ID);
                    string spriteName = $"{config.GetItemConfigAppearanceByID(ID).SpriteName}_{direction}";
                    return AtlasData.dictAtlases.GetValue(itemType + "Atlas").GetSprite(spriteName);
                default:
                    return null;
            }
        }

        public Sprite GetSpriteUIByName(string name)
        {
            Sprite result = null;
            result = AtlasData.dictAtlases.GetValue("UI_v1").GetSprite(name);
            if (result != null)
                return result;
            return result;
        }

        public T GetConfigByID<T>(int ID) where T : ScriptableObject
        {
            ItemType itemType = ConvertService.GetItemTypeByID(ID);
            switch (itemType)
            {
                case ItemType.Appearance:
                    return (T)ConfigData.dictConfigs.GetValue("Config" + itemType);
                default:
                    return null;
            }
        }
    }
}
