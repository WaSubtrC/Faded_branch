using UnityEngine;

public class CharacterStats : MonoBehaviour
{
   [Header("Weapon")]
   public Transform weaponSlot;
    [Header("Stats SO")]
   [SerializeField]public CharacterData_SO characterData;

    #region Read form Data_SO


    //public float MaxHealth
    //{
    //    get { if(characterData != null)   return characterData.maxHealth;     else return 0;}
    //    set { characterData.maxHealth = value;}
    //}

    //public uint coins{
    //  get { if (characterData != null) return characterData.coins; else return 0; } 
    //  set {  characterData.coins = value; } 
    //}

    //public float CurrentHealth { 
    //    get { if (characterData != null) { return characterData.currHealth; } else return 0; }
    //    set { characterData.currHealth = value; }
    //}

    #endregion


    public void EquipWeapon(ItemData_SO weapon)
   {
      if(weapon.weaponPrefab != null)
      {
         Instantiate(weapon.weaponPrefab,weaponSlot);
      }
   }
}
