using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faded.Town;
using Faded;

public class FlowchartHandler : MonoBehaviour
{
    public void setOrder(int newOrder)
    {
        GameManager.Instance.setOrder(newOrder);
    }

    public void ActivatePlayerController()
    {
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = true;
    }

    public void DeactivatePlayerController()
    {
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = false;
    }
}
