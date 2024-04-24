using CustomInspector;
using NoobKnight.Utils;
using UnityEngine;

namespace NoobKnight.Managers
{
    public class LeftAnchor : MonoBehaviour
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

        public void OnChangeAppearance(int ID, AppearanceTypeForCustomize typeForCustomize)
        {
            var color = ColorUtils.IntToColor32(ID);
            switch (typeForCustomize)
            {
                case AppearanceTypeForCustomize.Skin_Color:
                    body.color = color;
                    head.color = color;
                    earL.color = color;
                    earR.color = color;
                    armL.color = color;
                    handL.color = color;
                    legL.color = color;
                    legR.color = color;
                    break;
                case AppearanceTypeForCustomize.Eye_Color:
                    eyes.color = color;
                    break;
                case AppearanceTypeForCustomize.Hair_Color:
                    hair.color = color;
                    break;
                case AppearanceTypeForCustomize.Head:
                    head.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Hair:
                    hair.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Makeup:
                    makeup.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Ear:
                    earL.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    earR.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Eyes:
                    eyes.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Eyebrows:
                    eyesbrows.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Mouth:
                    mouth.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                case AppearanceTypeForCustomize.Beard:
                    beard.sprite = GameManager.Instance.ResourceManager.GetSpriteByID(ID, Direction.Left);
                    break;
                default:
                    break;
            }
        }
    }
}
