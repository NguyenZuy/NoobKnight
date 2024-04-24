using NoobKnight.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NoobKnight.Managers
{
    public class ItemColor : MonoBehaviour
    {
        private Color32 _color;

        private void Awake()
        {
            _color = this.GetComponent<Image>().color;
        }

        public int GetColor()
        {
            return (int)ColorUtils.Color32ToInt(_color);
        }
    }
}
