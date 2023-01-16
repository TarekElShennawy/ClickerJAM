using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Awake()
    {
        damageDealt = 0;
        damagePerSecond = 0;
        InvokeRepeating("AddDps", 1f, 1f);

        currentShip = Ships.Recon;
        
        ChangeShip(Ships.Recon);
    }

    public Ships ChangeShip(Ships ship) //TODO: Works but code could be cleaner. Re-factor the two-liner instantiate + parent to it's own method
    {
            

        switch(ship)
        {
            case Ships.Recon:
                GameObject reconShip = Instantiate(reconGfx, new Vector3(1.11f, -6.05f, 1f), Quaternion.identity);
                reconShip.transform.parent = ShipSlot.transform;

                break;
            case Ships.Fighter:
                Destroy(ShipSlot.transform.GetChild(0).gameObject);

                GameObject redFighterShip = Instantiate(fighterGfx, new Vector3(3.8f,-4.8f,6.17f), Quaternion.identity);
                redFighterShip.transform.parent = ShipSlot.transform;
                break;

            case Ships.Trooper:
                Destroy(ShipSlot.transform.GetChild(0).gameObject);

                GameObject trooperShip = Instantiate(trooperGfx, new Vector3(3.8f,-4.8f,6.17f), Quaternion.identity);
                trooperShip.transform.parent = ShipSlot.transform;
                break;
            case Ships.Meteor:
                Destroy(ShipSlot.transform.GetChild(0).gameObject);

                GameObject meteorShip = Instantiate(meteorGfx, new Vector3(3.8f,-4.8f,6.17f), Quaternion.identity);
                meteorShip.transform.parent = ShipSlot.transform;
                break;
        } 

        currentShip = ship;

        return ship;
    }
    
    void Update() 
    {
        
        damageUI.text = "Damage: " + damageDealt;
        dpsUI.text = "DPS: " + damagePerSecond;
        
    }

    private void AddDps()
    {
        damageDealt += damagePerSecond;
    }
}
