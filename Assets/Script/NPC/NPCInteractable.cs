using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    private Animator animator; //NPC����
    [SerializeField]private string talkText="Oh!You are here.";
 

    //�ҵ�NPC�� ���������
    public void Interact() 
    {
        ChatBubble.Create(transform.transform, new Vector3(-3,0,0), ChatBubble.IconType.Happy,talkText);
        TaskManager.Instance.TalkWith(this);
        //����ɼӴ���
        //animator���ý�̸״̬
        //npc�泯��� Ŀǰ����

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
