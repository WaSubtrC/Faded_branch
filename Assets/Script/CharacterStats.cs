using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
   [Header("Weapon")]
   public Transform weaponSlot;
    [Header("Player Stats")]
   [SerializeField]public uint money = 0;

   public void EquipWeapon(ItemData_SO weapon)
   {
      if(weapon.weaponPrefab != null)
      {
         Instantiate(weapon.weaponPrefab,weaponSlot);
      }
   }
}
