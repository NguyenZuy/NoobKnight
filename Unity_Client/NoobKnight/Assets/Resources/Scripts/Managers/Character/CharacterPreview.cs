using UnityEngine;
using CustomInspector;
using NoobKnight.Managers.Character;
using NoobKnight.Utils;

namespace NoobKnight.Managers.Character
{
    public class CharacterPreview : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public CharacterAnchor male;
        [ForceFill] public CharacterAnchor female;

        private GenderType _curGenderType;
        #endregion

        public void OnChangeAppearance(int ID, AppearanceTypeForCustomize typeForCustomize)
        {
            if(_curGenderType == GenderType.Male)
                male.OnChangeAppearance(ID, typeForCustomize);
            else
                female.OnChangeAppearance(ID, typeForCustomize);
        }
    }
}
