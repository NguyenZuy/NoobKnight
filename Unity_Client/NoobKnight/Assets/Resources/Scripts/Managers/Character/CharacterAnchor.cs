using NoobKnight.Utils;
using UnityEngine;

namespace NoobKnight.Managers.Character
{
    public class CharacterAnchor : MonoBehaviour
    {
        public FrontAnchor frontAnchor;
        public BackAnchor backAnchor;
        public LeftAnchor leftAnchor;
        public RightAnchor rightAnchor;

        public void OnChangeAppearance(int ID, AppearanceTypeForCustomize typeForCustomize)
        {
            frontAnchor.OnChangeAppearance(ID, typeForCustomize);
            backAnchor.OnChangeAppearance(ID, typeForCustomize);
            leftAnchor.OnChangeAppearance(ID, typeForCustomize);
            rightAnchor.OnChangeAppearance(ID, typeForCustomize);
        }
    }
}
