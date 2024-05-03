using TMPro;

using UnityEngine;


namespace Faded.Town
{
    public class StatsPromptHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI StatValue;
        [SerializeField] private ValueType valueType;
        private bool refreshed = false;

        void Start()
        {
            RefreshStatsBar();
        }

        void Update()
        {
            RefreshStatsBar();
        }

        private void RefreshStatsBar()
        {
            if (GameManager.Instance.playerStats.playerData == null) return;
            switch (valueType)
            {
                case ValueType.maxMana:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.maxMana.ToString());
                    break;
                case ValueType.currMana:
                    AssignText(valueType.ToString(), GameManager.Instance.playerStats.playerData.currMana.ToString());
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
                    AssignText("Error statName", "Error value");
                    break;

            }
        }

        private void AssignText(string _statName, string _valueText)
        {
            if (!refreshed)
            {
                refreshed = true;
            }
            StatValue.text = _valueText;
        }
    }
}
