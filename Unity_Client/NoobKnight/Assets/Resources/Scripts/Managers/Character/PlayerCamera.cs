using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInspector;

namespace NoobKnight.Managers.Character
{
    public class PlayerCamera : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public Camera mainCamera;
        #endregion

        #region Unity Lifecircle
        private void LateUpdate()
        {
            mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10f);
        }
        #endregion
    }
}
