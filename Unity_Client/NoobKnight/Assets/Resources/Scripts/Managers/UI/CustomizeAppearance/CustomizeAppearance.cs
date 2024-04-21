using UnityEngine;
using CustomInspector;
using NoobKnight.Utils;
using UnityEngine.Events;
using NoobKnight.Entities;

namespace NoobKnight.Managers
{
    public class CustomizeAppearance : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public GameObject itemsPanel;
        [ForceFill] public GameObject colorsPanel;

        [ForceFill] public CustomizeAppearanceScrollView customizeAppearanceScrollView;

        public UnityAction<TypeAppearance, int> OnChangeAppearance { get; set; }

        private TypeAppearance _curMode;

        private PlayerInventoryData.AppearanceData _appearanceData;
        #endregion

        #region Data Methods
        public void SetupData(PlayerInventoryData.AppearanceData appearanceInventoryData)
        {
            _appearanceData = appearanceInventoryData;
        }
        #endregion

        #region UI Methods
        private void SetMode(bool isItems)
        {
            itemsPanel.SetActive(isItems);
            colorsPanel.SetActive(!isItems);
        }
        #endregion

        #region OnClick Methods
        public void OnClickTypes(TypeAppearanceComponent typeAppearanceComponent)
        {
            TypeAppearance typeAppearance = typeAppearanceComponent.typeAppearance;
            _curMode = typeAppearance;
            SetMode(typeAppearance != TypeAppearance.Skin_Color || typeAppearance != TypeAppearance.Eye_Color || typeAppearance != TypeAppearance.Hair_Color);
            switch (typeAppearance)
            {
                case TypeAppearance.Head:
                    customizeAppearanceScrollView.SetupData(_appearanceData.HeadIDs);
                    break;
                case TypeAppearance.Hair:
                    customizeAppearanceScrollView.SetupData(_appearanceData.HairIDs);
                    break;
                case TypeAppearance.Makeup:
                    customizeAppearanceScrollView.SetupData(_appearanceData.MakeupIDs);
                    break;
                case TypeAppearance.Ear:
                    customizeAppearanceScrollView.SetupData(_appearanceData.EarIDs);
                    break;
                case TypeAppearance.Eyes:
                    customizeAppearanceScrollView.SetupData(_appearanceData.EyesIDs);
                    break;
                case TypeAppearance.Eyebrows:
                    customizeAppearanceScrollView.SetupData(_appearanceData.EyeBrowsIDs);
                    break;
                case TypeAppearance.Mouth:
                    customizeAppearanceScrollView.SetupData(_appearanceData.MouthIDs);
                    break;
                case TypeAppearance.Beard:
                    customizeAppearanceScrollView.SetupData(_appearanceData.BeardIDs);
                    break;
                default:
                    break;
            }
            customizeAppearanceScrollView.ReloadData();
        }

        public void OnClickItemColor(ItemColor itemColor)
        {
            OnChangeAppearance?.Invoke(_curMode, itemColor.GetColor());
        }
        #endregion
    }
}
