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
        [ForceFill] public CreateCharacterSuperScrollView createCharacterSuperScrollView;
        #endregion

        #region Inheritance Methods
        protected override void OnShowing()
        {
            base.OnShowing();

            //createCharacterSuperScrollView.InitView()
        }
        #endregion

        #region Utils Methods

        #endregion
    }

    public class CreateCharacterDefaultData
    {
        public List<ItemInventoryData> itemInventoryDatas = new List<ItemInventoryData>();

        public CreateCharacterDefaultData()
        {

        }

        private void InitializeData()
        {
            itemInventoryDatas.Add(new ItemInventoryData()
            {

            })
        }
    }
}
