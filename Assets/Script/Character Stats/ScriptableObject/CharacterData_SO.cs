using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Data",menuName = "Character Stats/Data")]
    public class CharacterData_SO :ScriptableObject
{
    //Stats Info

    //添加角色 各种 属性 ；然后在ChatacterStats添加get set
    public int maxHealth;
    public int currentHealth;
    public uint money = 0;
    public CharacterData_SO()
    {
        // 在这里进行初始化操作，或者留空
    }




}
