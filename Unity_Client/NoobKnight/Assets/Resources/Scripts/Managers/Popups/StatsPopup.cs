using CustomInspector;
using NoobKnight.Managers.Character;
using TMPro;
using UnityEngine.UI;
using NoobKnight.Utils;

namespace NoobKnight.Managers.Popups
{
    public class StatsPopup : BasePopup
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public CharacterPreview characterPreview;

        [ForceFill] public TextMeshProUGUI txt_PlayerDisplayName;
        [ForceFill] public TextMeshProUGUI txt_Level;
        [ForceFill] public TextMeshProUGUI txt_Status;

        [ForceFill] public Image img_EquiptEarringL;
        [ForceFill] public Image img_EquiptArmArmorL;
        [ForceFill] public Image img_EquiptArmSleeveL;
        [ForceFill] public Image img_EquiptWeaponL;
        [ForceFill] public Image img_EquiptRingL;
        [ForceFill] public Image img_EquiptLegL;

        [ForceFill] public Image img_EquiptEarringR;
        [ForceFill] public Image img_EquiptArmArmorR;
        [ForceFill] public Image img_EquiptArmSleeveR;
        [ForceFill] public Image img_EquiptWeaponR;
        [ForceFill] public Image img_EquiptRingR;
        [ForceFill] public Image img_EquiptLegR;

        [ForceFill] public Image img_EquiptArmor;
        [ForceFill] public Image img_EquiptMask;
        [ForceFill] public Image img_EquipHelmet;
        [ForceFill] public Image img_EquipNecklace;

        [ForceFill] public TextMeshProUGUI txt_StatsStreigth;
        [ForceFill] public TextMeshProUGUI txt_StatsMagic;
        [ForceFill] public TextMeshProUGUI txt_StatsIntelligence;
        [ForceFill] public TextMeshProUGUI txt_StatsEndurance;
        [ForceFill] public TextMeshProUGUI txt_StatsAgility;
        [ForceFill] public TextMeshProUGUI txt_StatsWillPower;

        #endregion

        #region Inheritance Methods
        protected override void OnShowing()
        {
            base.OnShowing();

            Refresh(GameManager.Instance.playerDataManager);
        }
        #endregion

        #region UI Methods
        private void Refresh(PlayerDataManager playerDataManager)
        {
            characterPreview.ReloadChacracter(playerDataManager.playerCharacterData);
        }
        #endregion

        #region OnClick Methods
        public void OnClickClose()
        {
            GameManager.Instance.UIManager.HidePopup(PopupNames.StatsPopup);
        }
        #endregion
    }
}
