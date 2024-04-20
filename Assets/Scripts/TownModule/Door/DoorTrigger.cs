using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Town
{
    enum TriggerType { InDoor, OutDoor }

    public class DoorTrigger : MonoBehaviour
    {

        [SerializeField] private Door door;
        [SerializeField] private TriggerType type;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (type == TriggerType.InDoor)
                    door.OnEnter();
                else
                {
                    door.OnExit();
                }

            }

        }
    }
}

