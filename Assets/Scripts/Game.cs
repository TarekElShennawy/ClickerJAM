using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public float damageDealt;
    public float damagePerSecond;
    public float totalDamage;

    public TextMeshProUGUI damageUI;
    public TextMeshProUGUI dpsUI;

    public GameObject ShipSlot;

    public enum Ships {Recon, Fighter, Trooper, Meteor}
    public Ships currentShip;

    //List of Ship Gfx
    public GameObject reconGfx;
    public GameObject fighterGfx;
    public GameObject trooperGfx;
    public GameObject meteorGfx;

    //List of achievement icons
    public List<Image> shipAchievementIcons;
    public List<TextMeshProUGUI> damageAchievementText;

    void Awake()
    {
        damageDealt = 0;
        damagePerSecond = 0;
        InvokeRepeating("AddDps", 1f, 1f);

        currentShip = Ships.Recon;
        
        ChangeShip(Ships.Recon);

        
    }

    public Ships ChangeShip(Ships ship)
    {
            
        switch(ship)
        {
            case Ships.Recon:
                GameObject reconShip = Instantiate(reconGfx, new Vector3(1.11f, -6.05f, 1f), Quaternion.identity);
                reconShip.transform.parent = ShipSlot.transform;
                break;

            case Ships.Fighter:
                Destroy(ShipSlot.transform.GetChild(0).gameObject);
                UnlockAchievement(shipAchievementIcons[0]);

                GameObject redFighterShip = Instantiate(fighterGfx, new Vector3(3.8f,-4.8f,6.17f), Quaternion.identity);
                redFighterShip.transform.parent = ShipSlot.transform;
                
                break;

            case Ships.Trooper:
                Destroy(ShipSlot.transform.GetChild(0).gameObject);
                UnlockAchievement(shipAchievementIcons[1]);

                GameObject trooperShip = Instantiate(trooperGfx, new Vector3(3.9f,-4.8f,6.17f), Quaternion.identity);
                trooperShip.transform.parent = ShipSlot.transform;
                break;
            case Ships.Meteor:
                Destroy(ShipSlot.transform.GetChild(0).gameObject);
                UnlockAchievement(shipAchievementIcons[2]);

                GameObject meteorShip = Instantiate(meteorGfx, new Vector3(3.8f,-4.8f,6.17f), Quaternion.identity);
                meteorShip.transform.parent = ShipSlot.transform;
                break;
        } 

        currentShip = ship;

        return ship;
    }

    void UnlockAchievement(Image icon)
    {
        var unlockedAchievement = icon.color;
        unlockedAchievement.a = 1f;
        icon.color = unlockedAchievement;
    }

    void UnlockDamageAchievement(TextMeshProUGUI damageIcon)
    {
        damageIcon.alpha = 1f;
    }
    
    void Update() 
    {
        
        damageUI.text = "Damage: " + damageDealt;
        dpsUI.text = "DPS: " + damagePerSecond;

        //Checking for total damage to update achievements, TODO (post game-jam due to time): clean up the achievement code into its own script
        if(totalDamage % 100 == 0)
        {
            switch(totalDamage)
            {
                case >= 2000:
                    UnlockDamageAchievement(damageAchievementText[2]);
                    break;
                case >= 1000:
                    UnlockDamageAchievement(damageAchievementText[1]);
                    break;
                case >= 100:
                    UnlockDamageAchievement(damageAchievementText[0]);
                    break;
            }
        }
        
    }

    private void AddDps()
    {
        damageDealt += damagePerSecond;
        totalDamage += damagePerSecond;
    }
}
