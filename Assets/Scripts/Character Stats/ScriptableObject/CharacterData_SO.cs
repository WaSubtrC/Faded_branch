using System;
using UnityEngine;


public enum Buff {Nothing ,Starvation }
[CreateAssetMenu(fileName ="New Data",menuName = "Character Stats/Data")]
public class CharacterData_SO : ScriptableObject
{
    [Header("Stats Info")]
    [Header("战斗 相关状态")]
    public float maxMana;
    public float currMana;
    public float maxHealth;
    public float currHealth;
    public int strength;
    public float speed;

    [Header("其他信息")]
    public int hunger;
    public int stamina;
    public int coins ;
    public int level;
    public Buff buff;

    public CharacterData_SO()
    {
        // 在这里进行初始化操作，或者留空
    }
    



}
