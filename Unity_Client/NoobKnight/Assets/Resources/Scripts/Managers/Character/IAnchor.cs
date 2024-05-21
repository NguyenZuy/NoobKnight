using NoobKnight.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Managers.Character
{
    public interface IAnchor
    {
        void OnChangeAppearance(int ID, AppearanceSubtype typeForCustomize);
    }
}
