using UnityEngine;

namespace Faded.Town{
    public interface IInteractable
    {

        void OnInteract();
        string GetInteractText();

        Transform GetTransform();

        KeyCode GetKeyCode();
    }
}

