using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInspector;
using NoobKnight.JoyStick;
using System;
using NoobKnight.Utils;

namespace NoobKnight.Managers
{
    public class MainScreen : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components", 5)]
        [HorizontalLine("Interaction")]
        [ForceFill] public VariableJoystick joystick;

        public Action<Vector2> onUpdateMovementCallback;
        #endregion

        #region Unity Lifecircle Methods
        private void Update()
        {
            onUpdateMovementCallback?.Invoke(new Vector2(joystick.Horizontal, joystick.Vertical));
        }
        #endregion

        #region OnClick Methods
        public void OnClickStats()
        {
            GameManager.Instance.UIManager.ShowPopup(PopupNames.StatsPopup);
        }
        #endregion
    }
}
