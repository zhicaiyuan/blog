using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatSlot : MonoBehaviour
{
    [SerializeField] private string statname;
    [SerializeField] private StatType stattype;
    [SerializeField] private TextMeshProUGUI statValueText;
    [SerializeField] private TextMeshProUGUI statNameText;

    private void OnValidate()
    {
        gameObject.name = "属性：" + statname;


        if(statValueText != null )
            statNameText.text = statname;
    }
     void Start()
    {
        UpdateStatValueUI();
    }
    public void UpdateStatValueUI()
    {
        PlayerStat playerStat = playermanger.instance.player.GetComponent<PlayerStat>();

        if (playerStat != null)
        {
            statValueText.text = playerStat.GetStat(stattype).Getvalue().ToString();
        }
    }
}
