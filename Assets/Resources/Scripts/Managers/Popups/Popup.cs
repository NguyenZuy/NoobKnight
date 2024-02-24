using UnityEngine;

namespace NoobKnight.Managers.Popup
{
    public class Popup : MonoBehaviour
    {
        private object _parameter;
        public object Parameter {
            get { return _parameter; }
            set { _parameter = value; }
        }

        public void Show()
        {

        }
    }
}
