using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NoobKnight.Utils;
using NoobKnight.Managers;
using CustomInspector;
using Nakama;
using NoobKnight.Entities;
using System.Collections.Generic;

namespace NoobKnight.Managers.Popups
{
    public class CreateCharacterPopup : BasePopup
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public CustomizeAppearance customizeAppearance;
        [ForceFill] public GameObject characterPreview;
        #endregion

        #region Inheritance Methods
        protected override void OnShowing()
        {
            base.OnShowing();

            characterPreview.SetActive(true);
            customizeAppearance.OnChangeAppearance = OnChangeAppearance;
            customizeAppearance.SetupData(InitDefaultData());
            customizeAppearance.customizeAppearanceScrollView.InitView();
        }

        protected override void OnHiding()
        {
            base.OnHiding();

            characterPreview.SetActive(false);
        }
        #endregion

        #region Methods
        public void OnChangeAppearance(TypeAppearance typeAppearance, int ID)
        {

        }
        #endregion

        #region Utils Methods
        private PlayerInventoryData.AppearanceData InitDefaultData()
        {
            return new PlayerInventoryData.AppearanceData()
            {
                HeadIDs = new int[] { 110100001 },
                HairIDs = new int[] { 110200001 },
                MakeupIDs = new int[] { 110300001 },
                EarIDs = new int[] { 110400001 },
                EyesIDs = new int[] { 110500001 },
                EyeBrowsIDs = new int[] { 110600001 },
                MouthIDs = new int[] { 110700001 },
                BeardIDs = new int[] { 110800001 }
            };
        }
        #endregion
    }
}
