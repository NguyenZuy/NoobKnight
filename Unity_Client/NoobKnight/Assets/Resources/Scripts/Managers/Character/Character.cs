using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInspector;
using UnityEngine.Events;

namespace NoobKnight.Managers.Character
{
    public class Character : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [MessageBox("Toggle this bool value if this is local player")]
        public bool isLocalPlayer;
        [ShowIf(nameof(isLocalPlayer))] [ForceFill] public PlayerInput playerInput;
        [ShowIf(nameof(isLocalPlayer))] [ForceFill] public PlayerCamera playerCamera;
        [ForceFill] public CharacterAnchor characterAnchor;
        [ForceFill] public CharacterMovement characterMovement;
        [ForceFill] public CharacterAnimator characterAnimator;
        #endregion

        #region Unity Lifecircle Methods
        private void Start()
        {
            if (isLocalPlayer)
            {
                UnityAction<Vector2> onUpdateMovement = null;
                onUpdateMovement += characterAnchor.UpdateMovement;
                onUpdateMovement += characterMovement.UpdateMovement;
                onUpdateMovement += characterAnimator.UpdateMovement;

                playerInput.onUpdateMovementCallback = onUpdateMovement;
            }
        }
        #endregion

        #region Common Methods
        public void ToggleActive(bool state)
        {
            this.gameObject.SetActive(state);
            RefreshCharacter();
        }

        public void RefreshCharacter()
        {
            GameManager.Instance.UIManager.mainScreen.onUpdateMovementCallback = playerInput.onUpdateMovement;

            characterAnchor.Refresh();
            characterMovement.Refresh();
        }
        #endregion
    }
}
