using TMPro;

using UnityEngine;

enum ValueType { 
    maxMana,
    currMana,
    maxExp,
    currExp,
    maxHealth,
    currHealth,
    damage,
    defense,
    speed,
    coins,
    level 
}

namespace Faded.Town {
    public class StatsHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI statName;
        [SerializeField] private TextMeshProUGUI StatValue;
        [SerializeField] private ValueType valueType;
        private bool refreshed = false;

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
                if(GameManager.Instance.playerStats != null)
                    RefreshStatsBar();
                isRefresh = true;
            }
        }

        private void RefreshStatsBar()
        {
            switch (valueType)
            {
                case ValueType.maxMana:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.maxMana.ToString());
                    break;
                case ValueType.currMana:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.currMana.ToString());
                    break ;
                case ValueType.maxExp:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.maxExp.ToString());
                    break;
                case ValueType.currExp:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.currExp.ToString());
                    break;
                case ValueType.maxHealth: 
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.maxHealth.ToString());
                    break;
                case ValueType.currHealth:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.currHealth.ToString());
                    break;
                case ValueType.damage:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.baseDamage.ToString());
                    break;
                case ValueType.defense:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.baseDefense.ToString());
                    break;
                case ValueType.speed:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.speed.ToString());
                    break;
                case ValueType.coins:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.coins.ToString());
                    break;
                case ValueType.level:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.level.ToString());
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
}
