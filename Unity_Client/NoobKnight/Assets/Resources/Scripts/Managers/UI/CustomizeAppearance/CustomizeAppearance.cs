using UnityEngine;
using CustomInspector;
using NoobKnight.Utils;
using UnityEngine.Events;
using NoobKnight.Entities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;

namespace NoobKnight.Managers
{
    public class CustomizeAppearance : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public GameObject itemsPanel;
        [ForceFill] public GameObject colorsPanel;
        [ForceFill] public CustomizeAppearanceScrollView customizeAppearanceScrollView;

        [ForceFill] public Button btn_SkinColor;
        [ForceFill] public Button btn_Head;
        [ForceFill] public Button btn_Hair;
        [ForceFill] public Button btn_HairColor;
        [ForceFill] public Button btn_Makeup;
        [ForceFill] public Button btn_Ear;
        [ForceFill] public Button btn_Eyes;
        [ForceFill] public Button btn_EyeColor;
        [ForceFill] public Button btn_Eyebrows;
        [ForceFill] public Button btn_Mouth;
        [ForceFill] public Button btn_Beard;

        [ForceFill] public Button btn_GenderMale;
        [ForceFill] public Button btn_GenderFemale;

        public UnityAction<int, AppearanceSubtype> OnChangeAppearance;
        public UnityAction<string> OnChangeGender;

        [HideInInspector] public ItemColor curItemColor = null;
        [HideInInspector] public ItemCustomizeAppearance curItemCustomizeAppearance = null;

        private GenderType  _curGenderType;
        private AppearanceSubtype _curMode;
        private PlayerInventoryData.AppearanceInventoryData _curAppearanceData;
        private Button _curBtnTypeSelecting;

        #endregion

        #region Unity Lifecircle Methods
        private void OnEnable()
        {
            ResetUI();
        }
        #endregion

        #region Data Methods
        public void SetupData(PlayerInventoryData.AppearanceInventoryData appearanceInventoryData)
        {
            _curAppearanceData = appearanceInventoryData;
            OnClickTypes(new TypeAppearanceComponent() { typeAppearance = AppearanceSubtype.Skin_Color });
        }
        #endregion

        #region UI Methods
        public void ResetUI()
        {
            OnClickGender(GenderType.Male.ToString());
            ResetCharacterCustomize();
        }

        public void ResetCharacterCustomize()
        {
            SetMode(true);
            OnClickTypes(new TypeAppearanceComponent()
            {
                typeAppearance = AppearanceSubtype.Skin_Color,
            });
            SetStateButtonGender();
        }

        private void SetMode(bool isColors)
        {
            itemsPanel.SetActive(!isColors);
            colorsPanel.SetActive(isColors);
        }

        private void SetStateButtonGender()
        {
            btn_GenderMale.interactable = _curGenderType != GenderType.Male;
            btn_GenderFemale.interactable = _curGenderType != GenderType.Female;
        }

        private void SetStateButtonTypes()
        {
            if (_curBtnTypeSelecting != null)
                _curBtnTypeSelecting.interactable = true;
            switch (_curMode)
            {
                case AppearanceSubtype.Skin_Color:
                    _curBtnTypeSelecting = btn_SkinColor;
                    break;
                case AppearanceSubtype.Eye_Color:
                    _curBtnTypeSelecting = btn_EyeColor;
                    break;
                case AppearanceSubtype.Hair_Color:
                    _curBtnTypeSelecting = btn_HairColor;
                    break;
                case AppearanceSubtype.Head:
                    _curBtnTypeSelecting = btn_Head;
                    break;
                case AppearanceSubtype.Hair:
                    _curBtnTypeSelecting = btn_Hair;
                    break;
                case AppearanceSubtype.Makeup:
                    _curBtnTypeSelecting = btn_Makeup;
                    break;
                case AppearanceSubtype.Ear:
                    _curBtnTypeSelecting = btn_Ear;
                    break;
                case AppearanceSubtype.Eyes:
                    _curBtnTypeSelecting = btn_Eyes;
                    break;
                case AppearanceSubtype.Eyebrows:
                    _curBtnTypeSelecting = btn_Eyebrows;
                    break;
                case AppearanceSubtype.Mouth:
                    _curBtnTypeSelecting = btn_Mouth;
                    break;
                case AppearanceSubtype.Beard:
                    _curBtnTypeSelecting = btn_Beard;
                    break;
            }
            _curBtnTypeSelecting.interactable = false;
        }
        #endregion

