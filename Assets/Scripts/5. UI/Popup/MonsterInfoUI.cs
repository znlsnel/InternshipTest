using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI maxHpText;
    [SerializeField] private TextMeshProUGUI attackRangeText;
    [SerializeField] private TextMeshProUGUI moveSpeedText;

    public void Setup(MonsterData data)
    {
        gameObject.SetActive(true);
        nameText.text = data.Name;
        attackText.text = data.Attack.ToString();
        maxHpText.text = data.MaxHP.ToString();
        attackRangeText.text = data.AttackRange.ToString();
        moveSpeedText.text = data.MoveSpeed.ToString();
    }
}
