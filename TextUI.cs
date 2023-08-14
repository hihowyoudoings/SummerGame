using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    //text objects
    public GameObject bottomInfo;
    public GameObject playerHPInfo;
    public GameObject playerDefenceInfo;
    public GameObject playerAttackInfo;
    public GameObject areaInfo;
    public GameObject warningInfo;

    //text's text
    public static string warning = "";
    public static string bottomText = "";
    //text components
    TextMeshProUGUI bottomInfoText;
    TextMeshProUGUI playerHPInfoText;
    TextMeshProUGUI playerDefenceInfoText;
    TextMeshProUGUI playerAttackInfoText;
    TextMeshProUGUI areaInfoText;
    TextMeshProUGUI warningInfoText;

    private void Start() {
        bottomInfoText = bottomInfo.GetComponent<TextMeshProUGUI>();
        playerHPInfoText = playerHPInfo.GetComponent<TextMeshProUGUI>();
        playerDefenceInfoText = playerDefenceInfo.GetComponent<TextMeshProUGUI>();
        playerAttackInfoText = playerAttackInfo.GetComponent<TextMeshProUGUI>();
        areaInfoText = areaInfo.GetComponent<TextMeshProUGUI>();
        warningInfoText = warningInfo.GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        bottomInfoText.text = bottomText;
        playerHPInfoText.text = "HP: " + Player.health.ToString() + "/" + Player.maxHealth.ToString();
        playerDefenceInfoText.text = "Defence: " + Player.defence.ToString();
        playerAttackInfoText.text = "Attack: " + Player.attack.ToString();
        areaInfoText.text = "0";
        warningInfoText.text = warning;
    }
    
}
