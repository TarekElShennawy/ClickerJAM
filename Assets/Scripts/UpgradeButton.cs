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

    [SerializeField]
    private AudioSource audioSrc;
    
    [SerializeField]
    private AudioClip clickSfx;

    public void Start()
    {
        button.onClick.AddListener(ApplyDPS);
    }

    private void ApplyDPS()
    {
        audioSrc.PlayOneShot(clickSfx);

        if(gameInstance.damageDealt >= upgradeCost)
        { 
            powerup.Apply(gameInstance);
            gameInstance.damageDealt -= upgradeCost;
        }
        
    }
}
