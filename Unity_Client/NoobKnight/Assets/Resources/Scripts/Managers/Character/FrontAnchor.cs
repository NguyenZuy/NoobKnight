using CustomInspector;
using NoobKnight.Utils;
using UnityEngine;

namespace NoobKnight.Managers.Character
{
    public class FrontAnchor : MonoBehaviour, IAnchor
    {
        #region Variables
        [HorizontalLine("Upper Body Components", 5f)]
        [ForceFill] public SpriteRenderer body;
        [ForceFill] public SpriteRenderer armor;
        [ForceFill] public SpriteRenderer quiver;
        [HorizontalLine("Head")]
        [ForceFill] public SpriteRenderer head;
        [ForceFill] public SpriteRenderer makeup;
        [ForceFill] public SpriteRenderer mask;
        [ForceFill] public SpriteRenderer hair;
        [ForceFill] public SpriteRenderer helmet;
        [ForceFill] public SpriteRenderer earL;
        [ForceFill] public SpriteRenderer earringL;
        [ForceFill] public SpriteRenderer earR;
        [ForceFill] public SpriteRenderer earringR;
        [ForceFill] public SpriteRenderer eyes;
        [ForceFill] public SpriteRenderer eyesbrows;
        [ForceFill] public SpriteRenderer mouth;
        [ForceFill] public SpriteRenderer beard;
        [HorizontalLine("Arm Left")]
        [ForceFill] public SpriteRenderer armL;
        [ForceFill] public SpriteRenderer armLArmor;
        [ForceFill] public SpriteRenderer armLSleeve;
        [ForceFill] public SpriteRenderer handL;
        [ForceFill] public SpriteRenderer handLArmor;
        [ForceFill] public SpriteRenderer handLWeapon;
        [ForceFill] public SpriteRenderer handLShield;
        [ForceFill] public SpriteRenderer handLHandle;
        [ForceFill] public SpriteRenderer handLLimbU;
        [ForceFill] public SpriteRenderer handLLimbL;
        [ForceFill] public SpriteRenderer handLArrow;
        [HorizontalLine("Arm Right")]
        [ForceFill] public SpriteRenderer armR;
        [ForceFill] public SpriteRenderer armRArmor;
        [ForceFill] public SpriteRenderer armRSleeve;
        [ForceFill] public SpriteRenderer handR;
        [ForceFill] public SpriteRenderer handRArmor;
        [ForceFill] public SpriteRenderer handRWeapon;
        [ForceFill] public SpriteRenderer handRShield;
        [ForceFill] public SpriteRenderer handRHandle;
        [ForceFill] public SpriteRenderer handRLimbU;
        [ForceFill] public SpriteRenderer handRLimbL;
        [ForceFill] public SpriteRenderer handRArrow;

        [HorizontalLine("Lower Body Components", 5f)]
        [ForceFill] public SpriteRenderer legL;
        [ForceFill] public SpriteRenderer legLArmor;
        [ForceFill] public SpriteRenderer legR;
        [ForceFill] public SpriteRenderer legRArmor;
        #endregion

        public void OnChangeAppearance(int ID, AppearanceSubtype typeForCustomize)
        {
            var color = ColorUtils.IntToColor32(ID);
            var resourceManager = GameManager.Instance.resourceManager;
            switch (typeForCustomize)
            {
                case AppearanceSubtype.Skin_Color:
                    body.color = color;
                    head.color = color;
                    earL.color = color;
                    earR.color = color;
                    armL.color = color;
                    armR.color = color;
                    handL.color = color;
                    handR.color = color;
                    legL.color = color;
                    legR.color = color;
                    break;
                case AppearanceSubtype.Eye_Color:
                    eyes.color = color;
                    break;
                case AppearanceSubtype.Hair_Color:
                    hair.color = color;
                    break;
                case AppearanceSubtype.Head:
                    head.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Hair:
                    hair.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Makeup:
                    makeup.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Ear:
                    earL.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    earR.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Eyes:
                    eyes.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Eyebrows:
                    eyesbrows.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Mouth:
                    mouth.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                case AppearanceSubtype.Beard:
                    beard.sprite = resourceManager.GetSpriteByID(ID, Direction.Front);
                    break;
                default:
                    break;
            }
        }
    }
}
