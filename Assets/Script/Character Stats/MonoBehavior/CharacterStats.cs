using UnityEngine;

public class CharacterStats : MonoBehaviour
{
   [Header("Weapon")]
   public Transform weaponSlot;
    [Header("Stats SO")]
   [SerializeField]public CharacterData_SO characterData;

    #region Read form Data_SO


    public int MaxHealth
    {
        get { if(characterData != null)   return characterData.maxHealth;     else return 0;}
        set { characterData.maxHealth = value;}
    }

    public uint Money{
      get { if (characterData != null) return characterData.money; else return 0; } 
      set {  characterData.money = value; } 
    }

    public int CurrentHealth { 
        get { if (characterData != null) { return characterData.currentHealth; } else return 0; }
        set { characterData.currentHealth = value; }
    }

    #endregion


    public void EquipWeapon(ItemData_SO weapon)
   {
      if(weapon.weaponPrefab != null)
      {
         Instantiate(weapon.weaponPrefab,weaponSlot);
      }
   }
}
