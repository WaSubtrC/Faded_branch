using UnityEngine;

namespace Faded.Town{
    public interface IInteractable
    {

        void Interact();//互动的实现方式方法函数
        string GetInteractText();//阐述文本

        Transform GetTransform();

    }
}

