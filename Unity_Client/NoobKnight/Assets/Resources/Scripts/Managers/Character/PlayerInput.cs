using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoobKnight.JoyStick;
using CustomInspector;
using UnityEngine.Events;

namespace NoobKnight.Managers.Character
{
    public class PlayerInput : MonoBehaviour
    {
        #region Variables
        public UnityAction<Vector2> onUpdateMovementCallback;
        #endregion

        #region Unity Lifecircle Methods
        private void Update()
        {
            
        }
        #endregion

        #region Common Methods
        public void onUpdateMovement(Vector2 movement)
        {
            onUpdateMovementCallback?.Invoke(movement);
        }
        #endregion
    }
}
