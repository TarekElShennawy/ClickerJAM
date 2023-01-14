using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public float damageDealt;
    public float damagePerSecond;

    public TextMeshProUGUI damageUI;
    public TextMeshProUGUI dpsUI;

    public GameObject ShipSlot;

    public enum Ships {Recon, RedFighter}
    public Ships currentShip;

    //List of Ship Gfx
    public GameObject reconGfx;
    public GameObject redFighterGfx;

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
        
        //Ship switching logic
        if(ship == Ships.Recon)
        {
            GameObject reconShip = Instantiate(reconGfx, new Vector3(1.11f, -6.05f, 1f), Quaternion.identity);

            reconShip.transform.parent = ShipSlot.transform;
        }
        else if(ship == Ships.RedFighter)
        {
            //TODO: Had to hard-code the destruction of previous ships for new, change as necessary
            Destroy(GameObject.Find("Recon(Clone)"));

            GameObject redFighterShip = Instantiate(redFighterGfx, new Vector3(3.8f,-4.8f,6.17f), Quaternion.identity);

            redFighterShip.transform.parent = ShipSlot.transform;
        }

        currentShip = ship;

        return ship;
    }

    // Update is called once per frame
    
    void Update() 
    {
        
        damageUI.text = "Damage: " + damageDealt;
        dpsUI.text = "DPS: " + damagePerSecond;
        
    }

    private void AddDps()
    {
        damageDealt+= damagePerSecond;
    }
}
