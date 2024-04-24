using UnityEngine;
using CustomInspector;
using NoobKnight.Utils;
using UnityEngine.Events;
using NoobKnight.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NoobKnight.Managers
{
    public class CustomizeAppearance : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public GameObject itemsPanel;
        [ForceFill] public GameObject colorsPanel;

        [ForceFill] public CustomizeAppearanceScrollView customizeAppearanceScrollView;

        public UnityAction<int, AppearanceTypeForCustomize> OnChangeAppearance { get; set; }

        private AppearanceTypeForCustomize _curMode;

        private PlayerInventoryData.AppearanceData _appearanceData;

        private ItemColor _curItemColor;
        private int _curID;
        #endregion

        #region Data Methods
        public void SetupData(PlayerInventoryData.AppearanceData appearanceInventoryData)
        {
            _appearanceData = appearanceInventoryData;
            OnClickTypes(new TypeAppearanceComponent() { typeAppearance = AppearanceTypeForCustomize.Skin_Color });
        }
        #endregion

        #region UI Methods
        private void SetMode(bool isColors)
        {
            itemsPanel.SetActive(!isColors);
            colorsPanel.SetActive(isColors);
        }
        #endregion

        #region OnClick Methods
        public void OnClickTypes(TypeAppearanceComponent typeAppearanceComponent)
        {
            AppearanceTypeForCustomize typeAppearance = typeAppearanceComponent.typeAppearance;
            _curMode = typeAppearance;
            bool isColors = typeAppearance == AppearanceTypeForCustomize.Skin_Color || typeAppearance == AppearanceTypeForCustomize.Eye_Color || typeAppearance == AppearanceTypeForCustomize.Hair_Color;
            SetMode(isColors);
            if (isColors) return;
            else
            {
                if (!customizeAppearanceScrollView.isDoAwake)
                    customizeAppearanceScrollView.InitView();
            }
            int[] datas = new int[0];
            switch (typeAppearance)
            {
                case AppearanceTypeForCustomize.Head:
                    datas = _appearanceData.HeadIDs;
                    break;
                case AppearanceTypeForCustomize.Hair:
                    datas = _appearanceData.HairIDs;
                    break;
                case AppearanceTypeForCustomize.Makeup:
                    datas = _appearanceData.MakeupIDs;
                    break;
                case AppearanceTypeForCustomize.Ear:
                    datas = _appearanceData.EarIDs;
                    break;
                case AppearanceTypeForCustomize.Eyes:
                    datas = _appearanceData.EyesIDs;
                    break;
                case AppearanceTypeForCustomize.Eyebrows:
                    datas = _appearanceData.EyeBrowsIDs;
                    break;
                case AppearanceTypeForCustomize.Mouth:
                    datas = _appearanceData.MouthIDs;
                    break;
                case AppearanceTypeForCustomize.Beard:
                    datas = _appearanceData.BeardIDs;
                    break;
                default:
                    break;
            }
            List<int> rawData = datas.ToList();
            rawData.Insert(0, 0); // Add none item 

            customizeAppearanceScrollView.SetupData(datas, OnClickItem);
            customizeAppearanceScrollView.ReloadData();
        }

        public void OnClickItemColor(ItemColor itemColor)
        {
            if (_curItemColor != null && _curItemColor == itemColor)
                return;
             OnChangeAppearance?.Invoke(itemColor.GetColor(), _curMode);
            _curItemColor = itemColor;
        }

        public void OnClickItem(int ID)
        {
            if (_curID != 0 && _curID == ID)
                return;
            OnChangeAppearance?.Invoke(ID, _curMode);
            _curID = ID;
        }
        #endregion
    }
}
