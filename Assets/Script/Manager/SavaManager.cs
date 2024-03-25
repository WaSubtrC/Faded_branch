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


    //ʹ��JSON����  �Լ� PlayerPrefs ��������
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
