using UnityEngine;

public class GameAssets : Singleton<GameAssets>
{
    #region trash

    //单例模式 改成继承Singleton，所以不用
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

    //引用特定的prefab 后期整合改到其他脚本
    //在chatBubble 中引用
    [Header("Prefab")]
    public Transform pfChatBubble;
    public GameObject pfStoreUI;

}
