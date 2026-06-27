using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCardController : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;
    public UpgradesController.UpgradesEnum Upgrades;
    public bool IsPlayerOne;
    


    public void OnClick()
    {
        UpgradesController.Instance.ChooseUpgrade(Upgrades, IsPlayerOne);
        GameState.Instance.gameState = GameState.GameStateEnum.InMatch;
        ReadyView.Instance.CloseUpgrades();
    }
}
