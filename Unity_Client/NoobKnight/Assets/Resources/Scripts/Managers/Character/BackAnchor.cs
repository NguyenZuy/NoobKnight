using CustomInspector;
using UnityEngine;

namespace NoobKnight.Managers
{
    public class BackAnchor : MonoBehaviour
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
        [HorizontalLine("Arm Left")]
        [ForceFill] public SpriteRenderer armL;
        [ForceFill] public SpriteRenderer armLArmor;
        [ForceFill] public SpriteRenderer armLSleeve;
        [ForceFill] public SpriteRenderer handL;
        [ForceFill] public SpriteRenderer handLArmor;
        [ForceFill] public SpriteRenderer handLFingers;
        [ForceFill] public SpriteRenderer handLFingersArmor;
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
        [ForceFill] public SpriteRenderer handRFingers;
        [ForceFill] public SpriteRenderer handRFingersArmor;
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
    }
}
