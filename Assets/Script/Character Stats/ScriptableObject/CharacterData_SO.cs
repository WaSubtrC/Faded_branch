using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Data",menuName = "Character Stats/Data")]
    public class CharacterData_SO :ScriptableObject
{
    //Stats Info

    //��ӽ�ɫ ���� ���� ��Ȼ����ChatacterStats���get set
    public int maxHealth;
    public int currentHealth;
    public uint money = 0;
    public CharacterData_SO()
    {
        // ��������г�ʼ����������������
    }




}
