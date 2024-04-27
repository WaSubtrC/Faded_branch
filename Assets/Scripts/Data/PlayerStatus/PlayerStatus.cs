using UnityEngine;

public class PlayerStatus : Singleton<PlayerStatus>
{
   [Header("Weapon")]
   public Transform weaponSlot;
   
   [Header("Stats SO")]
   [SerializeField] public PlayerStatus_SO playerData;
   [SerializeField] public PlayerStatus_SO playerDataTemplate;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (playerData == null)
        {
            if (GameManager.Instance.playerStats.playerData != null)
            {
                AssignFromTemplete(GameManager.Instance.playerStats.playerData, ref playerData);
                Debug.Log("Init by hard disk");
            }
            else
            {
                AssignFromTemplete(playerDataTemplate, ref playerData);
                Debug.Log("Init by dafault data");
            }

        }
        else
        {
            Debug.Log("Nothing to init");
        }
    }

    #region Read form Data_SO


    //public float MaxHealth
    //{
    //    get { if(playerData != null)   return playerData.maxHealth;     else return 0;}
    //    set { playerData.maxHealth = value;}
    //}

    //public int coins
    //{
    //    get { if (playerData != null) return playerData.coins; else return 0; }
    //    set { playerData.coins = value; }
    //}

    //public float CurrentHealth { 
    //    get { if (playerData != null) { return playerData.currHealth; } else return 0; }
    //    set { playerData.currHealth = value; }
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

    void AssignFromTemplete(PlayerStatus_SO template, ref PlayerStatus_SO data)
    {
        if (template != null)
        {
            data = Instantiate(template);
        }
        else
        {
            Debug.LogError(template + "模板对象为空，无法创建副本。");
        }
    }
}
