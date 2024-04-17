using TMPro;

using UnityEngine;

enum ValueType 
{ maxMana,currMana,maxHealth,currHealth,
    Strength,speed,
  Hunger,Stamina,coins,
  level, buff 
}
public class StatsHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statName;
    [SerializeField] private TextMeshProUGUI StatValue;
    [SerializeField] private ValueType valueType;
    private bool refreshed =false;

    void Start()
    {
        RefreshStatsBar();
    }
    void Update()
    {
            var isRefresh = false;
        if (!this.gameObject.activeSelf)
        {
            isRefresh = false;
        }else if (!isRefresh)
            {
            RefreshStatsBar();
            isRefresh = true;
            }
    }

    private void RefreshStatsBar()
    {
        switch (valueType)
        {
            case ValueType.maxMana:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.maxMana.ToString());
                break;
            case ValueType.currMana:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.currMana.ToString());
                break ;
            case ValueType.maxHealth: 
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.maxHealth.ToString());
                break;
            case ValueType.currHealth:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.currHealth.ToString());
                break;

            case ValueType.Strength:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.strength.ToString());
                break;
            case ValueType.speed:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.speed.ToString());
                break;

            case ValueType.Hunger:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.hunger.ToString());
                break;
            case ValueType.Stamina:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.stamina.ToString());
                break;
            case ValueType.coins:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.coins.ToString());
                break;
            case ValueType.level:
                AssignText(valueType.ToString(), GameManager.Instance.playerStats.characterData.level.ToString());
                break;
            default:
                AssignText("Error statName","Error value");
                break;

        }
    }

    private void AssignText(string _statName,string _valueText)
    {
        if(!refreshed) 
        {
        statName.text = _statName;
        refreshed = true;
        }
        StatValue.text = _valueText;
    }
}