        #region OnClick Methods
        public void OnClickGender(string gender)
        {
            if (gender == _curGenderType.ToString())
                return;

            _curGenderType = Enum.Parse<GenderType>(gender);
            OnChangeGender?.Invoke(gender);
            ResetCharacterCustomize();
        }

        public void OnClickTypes(TypeAppearanceComponent typeAppearanceComponent)
        {
            _curMode = typeAppearanceComponent.typeAppearance;
            SetStateButtonTypes();
            bool isColors = _curMode == AppearanceSubtype.Skin_Color || _curMode == AppearanceSubtype.Eye_Color || _curMode == AppearanceSubtype.Hair_Color;
            SetMode(isColors);
            if (isColors)
            {
                // Check color is using
                Button[] btnColors = colorsPanel.GetComponentsInChildren<Button>();
                foreach (var btn in btnColors)
                {
                    int colorInteger = ColorUtils.Color32ToInt(btn.GetComponent<Image>().color);
                    bool isUsing = GameManager.Instance.playerDataManager.playerCharacterData.appearanceData.IsUsing(colorInteger, _curMode);
                    btn.interactable = !isUsing;
                    if (isUsing)
                        curItemColor = btn.GetComponent<ItemColor>();
                }
                return;
            }
            else
            {
                if (!customizeAppearanceScrollView.isDoAwake)
                    customizeAppearanceScrollView.InitView();
            }
            int[] datas = new int[0];
            switch (_curMode)
            {
                case AppearanceSubtype.Head:
                    datas = _curAppearanceData.headIDs;
                    break;
                case AppearanceSubtype.Hair:
                    datas = _curAppearanceData.hairIDs;
                    break;
                case AppearanceSubtype.Makeup:
                    datas = _curAppearanceData.makeupIDs;
                    break;
                case AppearanceSubtype.Ear:
                    datas = _curAppearanceData.earIDs;
                    break;
                case AppearanceSubtype.Eyes:
                    datas = _curAppearanceData.eyesIDs;
                    break;
                case AppearanceSubtype.Eyebrows:
                    datas = _curAppearanceData.eyeBrowsIDs;
                    break;
                case AppearanceSubtype.Mouth:
                    datas = _curAppearanceData.mouthIDs;
                    break;
                case AppearanceSubtype.Beard:
                    datas = _curAppearanceData.beardIDs;
                    break;
                default:
                    break;
            }
            List<int> rawData = datas.ToList();
            rawData.Insert(0, 0); // Add none item 

            customizeAppearanceScrollView.SetupData(datas, _curMode, OnClickItem);
            customizeAppearanceScrollView.ReloadData();
        }

        public void OnClickItemColor(ItemColor itemColor)
        {
            if (curItemColor != null && curItemColor == itemColor)
                return;
            OnChangeAppearance?.Invoke(itemColor.GetColor(), _curMode);

            if (curItemColor != null)
                curItemColor.GetComponent<Button>().interactable = true;
            curItemColor = itemColor;
            curItemColor.GetComponent<Button>().interactable = false;
        }

        public void OnClickItem(ItemCustomizeAppearance itemCustomizeAppearance)
        {
            if (curItemCustomizeAppearance != null && curItemCustomizeAppearance.ID == itemCustomizeAppearance.ID)
                return;
            OnChangeAppearance?.Invoke(itemCustomizeAppearance.ID, _curMode);

            if (curItemCustomizeAppearance != null)
                curItemCustomizeAppearance.GetComponent<Button>().interactable = true;
            curItemCustomizeAppearance = itemCustomizeAppearance;
            curItemCustomizeAppearance.GetComponent<Button>().interactable = false;
        }

        #endregion
    }
}
