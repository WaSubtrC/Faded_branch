using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISingleton : Singleton<UISingleton>
{
    protected override void Awake()
    {

        DontDestroyOnLoad(this);
    }
}
