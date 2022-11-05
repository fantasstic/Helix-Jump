using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;

    private void OnEnable()
    {
        Ball.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        Ball.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
