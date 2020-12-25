using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GoldText : MonoBehaviour
{
    private TextMeshProUGUI goldText;

    private void Awake()
    {
        goldText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        PlayerManager.OnGoldUpdated += UpdateGoldText;
    }

    private void UpdateGoldText(int gold)
    {
        goldText.text = "<b>Gold:</b> " + gold;
    }

    private void OnDisable()
    {
        PlayerManager.OnGoldUpdated -= UpdateGoldText;
    }
}
