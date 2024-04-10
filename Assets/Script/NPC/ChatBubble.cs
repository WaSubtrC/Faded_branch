using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    public static void Create(Transform parent,Vector3 localPosition, IconType iconType,string text)
    {
        Transform chatBubbleTransform = Instantiate(GameManager.Instance.pfChatBubble, parent);
        chatBubbleTransform.localPosition = localPosition;

        chatBubbleTransform.GetComponent<ChatBubble>().Setup(iconType, text);

        if(chatBubbleTransform != null && Input.GetKeyDown(KeyCode.E))
        Destroy(chatBubbleTransform.gameObject,3f); //���� �Ա������һ�仰

    }
    
    public enum IconType    //NPC�ض��� ����||����image ����еĻ�
    {
        Happy,Neutral,Angry
    }

    [SerializeField] private Sprite happyIconSprite;
    [SerializeField] private Sprite neutralIconSprite;
    [SerializeField] private Sprite angryIconSprite;


    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent <SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        //Setup(IconType.Happy,"Hello World!As you can see,this is a chat test!");
    }

    private void Setup(IconType iconType,string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();  //ǿ��ˢ��
        Vector2 textSize = textMeshPro.GetRenderedValues(false); 
        //����ƥ���ı���С
        Vector2 padding = new Vector2(2.3f, 1.3f);
        //Debug.Log("textSize = " + textSize);
        //Debug.Log("padding" + padding);
        backgroundSpriteRenderer.size = textSize+ padding; //background spriteҪ�ĳ�sliced������Ч


        //����text��background֮���ƫ���� ����text��ȫ��background�� x=size/2;   y,z����
        Vector3 offset = new Vector2(0.32f, 0f);
        backgroundSpriteRenderer.transform.localPosition = 
            new Vector3(backgroundSpriteRenderer.size.x / 2f, backgroundSpriteRenderer.transform.localPosition.y)+offset;

        iconSpriteRenderer.sprite = GetIconSprite(iconType);

        //To do ���ֻ�Ч�� ����

    }

    private Sprite GetIconSprite(IconType iconType)
    {
        switch(iconType) 
        {
            default:
                case IconType.Happy:    return happyIconSprite;
                case IconType.Neutral:  return neutralIconSprite;
                case IconType.Angry:    return angryIconSprite;
               




        }
    }
}
