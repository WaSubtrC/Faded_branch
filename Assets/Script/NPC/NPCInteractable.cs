using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    private Animator animator; //NPC����
    [SerializeField]private string talkText="Oh!You are here.";


    //�ҵ�NPC�� ���������
    public void Interact() 
    {
        ChatBubble.Create(transform.transform, new Vector3(0f,0f,0f), ChatBubble.IconType.Happy,talkText);
        
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
