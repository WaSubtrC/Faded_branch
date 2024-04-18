using System;
using UnityEngine;


public enum Buff {Nothing ,Starvation }
[CreateAssetMenu(fileName ="New Data",menuName = "Character Stats/Data")]
public class CharacterData_SO : ScriptableObject
{
    [Header("Stats Info")]
    [Header("ս�� ���״̬")]
    public float maxMana;
    public float currMana;
    public float maxHealth;
    public float currHealth;
    public int strength;
    public float speed;

    [Header("������Ϣ")]
    public int hunger;
    public int stamina;
    public int coins ;
    public int level;
    public Buff buff;

    public CharacterData_SO()
    {
        // ��������г�ʼ����������������
    }
    



}
