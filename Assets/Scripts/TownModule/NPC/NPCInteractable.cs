using Fungus;
using System.Collections;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    //private Animator animator; //NPC动画
    //[SerializeField]private string talkText="Oh!You are here.";
    [SerializeField] private string chatName_01;
    private Flowchart flowchart;

    //挂到NPC上 互动的组件
    public void Interact() 
    {
        Say();
        StartCoroutine(StartTask());
        //ChatBubble.Create(transform.transform, new Vector3(-3,0,0), ChatBubble.IconType.Happy,talkText);
        //额外可加代码
        //animator设置交谈状态
        //npc面朝玩家 目前不用

    }


    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    private void Say()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (flowchart.HasBlock(chatName_01))
        {
            flowchart.ExecuteBlock(chatName_01);
        }
        else { Debug.LogWarning(chatName_01 + "can not found;"); }
   
    }
    private IEnumerator StartTask()
    {
        while (!flowchart.GetBooleanVariable("endTalk"))
        {
            yield return null; // 等待一帧
        }

        TaskManager.Instance.TalkWith(this);
        yield break;
    }
}
