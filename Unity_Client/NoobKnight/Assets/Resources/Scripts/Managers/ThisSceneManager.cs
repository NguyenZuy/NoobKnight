using NoobKnight.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Managers
{
    public class ThisSceneManager : BaseSingleton<ThisSceneManager>
    {
        #region Variables
        public Transform defaultSpawnPoint;
        public List<Gate> gates;
        #endregion

        #region Unity Lifecircle Methods
        private void Start()
        {
            int curGateID = GameManager.Instance.sceneManager.curGateID;
            if (curGateID == 0)
                GameManager.Instance.charactersManager.localPlayer.transform.position = defaultSpawnPoint.position;

        }
        #endregion
    }

    [Serializable]
    public class Gate
    {
        public int ID;
        public Transform spawnPoint;
    }
}
