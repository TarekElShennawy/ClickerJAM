using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Button button;

    public Game gameInstance;

    public PowerupEffect powerup;

    public float upgradeCost;

    public void Start()
    {
        button.onClick.AddListener(ApplyDPS);
    }

    private void ApplyDPS()
    {
        if(gameInstance.damageDealt >= upgradeCost)
        {
            powerup.Apply(gameInstance);
            gameInstance.damageDealt -= upgradeCost;
        }
        
    }
}
