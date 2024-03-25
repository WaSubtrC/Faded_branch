using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaManager : Singleton<SavaManager>
{

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }


    //使用JSON方法  以及 PlayerPrefs 保存数据
    public void Save(Object data,string key)
    {
        var jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }
    public void Load(Object data,string key) 
    {
        if(PlayerPrefs.HasKey(key)) 
        {
            
        }


    }


}
