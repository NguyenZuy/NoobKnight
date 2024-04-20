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
        #endregion

        #region Inheritance Methods
        protected override void OnShowing()
        {
            base.OnShowing();

            customizeAppearance.OnChangeAppearance = OnChangeAppearance;
            customizeAppearance.InitializeData(InitDefaultData());
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
                HeadIDs = new int[] { },
                HairIDs = new int[] { },
                MakeupIDs = new int[] { },
                EarLIDs = new int[] { },
                EarRIDs = new int[] { },
                EyesIDs = new int[] { },
                EyeBrowsIDs = new int[] { },
                MouthIDs = new int[] { },
                BeardIDs = new int[] { }
            };
        }
        #endregion
    }
}
