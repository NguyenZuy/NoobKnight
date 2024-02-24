using UnityEngine;
using CustomInspector;

namespace NoobKnight.Managers.Nakama
{
    [CreateAssetMenu(fileName = "NakamaConnection", menuName = "ScriptableObjects/NakamaConnection", order = 1)]
    public class NakamaConnection : ScriptableObject
    {
        [ForceFill] public string scheme = "http";
        [ForceFill] public string host = "localhost";
        [ForceFill] public int port = 7350;
        [ForceFill] public string serverKey = "defaultkey";
    }
}
