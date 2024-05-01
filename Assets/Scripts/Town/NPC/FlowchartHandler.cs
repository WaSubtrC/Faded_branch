using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;
using Faded.Town;


public class FlowchartHandler : MonoBehaviour
{
    protected Flowchart flowchart;

    private void Awake()
    {
        flowchart = GetComponent<Flowchart>();
    }

    private void Start()
    {
        StartCoroutine(loadOrder());
    }

    IEnumerator loadOrder()
    {
        yield return new WaitForSeconds(0.2f);
        while(GameManager.Instance.playerStats == null)
        {
            yield return new WaitForSeconds(0.5f);
        }
        flowchart.SetIntegerVariable("Order", GameManager.Instance.playerStats.playerData.plotOrder);

    }

    public void setOrder(int newOrder)
    {
        //Debug.Log("new:" + newOrder);
        GameManager.Instance.setOrder(newOrder);
    }

    public void FacedWithMaster()
    {
        GameManager.Instance.player.GetComponent<Animator>().Play("right_idle");
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
