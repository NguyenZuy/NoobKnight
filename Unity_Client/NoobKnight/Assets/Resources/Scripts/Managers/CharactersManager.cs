using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInspector;
using NoobKnight.Managers.Character;

namespace NoobKnight.Managers
{
    public class CharactersManager : MonoBehaviour
    {
        [HorizontalLine("Local Player")]
        [ForceFill] public NoobKnight.Managers.Character.Character localPlayer;
    }
}
