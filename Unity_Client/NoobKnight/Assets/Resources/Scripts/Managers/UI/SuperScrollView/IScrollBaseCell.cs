using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Managers
{
    public interface IScrollBaseCell<T>
    {
        void BindData(T data);
        void OnClick();
    }
}
