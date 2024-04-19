using Fungus;
using System.Collections;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    //private Animator animator; //NPC����
    //[SerializeField]private string talkText="Oh!You are here.";
    [SerializeField] private string chatName_01;
    private Flowchart flowchart;

    //�ҵ�NPC�� ���������
    public void Interact() 
    {
        Say();
        StartCoroutine(StartTask());
        //ChatBubble.Create(transform.transform, new Vector3(-3,0,0), ChatBubble.IconType.Happy,talkText);
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
            yield return null; // �ȴ�һ֡
        }

        TaskManager.Instance.TalkWith(this);
        yield break;
    }
}
