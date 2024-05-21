using UnityEngine;

namespace NoobKnight.Managers.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        #region Variables
        private Animator _animator;

        private int _horizontalHash;
        private int _verticalHash;
        #endregion

        #region Unity Lifecirle Methods
        private void Start()
        {
            _animator = this.GetComponent<Animator>();

            _horizontalHash = Animator.StringToHash("Horizontal");
            _verticalHash = Animator.StringToHash("Vertical");
        }
        #endregion

        #region Common Methods
        public void UpdateMovement(Vector2 movement)
        {
            _animator.SetFloat(_horizontalHash, movement.x);
            _animator.SetFloat(_verticalHash, movement.y);
        }
        #endregion
    }
}
