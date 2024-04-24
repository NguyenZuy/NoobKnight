using System;

namespace NoobKnight.Utils
{
    public enum SceneNames
    {
        Authenticate = 0,
        BeginnerVillage = 1,
    }

    public enum PopupNames
    {
        IntroPopup = 0,
        AuthenticatePopup = 1,
        CreateCharacterPopup = 2,
    }

    public enum Direction
    {
        None = 0,
        Front = 1,
        Back = 2,
        Left = 3,
    }

    public enum ItemType
    {
        Appearance = 1,
        Equipment = 2,
        Consumable = 3,
    }

    public enum GenderType
    {
        Male = 0,
        Female = 1,
    }

    [Serializable]
    public enum AppearanceTypeForCustomize
    {
        Skin_Color = 0,
        Eye_Color = 1,
        Hair_Color = 2,

        Head = 3,
        Hair = 4,
        Makeup = 5,
        Ear = 6,
        Eyes = 7,
        Eyebrows = 8,
        Mouth = 9,
        Beard = 10,
    }

    public enum AppearanceSubType
    {
        None = 0,
        Head = 1,
        Hair = 2,
        Makeup = 3,
        Ear = 4,
        Eyes = 5,
        Eyebrows = 6,
        Mouth = 7,
        Beard = 8,
    }
}
