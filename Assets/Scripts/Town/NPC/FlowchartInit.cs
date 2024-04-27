using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartInit : MonoBehaviour
{
    public void setOrder(int newOrder)
    {
        GameManager.Instance.setOrder(newOrder);
    }
}
