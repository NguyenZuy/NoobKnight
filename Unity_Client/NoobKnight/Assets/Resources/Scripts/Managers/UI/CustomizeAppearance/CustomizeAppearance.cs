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
        #endregion

        #region Data Methods
        public void InitializeData(PlayerInventoryData.AppearanceData appearanceInventoryData)
        {

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
            switch (typeAppearance)
            {
                case TypeAppearance.Skin_Color:
                case TypeAppearance.Eye_Color:
                case TypeAppearance.Hair_Color:
                    SetMode(false);
                    break;
                case TypeAppearance.Ear:

                    break;
                default:
                    break;
            }
        }

        public void OnClickItemColor(ItemColor itemColor)
        {
            OnChangeAppearance?.Invoke(_curMode, itemColor.GetColor());
        }
        #endregion
    }
}
