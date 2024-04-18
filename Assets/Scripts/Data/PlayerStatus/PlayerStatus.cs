using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
   [Header("Weapon")]
   public Transform weaponSlot;
   
   [Header("Stats SO")]
   [SerializeField] public PlayerStatus_SO characterData;

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

    #region EquipWeapon

    public void ChangeWeapon(ItemData_SO weapon)
    {
        UnEquipWeapon();
        EquipWeapon(weapon);
    }
    public void EquipWeapon(ItemData_SO weapon)
    {
      if(weapon.weaponPrefab != null)
      {
         Instantiate(weapon.weaponPrefab,weaponSlot);
      }
      //attackData.ApplyWeaponData(weapon, weaponData);
    }

    public void UnEquipWeapon()
    {
        if(weaponSlot.transform.childCount == 0)
        {
            foreach(var gameobject in weaponSlot.transform.GetComponentsInChildren<GameObject>())
            {
                Destroy(gameobject);
                
            }
        }
    }

    #endregion
}
