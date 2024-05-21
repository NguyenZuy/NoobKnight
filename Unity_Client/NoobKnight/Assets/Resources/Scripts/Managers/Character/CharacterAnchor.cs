using NoobKnight.Utils;
using UnityEngine;

namespace NoobKnight.Managers.Character
{
    public class CharacterAnchor : MonoBehaviour
    {
        #region Variables
        public FrontAnchor frontAnchor;
        public BackAnchor backAnchor;
        public LeftAnchor leftAnchor;
        public RightAnchor rightAnchor;

        private Direction _curDirection = Direction.Front;
        public Vector2 a;
        #endregion

        #region Common Methods
        public void Refresh()
        {
            var appearanceData = GameManager.Instance.playerDataManager.playerCharacterData.appearanceData;
            OnChangeAppearance(appearanceData.skinColorID, AppearanceSubtype.Skin_Color);
            OnChangeAppearance(appearanceData.eyesColorID, AppearanceSubtype.Eye_Color);
            OnChangeAppearance(appearanceData.hairColorID, AppearanceSubtype.Hair_Color);
            OnChangeAppearance(appearanceData.headID, AppearanceSubtype.Head);
            OnChangeAppearance(appearanceData.hairID, AppearanceSubtype.Hair);
            OnChangeAppearance(appearanceData.makeupID, AppearanceSubtype.Makeup);
            OnChangeAppearance(appearanceData.earID, AppearanceSubtype.Ear);
            OnChangeAppearance(appearanceData.eyesID, AppearanceSubtype.Eyes);
            OnChangeAppearance(appearanceData.eyeBrowsID, AppearanceSubtype.Eyebrows);
            OnChangeAppearance(appearanceData.mouthID, AppearanceSubtype.Mouth);
            OnChangeAppearance(appearanceData.beardID, AppearanceSubtype.Beard);
        }

        public void OnChangeAppearance(int ID, AppearanceSubtype typeForCustomize)
        {
            frontAnchor.OnChangeAppearance(ID, typeForCustomize);
            backAnchor.OnChangeAppearance(ID, typeForCustomize);
            leftAnchor.OnChangeAppearance(ID, typeForCustomize);
            rightAnchor.OnChangeAppearance(ID, typeForCustomize);
        }

        public void UpdateMovement(Vector2 movement)
        {
            a = movement;
            float horizontal = movement.x;
            float vertical = movement.y;

            Direction direction = _curDirection;

            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                if (horizontal > 0)
                {
                    // Right
                    direction = Direction.Right;
                }
                else if (horizontal < 0)
                {
                    // Left
                    direction = Direction.Left;
                }
            }
            else
            {
                if (vertical > 0)
                {
                    // Back
                    direction = Direction.Back;
                }
                else if (vertical < 0)
                {
                    // Front
                    direction = Direction.Front;
                }
            }

            ChangeDirection(direction);
        }

        void ChangeDirection(Direction direction)
        {
            if (direction == _curDirection)
                return;

            _curDirection = direction;

            frontAnchor.gameObject.SetActive(direction == Direction.Front);
            backAnchor.gameObject.SetActive(direction == Direction.Back);
            leftAnchor.gameObject.SetActive(direction == Direction.Left);
            rightAnchor.gameObject.SetActive(direction == Direction.Right);
        }
        #endregion
    }
}
