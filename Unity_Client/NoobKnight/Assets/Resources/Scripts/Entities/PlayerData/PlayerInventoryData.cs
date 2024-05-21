using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Entities
{
    [Serializable]
    public class PlayerInventoryData
    {
        #region Variables
        public AppearanceInventoryData appearanceInventoryData = new AppearanceInventoryData();
        #endregion

        [Serializable]
        public class AppearanceInventoryData
        {
            public int[] headIDs;
            public int[] hairIDs;
            public int[] makeupIDs;
            public int[] earIDs;
            public int[] eyesIDs;
            public int[] eyeBrowsIDs;
            public int[] mouthIDs;
            public int[] beardIDs;
        }
    }
}
