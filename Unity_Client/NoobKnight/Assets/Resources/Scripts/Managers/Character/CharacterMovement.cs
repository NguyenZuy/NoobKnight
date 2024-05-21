using NoobKnight.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Managers.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Variables
        public float _moveSpeed;
        #endregion

        #region Unity Lifecircle Methods
        private void Start()
        {
        }
        #endregion

        #region Common Methods
        public void Refresh()
        {
            _moveSpeed = GameManager.Instance.playerDataManager.playerCharacterData.statisticsData.moveSpeed;
        }

        public void UpdateMovement(Vector2 movement)
        {
            // Tạo vector di chuyển từ movement và tốc độ (_moveSpeed)
            Vector3 movementVector = new Vector3(movement.x, movement.y, 0) * _moveSpeed * Time.deltaTime;

            // Sử dụng phương thức Translate để di chuyển đối tượng
            transform.Translate(movementVector);
        }
        #endregion
    }
}
