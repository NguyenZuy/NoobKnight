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
            if (ID == 0 || ID == -99)
                return null;

            ItemType itemType = ConvertService.GetItemTypeByID(ID);
            SpriteAtlas atlas = AtlasData.dictAtlases.GetValue(itemType + "Atlas");
            switch (itemType)
            {
                case ItemType.Appearance:
                    ConfigAppearanceSciptable config = GetConfigByID<ConfigAppearanceSciptable>(ID);
                    string spriteName = $"{config.GetItemConfigAppearanceByID(ID).SpriteName}_{direction}";
                    return atlas.GetSprite(spriteName);
                default:
                    return null;
            }
        }

        public Sprite GetSpriteUIByName(string spriteName)
        {
            SpriteAtlas atlas = AtlasData.dictAtlases.GetValue("UI_v1" + "Atlas");
            return atlas.GetSprite(spriteName);
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
