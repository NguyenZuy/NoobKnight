using NoobKnight.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Utils
{

    [CreateAssetMenu(fileName = "ConfigAppearancce", menuName = "Configs/ConfigAppearancce")]
    public class ConfigAppearanceSciptable : ScriptableObject
    {
        public string sheetId;
        public string gridId;

        public List<ItemConfigAppearance> items;

        [ContextMenu("Sync")]
        private void Sync()
        {
            ReadGoogleSheets.FillData<ItemConfigAppearance>(sheetId, gridId, list =>
            {
                items = list;
                ReadGoogleSheets.SetDirty(this);
            });
        }

        [ContextMenu("OpenSheet")]
        private void Open()
        {
            ReadGoogleSheets.OpenUrl(sheetId, gridId);
        }
    }
}
