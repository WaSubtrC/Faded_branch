using UnityEngine;

public class GameAssets : Singleton<GameAssets>
{
    #region trash

    //����ģʽ �ĳɼ̳�Singleton�����Բ���
    //private static GameAssets _i;
    //public static GameAssets i
    //{
    //    get
    //    {
    //        if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
    //        return _i;
    //    }
    //}
    #endregion

    //�����ض���prefab �������ϸĵ������ű�
    //��chatBubble ������
    [Header("Prefab")]
    public Transform pfChatBubble;
    public GameObject pfStoreUI;

}
