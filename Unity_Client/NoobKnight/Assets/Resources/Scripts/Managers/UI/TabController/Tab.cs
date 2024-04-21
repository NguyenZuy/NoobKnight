using CustomInspector;
using UnityEngine;
using UnityEngine.UI;

namespace NoobKnight.Utils
{
    public class Tab : MonoBehaviour
    {
        #region Variables
        [HorizontalLine("Components")]
        [ForceFill] public Image imgToChangeColor;
        [ForceFill] public Image imgToChangeImage;
        [ForceFill] public Text txtToChangeText;
        #endregion
    }
}
