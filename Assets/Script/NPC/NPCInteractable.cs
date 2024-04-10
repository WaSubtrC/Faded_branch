using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    private Animator animator; //NPC动画
    [SerializeField]private string talkText="Oh!You are here.";
 

    //挂到NPC上 互动的组件
    public void Interact() 
    {
        ChatBubble.Create(transform.transform, new Vector3(-3,0,0), ChatBubble.IconType.Happy,talkText);
        TaskManager.Instance.TalkWith(this);
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
}
